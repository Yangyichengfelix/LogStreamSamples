using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Dtos.ActivityReport;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityReportController : ControllerBase
    {

        private readonly ILogger<ActivityReportController> _logger;
        private readonly IActivityReportRepository _activityReportRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ActivityReportController(ILogger<ActivityReportController> logger, IActivityReportRepository activityReportRepository, IMapper mapper, IEmailSender emailSender)
        {
            _activityReportRepository = activityReportRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender=emailSender;
        }
        // GET: api/<ActivityReportController>
        [HttpGet("timerange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupedStatusByTimeRange(DateTime start, DateTime end)
        {
            try
            {
                var logs = await _activityReportRepository.GetActivityReport(start, end);
                var response = _mapper.Map<IList<ActivityReportDto>>(logs);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}"+ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetGroupedStatusByTimeRange)}", statusCode: 500);
            }
        }
    }
}
