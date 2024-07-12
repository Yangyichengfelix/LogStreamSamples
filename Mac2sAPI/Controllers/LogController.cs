using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.Log;
using Mac2sAPI.Dtos.LogDuration;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;    
        private readonly ILogRepository _logRepository;
        private readonly IGenerateLogRepository _GenerateLogRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public LogController(ILogger<LogController> logger, ILogRepository logRepository, IMapper mapper, IEmailSender emailSender, IGenerateLogRepository generateLog )
        {
            _GenerateLogRepository = generateLog;
            _logRepository = logRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }
   

        [HttpGet("timerange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindWithTimeRange(DateTime start, DateTime end)
        {
            _logger.LogInformation($"Finding {nameof(FindWithTimeRange)} from {start} to {end}");

            try
            {
                var logs = await _logRepository.FindWithTimeRange(start, end);
                var response = _mapper.Map<IList<LogDurationDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(FindWithTimeRange)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(FindWithTimeRange)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(FindWithTimeRange)}", statusCode: 500);
            }
        }
        [HttpGet("rawlogs/timerange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> WithTimeRange(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _GenerateLogRepository.FindWithTimeRange(start, end);
                var response = _mapper.Map<IList<LogDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(WithTimeRange)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(WithTimeRange)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(WithTimeRange)}", statusCode: 500);
            }
        }
        [HttpGet("NokAlert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> NokAlert(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _logRepository.GetNokAlert(start, end);
                var response = _mapper.Map<IList<Log>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(NokAlert)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(NokAlert)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(NokAlert)}", statusCode: 500);
            }
        }

        [HttpGet("SkewingAlert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SkewingAlert(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _logRepository.GetSkewingAlert(start, end);
                var response = _mapper.Map<IList<LogDurationDto>>(logs);
                return Ok(response);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(SkewingAlert)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(SkewingAlert)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(SkewingAlert)}", statusCode: 500);
            }
        }

        [HttpGet("cycletime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CycleTime()
        {
            try
            {
                var result = await _logRepository.GetCycleTime();
                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CycleTime)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(CycleTime)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(CycleTime)}", statusCode: 500);
            }
        }

        [HttpGet("noknumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NokNumber(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _logRepository.GetNokNumber(start, end);
                
                return Ok(logs);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(NokNumber)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(NokNumber)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(NokNumber)}", statusCode: 500);
            }
        }

        [HttpGet("objectifnumberprogress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObjectifProgress(DateTime start, DateTime end)
        {
            try
            {
                var result = await _logRepository.GetObjectifNumberProgress(start, end);

                return Ok(result);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(ObjectifProgress)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(ObjectifProgress)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(ObjectifProgress)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLog([FromBody] LogCreateDto logCreateDto)
        {
            try
            {
                _logger.LogInformation($"{nameof(CreateLog)}: Create Work Attempted");
                if (logCreateDto == null)
                {
                    _logger.LogWarning($"{nameof(CreateLog)}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{nameof(CreateLog)}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var lg = _mapper.Map<Log>(logCreateDto);
                var isSuccess = await _GenerateLogRepository.Create(lg);
                if (!isSuccess)
                {
                    return InternalError($"{nameof(CreateLog)}: Creation failed");
                }
                _logger.LogInformation($"{nameof(CreateLog)}: Creation was successful");
                return Created("Create", new { lg.Id });

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(CreateLog)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(CreateLog)}" + e.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(CreateLog)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("createlogs")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLogs([FromBody] List<LogCreateDto> logCreateDtos)
        {
            try
            {
                _logger.LogInformation($"{nameof(CreateLogs)}: Create Work Attempted");
                if (logCreateDtos == null)
                {
                    _logger.LogWarning($"{nameof(CreateLogs)}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{nameof(CreateLogs)}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var lg = _mapper.Map<List<Log>>(logCreateDtos);
                var isSuccess = await _GenerateLogRepository.CreateLogs(lg);
                if (!isSuccess)
                {
                    return InternalError($"{nameof(CreateLogs)}: Creation failed");
                }
                _logger.LogInformation($"{nameof(CreateLogs)}: Creation was successful");
                int number = lg.Count();
                return Created("Create", new { number }) ;

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(CreateLogs)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(CreateLogs)}" + e.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(CreateLogs)}", statusCode: 500);
            }
        }
        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}
