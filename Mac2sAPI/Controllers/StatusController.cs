using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Dtos.Status;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;


        public StatusController(ILogger<StatusController> logger, IStatusRepository statusRepository,
            IMapper mapper, IEmailSender emailSender)
        {
            _logger = logger;
            _statusRepository = statusRepository;
            _mapper = mapper;
            _emailSender = emailSender;

        }

        [HttpGet("simple")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupedStatusByTimeRange(DateTime start, DateTime end)
        {
            try
            {
                var status = await _statusRepository.GetStatus();
                var response = _mapper.Map<IList<StatusSimpleDto>>(status);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}", statusCode: 500);
            }
        }
    }
}
