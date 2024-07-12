using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.Gauge;
using Mac2sAPI.Dtos.Schedule;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleParameterRepository _schedule;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public ScheduleController(ILogger<ScheduleController> logger, IScheduleParameterRepository schedule, IMapper mapper, IEmailSender emailSender)
        {
            _schedule = schedule;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllScheduleParameter()
        {
            try
            {
                var result = await _schedule.GetAllScheduleParameter();
                var response = _mapper.Map<IList<ScheduleParameterDto>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllScheduleParameter)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetAllScheduleParameter)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetAllScheduleParameter)}", statusCode: 500);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetScheduleParameterByIdAsync(int id)
        {
            try
            {
                var result = await _schedule.FindById(id);
                var response = _mapper.Map<ScheduleParameterDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetScheduleParameterByIdAsync)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetScheduleParameterByIdAsync)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetScheduleParameterByIdAsync)}", statusCode: 500);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateScheduleParameterAsync(int id, [FromBody] ScheduleParameterUpdateDto ParameterDto)
        {
            try
            {
                if (id < 1 || ParameterDto == null || id != ParameterDto.Id)
                {
                    _logger.LogError($"{nameof(UpdateScheduleParameterAsync)}: Update failed with bad data - id: {id}");
                    return BadRequest($"{nameof(UpdateScheduleParameterAsync)}: Update failed with bad data - id: {id}");
                }

                var isExists = await _schedule.isExists(id);
                if (!isExists)
                {
                    _logger.LogError($"{nameof(UpdateScheduleParameterAsync)}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{nameof(UpdateScheduleParameterAsync)}: Data was Incomplete");
                    return BadRequest($"{nameof(UpdateScheduleParameterAsync)}: Data was Incomplete");
                }
                var scheduleParameter = _mapper.Map<ScheduleParameter>(ParameterDto);
                var timeValidation = await _schedule.CheckTimeValidation(scheduleParameter);
                if (!timeValidation)
                {
                    _logger.LogError($"{nameof(UpdateScheduleParameterAsync)}: Schecule was invalide");
                    return BadRequest($"{nameof(UpdateScheduleParameterAsync)}: Schecule was invalide");
                }
                var isSuccess = await _schedule.Update(scheduleParameter);

                _logger.LogInformation($"{nameof(UpdateScheduleParameterAsync)}: Record with id: {id} successfully updated");
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateScheduleParameterAsync)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(UpdateScheduleParameterAsync)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(UpdateScheduleParameterAsync)}", statusCode: 500);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateScheduleParameter([FromBody] ScheduleParameterCreateDto parameterCreateDto)
        {
            try
            {
                _logger.LogInformation($"{nameof(UpdateScheduleParameterAsync)}: Create Schedule Attempted");
                if (parameterCreateDto == null)
                {
                    _logger.LogWarning($"{nameof(UpdateScheduleParameterAsync)}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{nameof(UpdateScheduleParameterAsync)}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var schedule = _mapper.Map<ScheduleParameter>(parameterCreateDto);
                var isSuccess = await _schedule.Create(schedule);
                if (!isSuccess)
                {
                    return InternalError($"{nameof(UpdateScheduleParameterAsync)}: Creation failed");
                }
                _logger.LogInformation($"{nameof(UpdateScheduleParameterAsync)}: Creation was successful");
                return Created("Create", new { schedule });

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(CreateScheduleParameter)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(CreateScheduleParameter)}" + e.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(CreateScheduleParameter)}", statusCode: 500);
            }
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                _logger.LogInformation($"{nameof(CreateScheduleParameter)}: Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarning($"{nameof(CreateScheduleParameter)}: Delete failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isOnlyLeft = await _schedule.isOnlyOneLeft();
                if (isOnlyLeft)
                {
                    _logger.LogWarning($"{nameof(CreateScheduleParameter)}: Failed to retrieve record with id: {id}, it's the only one left");
                    return BadRequest();
                }
                var isExists = await _schedule.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{nameof(CreateScheduleParameter)}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var schedule = await _schedule.FindById(id);
                var isSuccess = await _schedule.Delete(schedule);
                if (!isSuccess)
                {
                    return InternalError($"{nameof(CreateScheduleParameter)}: Delete failed for record with id: {id}");
                }
                _logger.LogInformation($"{nameof(CreateScheduleParameter)}: Record with id: {id} successfully deleted");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{nameof(CreateScheduleParameter)}: {e.Message} - {e.InnerException}");
            }
        }
        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}
