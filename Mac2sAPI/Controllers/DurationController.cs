using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Dtos.StatusDuration;
using Mac2sAPI.Dtos.StatusGroupDuration;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurationController : ControllerBase
    {
        private readonly ILogger<DurationController> _logger;
        private readonly IStatusDurationRepository _statusDurationRepository;
        private readonly IStatusGroupDurationRepository _statusGroupDurationRepository;
        private readonly IEmailSender _emailSender;

        private readonly IMapper _mapper;
        public DurationController(ILogger<DurationController> logger, 
            IStatusDurationRepository statusDurationRepository, 
            IStatusGroupDurationRepository statusGroupDurationRepository,
            IMapper mapper, IEmailSender emailSender)
        {
            _statusDurationRepository = statusDurationRepository;
            _statusGroupDurationRepository = statusGroupDurationRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }
        [HttpGet("statusDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusDurations(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            try
            {              
                var logs = await _statusDurationRepository.GetStatusDurations( scheduleStart,  scheduleEnd, start, end);
                var response = _mapper.Map<IList<StatusDurationDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetStatusDurations)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetStatusDurations)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetStatusDurations)}", statusCode: 500);
            }
        }
        [HttpGet("statusGroupDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusGroupDurations(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            try
            {
                var logs = await _statusGroupDurationRepository.GetStatusGroupDuration(scheduleStart, scheduleEnd, start, end);
                var response = _mapper.Map<IList<StatusGroupDurationDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetStatusGroupDurations)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetStatusGroupDurations)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetStatusGroupDurations)}", statusCode: 500);
            }
        }

        [HttpGet("trs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTRS(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            try
            {
                var result = await _statusDurationRepository.GetTRS(scheduleStart, scheduleEnd,start, end);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetTRS)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetTRS)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetTRS)}", statusCode: 500);
            }
        }
        [HttpGet("trg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTRG(TimeSpan scheduleStart, TimeSpan scheduleEnd, DateTime start, DateTime end)
        {
            try
            {
                var result = await _statusDurationRepository.GetTRG(scheduleStart, scheduleEnd,start, end);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetTRG)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetTRG)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetTRG)}", statusCode: 500);
            }
        }

    }
}
