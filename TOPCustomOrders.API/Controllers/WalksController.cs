using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOPCustomOrders.API.CustomActionsFilters;
using TOPCustomOrders.API.Data;
using TOPCustomOrders.API.Models.Domain;
using TOPCustomOrders.API.Models.DTO;
using TOPCustomOrders.API.Repositories;

namespace TOPCustomOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterBy, [FromQuery] string? filterValue, [FromQuery] string? sortBy,
            [FromQuery] string? sortOrder, [FromQuery] int page = 1, [FromQuery] int limit = 15)
        {
            var walkDomainModel = await walkRepository.GetAllAsync(filterBy, filterValue, sortBy, sortOrder,
                page, limit);

            var regionsDto = mapper.Map<List<WalkDTO>>(walkDomainModel);

            return Ok(regionsDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO walkRequestDto)
        {
            // Map Request DTO to Walk Domain Model
            var walkDomainModel = mapper.Map<Walk>(walkRequestDto);

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            // map Walk Domain Model to Walk DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO walkRequestDTO)
        {
            var walkDomainModel = mapper.Map<Walk>(walkRequestDTO);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDTO);
        }
    }
}
