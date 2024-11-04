using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectQLThueXe.Application.Authentication.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthenticationsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// Login web
        /// </summary>
        /// <param name="loginVM">phone number and password</param>
        /// <returns>Return token with status code 200</returns>
        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginVM loginVM)
        {
            try
            {
                if(loginVM != null)
                {
                    var _user = await _mediator.Send(new GetUserLoginQuery { PhoneNumber = loginVM.PhoneNumber, password = loginVM.Password });
                    if (_user != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new LoginDTO
                        {
                            Success = true,
                            Message = "Login successful",
                            AccessToken = GenerateToken(_user)
                        });
                    }
                }
                return StatusCode(StatusCodes.Status400BadRequest, new LoginDTO { Success = false, Message = "The phone number or password is incorrect." });
            }catch  (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
         
        /// <summary>
        /// Generate token JWT
        /// </summary>
        /// <param name="kt">car renter information</param>
        /// <returns>Return token</returns>
        private string GenerateToken(KT kt)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var serectkeyBytes = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]??"");
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Token_ID",Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Role,"Customer"),
                        new Claim(ClaimTypes.Name,kt.KT_Name),
                        new Claim(ClaimTypes.MobilePhone,kt.KT_Phone),
                        new Claim("KT_ID",kt.KT_ID.ToString()),
                        new Claim("KT_CCCD",kt.KT_CCCD),
                    }),
                    Expires = DateTime.UtcNow.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(serectkeyBytes),SecurityAlgorithms.HmacSha256Signature),
                };
                var _token = jwtTokenHandler.CreateToken(tokenDescription);
                return jwtTokenHandler.WriteToken(_token);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
