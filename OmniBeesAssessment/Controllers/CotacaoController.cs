using Microsoft.AspNetCore.Mvc;
using OmniBeesAssessment.Model;

namespace OmniBeesAssessment.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController : ControllerBase
{
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
}
