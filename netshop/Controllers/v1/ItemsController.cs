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
    }
}
