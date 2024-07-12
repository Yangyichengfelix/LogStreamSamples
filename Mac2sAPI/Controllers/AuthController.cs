using AutoMapper;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.ApiUser;
using Mac2sAPI.MailHelper;
using Mac2sAPI.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mac2sAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IMapper mapper;
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration, IEmailSender emailSender)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
            this.emailSender = emailSender;
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            logger.LogInformation($"Registration Attempt for {userDto.UserName} ");
            try
            {
                var user = mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.UserName;
                user.Email = userDto.UserName;
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, "Monitor");
                return Accepted();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(Register)}" + ex.ToString());
                await emailSender.SendEmailAsync(message);
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthResponse>> Login(UserLoginDto userDto)
        {
            logger.LogInformation($"Login Attempt for {userDto.UserName} with {userDto.Password} ");
            try
            {
                var user = await userManager.FindByEmailAsync(userDto.UserName);
                var passwordValid = await userManager.CheckPasswordAsync(user, userDto.Password);
                if (user == null || passwordValid == false)
                {
                    logger.LogInformation($"Login Attempt for {userDto.UserName} with {userDto.Password} failed");
                    return Unauthorized(userDto);
                }
                string tokenString = await GenerateToken(user);
                var response = new AuthResponse
                {
                    UserName = userDto.UserName,
                    Token = tokenString,
                    UserId = user.Id,
                };
                logger.LogInformation($"Token sent to {userDto.UserName}");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(Login)}" + ex.ToString());
                await emailSender.SendEmailAsync(message);
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("resetpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ResetPassword(UserResetPasswordDto userResetPasswordDto)
        {
            logger.LogInformation($"Logged user password reset process Attempt for {userResetPasswordDto.UserName} ");
            try
            {
                var user = await userManager.FindByEmailAsync(userResetPasswordDto.UserName);
                var passwordValid = await userManager.CheckPasswordAsync(user, userResetPasswordDto.Password);
                if (user == null || passwordValid == false)
                {
                    return Unauthorized(userResetPasswordDto);
                }
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var resetPassResult = await userManager.ResetPasswordAsync(user, token, userResetPasswordDto.NewPassword);
                if (!resetPassResult.Succeeded)
                {
                    return Unauthorized(userResetPasswordDto);
                }
                return Ok($"New password for { user.UserName } has been reset");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(ResetPassword)}");
                var message = new Message(new string[] { "yicheng.yang@ermo-tech.com", "ermo.automation@ermo-tech.com" }, "API Exception ", $"Something went wrong in the {nameof(ResetPassword)}" + ex.ToString());
                await emailSender.SendEmailAsync(message);
                return Problem($"Something Went Wrong in the {nameof(ResetPassword)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("forgotpassword")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ForgotPassword(UserNameDto userNameDto)
        {
            logger.LogInformation($"Forgot password reset process Attempt for {userNameDto.UserName} ");
            try
            {
                var user = await userManager.FindByEmailAsync(userNameDto.UserName);
                if (user == null)
                {
                    return BadRequest(userNameDto);
                }
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var message = new Message(new string[] { user.Email }, "Your token to reset password", token);
                logger.LogInformation($"Email with reset password token sent to {userNameDto.UserName} ");
                //var message = new Message(new string[] {"felix.yang.yicheng@gmail.com" }, "Your token to reset password",$"Please paste this token to the 'reset forgotten password' page : {token} " );
                await emailSender.SendEmailAsync(message);
                return Ok($"Email with reset password token sent to { user.UserName }");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(ForgotPassword)}");
                return Problem($"Something Went Wrong in the {nameof(ForgotPassword)}", statusCode: 500);
            }
        }
        [HttpPost]
        [Route("resetforgottenpassword")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ResetForgottenPassword(UserResetForgottenPasswordDto userResetForgottenPasswordDto)
        {
            logger.LogInformation($"Forgot password reset process Attempt for {userResetForgottenPasswordDto.UserName} ");
            try
            {
                var user = await userManager.FindByEmailAsync(userResetForgottenPasswordDto.UserName);
                if (user == null || userResetForgottenPasswordDto.Token == null)
                {
                    return BadRequest(userResetForgottenPasswordDto);
                }
                else if (userResetForgottenPasswordDto.Password != userResetForgottenPasswordDto.PasswordConfirm)
                {
                    return Conflict($"New password does not match with the password confirm");
                }

                var resetPassResult = await userManager.ResetPasswordAsync(user, userResetForgottenPasswordDto.Token, userResetForgottenPasswordDto.Password);
                if (!resetPassResult.Succeeded)
                {
                    return Unauthorized(userResetForgottenPasswordDto);
                }
                return Ok($"New password for { user.UserName } has been reset");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(ResetForgottenPassword)}");
                return Problem($"Something Went Wrong in the {nameof(ResetForgottenPassword)}", statusCode: 500);
            }
        }
        private async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var userClaims = await userManager.GetClaimsAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToInt32(configuration["JwtSettings:Duration"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
