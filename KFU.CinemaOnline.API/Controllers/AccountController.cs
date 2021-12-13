using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Account;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KFU.CinemaOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IOptions<AuthOptions> authOptions, IAccountService accountService, IMapper mapper)
        {
            this._authOptions = authOptions;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _accountService.GetByUsernameAndPassword(request.Username, request.Password);

            if (user == null)
            {
                return BadRequest(ErrorResponse.GenerateError(HttpStatusCode.BadRequest, "Bad username or password"));
            }

            var token = GenerateJwt(_mapper.Map<Account>(user));
            return Ok(new { account = user, token = token });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var userExist = _accountService.GetByUsername(request.Username);
            if (userExist != null)
            {
                return BadRequest(ErrorResponse.GenerateError(HttpStatusCode.BadRequest,
                    $"User with username {request.Username} already exists"));
            }

            userExist = _accountService.GetByEmail(request.Email);
            if (userExist != null)
            {
                return BadRequest(ErrorResponse.GenerateError(HttpStatusCode.BadRequest,
                    $"User with email {request.Email} already exists"));
            }

            var newUser = _mapper.Map<Account>(await _accountService.AddNewUser(_mapper.Map<AccountEntity>(request)));

            if (newUser == null)
            {
                return BadRequest(ErrorResponse.GenerateError(HttpStatusCode.BadRequest, "bad request"));
            }
            var token = GenerateJwt(newUser);

            return Ok(new { account = newUser, access_token = token });
        }

        private string GenerateJwt(Account account)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("email", account.Email),
                new Claim("username", account.Username)
            };
            
            claims.AddRange(account.Roles.Select(role => new Claim("role", role.ToString())));

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
