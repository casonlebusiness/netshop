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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ILinkService<CategoriesController> _linkService;

        public CategoriesController(
            ICategoryRepo categoryRepo,
            IMapper mapper,
            ILinkService<CategoriesController> linkService)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet]
        [Route(("{id:int}"), Name = nameof(GetSingle))]
        public ActionResult GetSingle(ApiVersion version, int id) {
            CategoryDisplayDto categoryDisplayDto = _mapper.Map<CategoryDisplayDto>(_categoryRepo.GetSingle(id));
            return Ok(categoryDisplayDto);
        }

        [HttpPost(Name = nameof(AddItem))]
        public ActionResult AddItem(ApiVersion version, [FromBody] CategoryCreateDTO categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
              return BadRequest();
            }

            CategoryEntity toAdd = _mapper.Map<CategoryEntity>(categoryCreateDto);

            _categoryRepo.Add(toAdd);

            if (!_categoryRepo.Save())
            {
                throw new Exception("Creating a category failed on save.");
            }

            return Ok();
        }
    }
}
