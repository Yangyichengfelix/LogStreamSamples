using AutoMapper;
using Mac2sAPI.Configurations;
using Mac2sAPI.Contracts;
using Mac2sAPI.Dtos.Sensor;
using Mac2sAPI.Hubs;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ILogger<SensorsController> _logger;
        private readonly IHubContext<SensorS1Hub> _hub;
        private readonly TimerManager _timer;
        private readonly ISensorUniqueRepository _uniqueRepository;
        private readonly ISensorPlRepository _plRepository;
        private readonly ISensorGlobalRepository _globalRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public SensorsController(ILogger<SensorsController> logger, IHubContext<SensorS1Hub> hub, TimerManager timer, ISensorUniqueRepository uniqueRepository, 
            ISensorPlRepository plRepository, ISensorGlobalRepository globalRepository,  IMapper mapper, IEmailSender emailSender)
        {
            _hub = hub;
            _timer = timer;
            _uniqueRepository = uniqueRepository;
            _plRepository=plRepository;
            _globalRepository = globalRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender=emailSender;
        }



        [HttpGet("s1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS1Value(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _uniqueRepository.Sensor1ValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorUniqueDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS1Value)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetS1Value)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetS1Value)}", statusCode: 500);
            }
        }
        [HttpGet("s2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS2Value(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _uniqueRepository.Sensor2ValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorUniqueDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS2Value)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetS2Value)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetS2Value)}", statusCode: 500);
            }
        }
        [HttpGet("s3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS3Value(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _uniqueRepository.Sensor3ValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorUniqueDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS3Value)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetS3Value)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetS3Value)}", statusCode: 500);
            }
        }
        [HttpGet("s4")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS4Value(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _uniqueRepository.Sensor4ValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorUniqueDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS4Value)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetS4Value)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetS4Value)}", statusCode: 500);
            }
        }
        [HttpGet("s5")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS5Value(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _uniqueRepository.Sensor5ValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorUniqueDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS5Value)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetS5Value)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetS5Value)}", statusCode: 500);
            }
        }
        [HttpGet("spl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSplValue(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _plRepository.SensorPlValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorPlDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetSplValue)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetSplValue)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetSplValue)}", statusCode: 500);
            }
        }


        [HttpGet("sg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSgValue(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _globalRepository.SensorGlobalValueTimeRange(start, end);
                var response = _mapper.Map<IList<SensorGlobalDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetSgValue)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetSgValue)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetSgValue)}", statusCode: 500);
            }
        }

        [HttpGet("s1last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS1LastValue()
        {
            try
            {
                var logs = await _uniqueRepository.Sensor1RealTime();
                var response = _mapper.Map<SensorUniqueDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS1LastValue)}");
                return Problem($"Something went wrong in the {nameof(GetS1LastValue)}", statusCode: 500);
            }
        }

        [HttpGet("s2last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS2LastValue()
        {
            try
            {
                var logs = await _uniqueRepository.Sensor2RealTime();
                var response = _mapper.Map<SensorUniqueDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS2LastValue)}");
                return Problem($"Something went wrong in the {nameof(GetS2LastValue)}", statusCode: 500);
            }
        }
        [HttpGet("s3last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS3LastValue()
        {
            try
            {
                var logs = await _uniqueRepository.Sensor3RealTime();
                var response = _mapper.Map<SensorUniqueDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS3LastValue)}");
                return Problem($"Something went wrong in the {nameof(GetS3LastValue)}", statusCode: 500);
            }
        }
        [HttpGet("s4last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS4LastValue()
        {
            try
            {
                var logs = await _uniqueRepository.Sensor4RealTime();
                var response = _mapper.Map<SensorUniqueDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS4LastValue)}");
                return Problem($"Something went wrong in the {nameof(GetS4LastValue)}", statusCode: 500);
            }
        }
        [HttpGet("s5last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetS5LastValue()
        {
            try
            {
                var logs = await _uniqueRepository.Sensor5RealTime();
                var response = _mapper.Map<SensorUniqueDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetS5LastValue)}");
                return Problem($"Something went wrong in the {nameof(GetS5LastValue)}", statusCode: 500);
            }
        }
        [HttpGet("pllast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlLastValue()
        {
            try
            {
                var logs = await _plRepository.SensorPlRealTime();
                var response = _mapper.Map<SensorPlDto>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetPlLastValue)}");
                return Problem($"Something went wrong in the {nameof(GetPlLastValue)}", statusCode: 500);
            }
        }
    }
}
