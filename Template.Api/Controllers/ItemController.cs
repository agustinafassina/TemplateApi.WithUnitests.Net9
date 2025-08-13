using AutoMapper;
using TemplateApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemplateApi.Services.Dto;
using Microsoft.AspNetCore.Authorization;

namespace TemplateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Auth0App1")]
        [HttpGet("version")]
        public async Task<IActionResult> GetVersion()
        {
            return Ok("v.1.0.0");
        }

        [HttpGet("items")]
        public IActionResult GetItems()
        {
            IEnumerable<ItemDto> items = _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ItemDto item = _itemService.GetItemById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}