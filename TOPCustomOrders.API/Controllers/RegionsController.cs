using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TOPCustomOrders.API.CustomActionsFilters;
using TOPCustomOrders.API.Data;
using TOPCustomOrders.API.Models.Domain;
using TOPCustomOrders.API.Models.DTO;
using TOPCustomOrders.API.Repositories;

namespace TOPCustomOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAllV1()
        {
            // Get dat from Database - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            // Map Domain Models to DTOs
            var regionsDto = mapper.Map<List<RegionDTO>>(regionsDomain);

            //Return DTOs
            return Ok(regionsDto);
        }

        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null) {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDTO>(regionDomain);

            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult> Create([FromBody] AddRegionRequestDTO regionRequestDto)
        {
            var regionDomainModel = mapper.Map<Region>(regionRequestDto);

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO regionRequestDto)
        {
            var regionDomainModel = mapper.Map<Region>(regionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null) 
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
