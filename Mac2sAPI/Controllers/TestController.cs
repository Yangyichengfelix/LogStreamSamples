using AutoMapper;
using Mac2sAPI.Configurations;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.Sensor;
using Mac2sAPI.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<SensorS1Hub> _hub;
        private readonly TimerManager _timer;
        private readonly ISensorUniqueRepository _repo;
        private readonly IMapper _mapper;
        private Mac2sAPIDbContext _db { get; set; }
        public TestController(IHubContext<SensorS1Hub> hub, TimerManager timer, ISensorUniqueRepository repo, IMapper mapper)
        {
            _hub = hub;
            _timer = timer;
            _repo = repo;
            _mapper = mapper;
        
        }


    }
}
