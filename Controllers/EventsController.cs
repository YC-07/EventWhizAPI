using AutoMapper;
using EventWhiz.CustomActionFilters;
using EventWhiz.Models.Domain;
using EventWhiz.Models.DTO;
using EventWhiz.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventWhiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;

        public EventsController(IMapper mapper,IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }

        //GET: api/events/filterOn=Name&filterQuery&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize=1000 )
        {
            //get all data from SQLLocationRepository
            throw new Exception("temp");
            var eventDomainModel = await eventRepository.GetAllEvent(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<EventDTO>>(eventDomainModel));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var eventDomainModel = await eventRepository.GetEventById(id);
            if(eventDomainModel== null)
            {
                return NotFound();
            }
            //convert doainModel to DTO
            return Ok(mapper.Map<EventDTO>(eventDomainModel));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddEventRequestDTO addEventRequestDTO)
        {
            //convert DTO to domain model
            var eventDomainModel = mapper.Map<Event>(addEventRequestDTO);
            await eventRepository.CreateEvent(eventDomainModel);

            //Map domain Model to DTO return DTO

            return Ok(mapper.Map<EventDTO>(eventDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventRequestDTO updateEventRequestDTO)
        {
                //Map DTO to domain Model
                var eventDomainModel = mapper.Map<Event>(updateEventRequestDTO);
                eventDomainModel = await eventRepository.UpdateEvent(id, eventDomainModel);
                if (eventDomainModel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<EventDTO>(eventDomainModel));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var eventDomainModel = await eventRepository.DeleteEvent(id);
            if(eventDomainModel==null)
            { 
                return NotFound();
            }
            return Ok(mapper.Map<EventDTO>(eventDomainModel));
        }
    }
}
