using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniBeesAssessment.Model;
using OmniBeesAssessment.Services;
using System.IdentityModel.Tokens.Jwt;

namespace OmniBeesAssessment.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController(IAuthService authService) : ControllerBase
{
    [Authorize]
    [Route("Listar")]
    [HttpPost]
    public IActionResult Listar(ListarCotacao cotacao)
    {
        string secret;
        if (string.IsNullOrEmpty(Request.Headers["Secret"]))
        {
            return NotFound("Secret empty");
        }
        else
        {
            secret = Request.Headers["Secret"].ToString();
            var tokenString = Request.Headers["Authorization"].ToString();
            var jwtEncodedString = tokenString.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString);
            foreach (var item in token.Claims)
            {
                Console.WriteLine(item.Type + "\\" + item.Value);
            }
            

            var parceiroId = Data.Validator.ValidateSecret(secret);
            if (parceiroId > 0)
            {
                if (ModelState.IsValid)
                {
                    DateTime nascimento = new DateTime(1983, 01, 24);
                    var timeSpan = DateTime.Now - nascimento;
                    int age = new DateTime(timeSpan.Ticks).Year - 1;
                    var agravo = Data.Validator.Agravo(age);
                }
                else
                    return BadRequest();
            }
            else
            {
                return NotFound("Secret not found");
            }
        }

        return Ok();
    }

    [Route("Incluir")]
    [HttpPost]
    public IActionResult Incluir(Cotacao cotacao)
    {
        string secret;
        if (string.IsNullOrEmpty(Request.Headers["Secret"]))
        {
            return NotFound("Secret empty");
        }
        else
        {
            secret = Request.Headers["Secret"].ToString();
            var parceiroId = Data.Validator.ValidateSecret(secret);

            if (parceiroId > 0)
            {
                if (ModelState.IsValid)
                {
                    DateTime nascimento = new DateTime(1983, 01, 26);

                    var timeSpan = DateTime.Now - nascimento;
                    int age = new DateTime(timeSpan.Ticks).Year - 1;

                    var agravo = Data.Validator.Agravo(age);
                }
                else
                    return BadRequest();
            }
            else
            {
                return NotFound("Secret not found");
            }
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
    {
        var result = await authService.LoginAsync(request);
        if (result is null)
            return BadRequest("Invalid username or password.");

        return Ok(result);
    }
}
