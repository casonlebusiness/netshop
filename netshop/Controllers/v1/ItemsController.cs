using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using netshop.Dtos;
using netshop.Entities;
using netshop.Helpers;
using netshop.Services;
using netshop.Models;
using netshop.Repositories;
using System.Text.Json;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace netshop.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepo;
        private readonly IMapper _mapper;
        private readonly ILinkService<ItemsController> _linkService;

        public ItemsController(
            IItemRepository itemRepo,
            IMapper mapper,
            ILinkService<ItemsController> linkService)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet(Name = nameof(GetAllItems))]
        public ActionResult GetAllItems(ApiVersion version, [FromQuery] QueryParameters queryParameters)
        {
            List<ItemEntity> foodItems = _itemRepo.GetAll(queryParameters).ToList();

            var allItemCount = _itemRepo.Count();

            var paginationMetadata = new
            {
                totalCount = allItemCount,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages(allItemCount)
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var links = _linkService.CreateLinksForCollection(queryParameters, allItemCount, version);
            var toReturn = foodItems.Select(x => _linkService.ExpandSingleFoodItem(x, x.Id, version));

            return Ok(new
            {
                value = toReturn,
                links = links
            });
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleItem))]
        public ActionResult GetSingleItem(ApiVersion version, int id)
        {
            ItemEntity item = _itemRepo.GetSingle(id);

            if (item == null)
            {
                return NotFound();
            }

            ItemDto itemDto = _mapper.Map<ItemDto>(item);

            return Ok(_linkService.ExpandSingleFoodItem(itemDto, itemDto.Id, version));
        }

        [HttpPost(), Route("/AddItem")]
        public ActionResult<ItemDto> AddItem(ApiVersion version, [FromBody] ItemCreateDto itemCreateDto)
        {
            if (itemCreateDto == null)
            {
                return BadRequest();
            }

            ItemEntity toAdd = _mapper.Map<ItemEntity>(itemCreateDto);

            _itemRepo.Add(toAdd);

            if (!_itemRepo.Save())
            {
                throw new Exception("Creating a item failed on save.");
            }

            ItemEntity newItem = _itemRepo.GetSingle(toAdd.Id);
            ItemDto itemDto = _mapper.Map<ItemDto>(newItem);

            return CreatedAtRoute(nameof(GetSingleItem),
                new { version = version.ToString(), id = newItem.Id },
                _linkService.ExpandSingleFoodItem(itemDto, itemDto.Id, version));
        }
    }
}
