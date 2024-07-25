using AutoMapper;
using EventWhiz.CustomActionFilters;
using EventWhiz.Data;
using EventWhiz.Models.Domain;
using EventWhiz.Models.DTO;
using EventWhiz.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace EventWhiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly EventWhizDBContext _dbContext;
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;
        private readonly ILogger<LocationsController> logger;

        public LocationsController(EventWhizDBContext dbContext,ILocationRepository locationRepository,
            IMapper mapper, ILogger<LocationsController> logger)
        {
            this._dbContext = dbContext;
            this.locationRepository = locationRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var locationsDomain = await locationRepository.GetAllLocations();

                var locationDTOs = mapper.Map<List<LocationDTO>>(locationsDomain);

                return Ok(locationDTOs);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest("bad");
            }
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var location = await locationRepository.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
           //return DTO to client

            return Ok(mapper.Map<LocationDTO>(location));
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddLocationRequestDTO addLocationRequestDTO)
        {
           
                //convert DTO to domain model
                var locationDomainModel = mapper.Map<Location>(addLocationRequestDTO);
                await locationRepository.CreateLocation(locationDomainModel);

                //Map domain Model to DTO
                var locationDTO = mapper.Map<LocationDTO>(locationDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = locationDomainModel.Id }, locationDTO);
          
        }

        //create put action method 
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLocationRequestDTO updateLocationRequestDTO)
        {
            
                var locationDomainModel = mapper.Map<Location>(updateLocationRequestDTO);
                locationDomainModel = await locationRepository.UpdateLocation(id, locationDomainModel);
                if (locationDomainModel == null)
                {
                    return NotFound();
                }
                //convert domainModel to DTO
                return Ok(mapper.Map<LocationDTO>(locationDomainModel));
           
        }

        //delete entry
        [HttpDelete]
        [Route("{id:Guid}")]
      //  [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var locationDomainModel = await locationRepository.DeleteLocation(id);
            if (locationDomainModel == null)
            {
                return NotFound();
            }
            //convert domainModel to DTO
            return Ok(mapper.Map<LocationDTO>(locationDomainModel));
        }

    }
}
