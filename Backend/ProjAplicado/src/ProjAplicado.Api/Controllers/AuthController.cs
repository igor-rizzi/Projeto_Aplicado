using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Api.Extensions;
using ProjAplicado.Business.Intefaces.Notification;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProjAplicado.Api.Controllers
{
    [Route("api")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettingsJWT _appSettingsJWT;

        public AuthController(SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager,
                              INotificador notificador,
                              IOptions<AppSettingsJWT> appSettingsJwt) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettingsJWT = appSettingsJwt.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUserDto.Email,
                Email = registerUserDto.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }
            foreach(var error in result.Errors)
            {
                NotificarErro(error.Description);
            }
            
            return CustomResponse(registerUserDto);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Email, loginUserDto.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(loginUserDto.Email));
            }

            if (result.IsLockedOut)
            {
                return CustomResponse("Usuário temporariamente bloqueado por tentativas inválidas");
            }

            return CustomResponse("Usuário ou senha incorretos");
        }

        private async Task<string> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettingsJWT.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettingsJWT.Emissor,
                Audience = _appSettingsJWT.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettingsJWT.ExpiracaoHora),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
