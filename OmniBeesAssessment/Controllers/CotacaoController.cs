using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniBeesAssessment.Model;
using OmniBeesAssessment.Services;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;

namespace OmniBeesAssessment.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController(IAuthService authService) : ControllerBase
{
    private int ValidateAuthorization()
    {
        int parceiroId = 0;

        if (!string.IsNullOrEmpty(Request.Headers["Secret"]))
        {
            parceiroId = Data.Validator.ValidateSecret(Request.Headers["Secret"].ToString());
        }
        else if (!string.IsNullOrEmpty(Request.Headers["Authorization"]))
        {
            var tokenString = Request.Headers["Authorization"].ToString();
            var jwtEncodedString = tokenString.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString);
            foreach (var item in token.Claims)
            {
                if (item.Type.EndsWith("nameidentifier")) parceiroId = int.Parse(item.Value);
            }
        }

        return parceiroId;
    }

    [Authorize]
    [Route("Listar")]
    [HttpPost]
    public IActionResult Listar(ListarCotacao cotacao)
    {
        int parceiroId = ValidateAuthorization();

        if (parceiroId > 0)
        {
            if (ModelState.IsValid)
            {
                cotacao.IdParceiro = parceiroId;
                var lista = Data.Validator.ListData(cotacao);
                return Ok(lista);
            }
            else
                return BadRequest();
        }
        else
        {
            return NotFound("Secret not found");
        }
    }

    [Authorize]
    [Route("Incluir")]
    [HttpPost]
    public IActionResult Incluir(Cotacao cotacao)
    {
        int parceiroId = ValidateAuthorization();

        if (parceiroId > 0)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string messageRet = Data.Validator.ValidateAllRules(cotacao);

                    if (!string.IsNullOrEmpty(messageRet)) return BadRequest(messageRet);

                    cotacao.IdParceiro = parceiroId;

                    int ret = Data.Validator.InsertCotacao(cotacao);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }                
            }
            else
                return BadRequest();
        }
        else
        {
            return NotFound("Parceiro nao encontrado");
        }
    }

    [Authorize]
    [Route("Atualizar")]
    [HttpPut]
    public IActionResult Atualizar(Cotacao cotacao)
    {
        int parceiroId = ValidateAuthorization();

        if (parceiroId > 0)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string messageRet = Data.Validator.ValidateAllRules(cotacao);

                    if (!string.IsNullOrEmpty(messageRet)) return BadRequest(messageRet);

                    cotacao.IdParceiro = parceiroId;

                    int ret = Data.Validator.UpdateCotacao(cotacao);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest();
        }
        else
        {
            return NotFound("Parceiro nao encontrado");
        }
    }

    [Authorize]
    [Route("Excluir")]
    [HttpDelete]
    public IActionResult Excluir(CotacaoDel cotacao)
    {
        int parceiroId = ValidateAuthorization();

        if (parceiroId > 0)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int messageRet = Data.Validator.ValidateDel(cotacao);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest();
        }
        else
        {
            return NotFound("Parceiro nao encontrado");
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
    {
        var result = await authService.LoginAsync(request);
        if (result is null)
            return BadRequest("Invalid username or password.");

        return Ok(result);
    }
}
