using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.Image;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IImageRepository _imageReportRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ImageController(ILogger<ImageController> logger, IImageRepository imageReportRepository, IMapper mapper, IEmailSender emailSender)
        {
            _imageReportRepository = imageReportRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UploadImage([FromBody] ImageCreateDto imageDto)
        {
            _logger.LogInformation($"Upload image Attempt ");
            try
            {
                var img = _mapper.Map<Image>(imageDto);
                var result = await _imageReportRepository.Create(img);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UploadImage)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(UploadImage)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something Went Wrong in the {nameof(UploadImage)}", statusCode: 500);
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetImageById(int id)
        {
            _logger.LogInformation($"Get Image By Id Attempt ");
            try
            {
                var result = await _imageReportRepository.FindById(id);
                var response = _mapper.Map<ImageDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetImageById)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetImageById)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetImageById)}", statusCode: 500);
            }
        }
        [HttpGet("last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetLastImage()
        {
            _logger.LogInformation($"Get Last Image Attempt ");
            try
            {
                var result = await _imageReportRepository.LastImage();
                var response = _mapper.Map<ImageDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetLastImage)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetLastImage)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetLastImage)}", statusCode: 500);
            }
        }
        [HttpGet("bylogid/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetImageByLogId(int id)
        {
            _logger.LogInformation($"Get Image By Log Id Attempt ");
            try
            {
                var result = await _imageReportRepository.FindImageByLogId(id);
                var response = _mapper.Map<ImageDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetImageByLogId)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetImageByLogId)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetImageByLogId)}", statusCode: 500);
            }
        }

        [HttpGet("lastlog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetImageByLastLog()
        {
            _logger.LogInformation($"Get Image By Last Log Attempt ");
            try
            {
                var result = await _imageReportRepository.FindImageByLastLog();
                var response = _mapper.Map<ImageDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetImageByLastLog)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetImageByLastLog)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(GetImageByLastLog)}", statusCode: 500);
            }
        }
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<IActionResult> GetImageByName(string name)
        //{
        //    try
        //    {
        //        var result = await _imageReportRepository.(id);
        //        var response = _mapper.Map<ImageDto>(result);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something went wrong in the {nameof(GetImageById)}");
        //        var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(GetImageById)}" + ex.ToString());
        //        await _emailSender.SendEmailAsync(message);
        //        return Problem($"Something went wrong in the {nameof(GetImageById)}", statusCode: 500);
        //    }

        //}
    }
}
