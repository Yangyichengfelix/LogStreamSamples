using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Dtos.Product;
using Mac2sAPI.MailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, IMapper mapper, IEmailSender emailSender)
        {
            _ProductRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPut("changephoto/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ChangeProductPhoto(int id, ProductPhotoUpdateDto productDto)
        {
            _logger.LogInformation($"Change product photo Attempt ");
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var product = await _ProductRepository.FindById(id);

            if (product == null)
            {
                return NotFound();
            }
            _mapper.Map(productDto, product);
            try
            {
                await _ProductRepository.Update(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(ChangeProductPhoto)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(ChangeProductPhoto)}" + ex.ToString());
                await _emailSender.SendEmailAsync(message);
                return Problem($"Something went wrong in the {nameof(ChangeProductPhoto)}", statusCode: 500);
            }
            return NoContent();
        }
    }
}
