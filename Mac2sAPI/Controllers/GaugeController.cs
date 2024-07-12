using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.Gauge;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GaugeController : ControllerBase
    {
        private readonly ILogger<GaugeController> _logger;
        private readonly IGaugeParameterRepository _gauge;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public GaugeController(ILogger<GaugeController> logger, IGaugeParameterRepository gauge, IMapper mapper, IEmailSender emailSender)
        {
            _gauge = gauge;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetGaugeParameter()
        {
            try
            {
                var result = await _gauge.GetAllGaugeParameter();
                var response = _mapper.Map<IList<GaugeParameterDto>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetGaugeParameter)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetGaugeParameter)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetGaugeParameter)}", statusCode: 500);
            }

        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetGaugeParameterByIdAsync(int id)
        {
            try
            {
                var result = await _gauge.FindById(id);
                var response = _mapper.Map<GaugeParameterDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetGaugeParameterByIdAsync)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetGaugeParameterByIdAsync)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetGaugeParameterByIdAsync)}", statusCode: 500);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGaugeParameterAsync(int id, [FromBody] GaugeParameterDto gaugeParameterDto)
        {
            try
            {
                if (id < 1 || gaugeParameterDto == null || id != gaugeParameterDto.Id)
                {
                    _logger.LogError($"{nameof(UpdateGaugeParameterAsync)}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _gauge.isExists(id);
                if (!isExists)
                {
                    _logger.LogError($"{nameof(UpdateGaugeParameterAsync)}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{nameof(UpdateGaugeParameterAsync)}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var gaugeParameter = _mapper.Map<GaugeParameter>(gaugeParameterDto);
                var isSuccess = await _gauge.Update(gaugeParameter);

                _logger.LogInformation($"{nameof(UpdateGaugeParameterAsync)}: Record with id: {id} successfully updated");
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateGaugeParameterAsync)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(UpdateGaugeParameterAsync)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(UpdateGaugeParameterAsync)}", statusCode: 500);
            }
        }
    }
}
