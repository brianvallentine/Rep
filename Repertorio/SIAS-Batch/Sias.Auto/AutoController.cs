
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Auto.Model;
using IA_ConverterCommons;
using static Code.AU9303B;
using Code;

namespace Sias.Auto
{
    [ApiController]
    [Route("Auto")]
    public class AutoController : ControllerBase
    {

        [HttpPost("AU9303B")]
        public IActionResult AU9303B(AU9303BModel AU9303BModel_P)
        {
            var program = new AU9303B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AU0025S")]
        public IActionResult AU0025S(AU0025SModel AU0025SModel_P)
        {
            var program = new AU0025S();
            var result = program.Execute(AU0025SModel_P.CSP_REGISTRO);
            return Ok(result);
        }

        [HttpPost("AU0032S")]
        public IActionResult AU0032S(AU0032SModel AU0032SModel_P)
        {
            var program = new AU0032S();
            var result = program.Execute(AU0032SModel_P.CSP_REGISTRO);
            return Ok(result);
        }

        [HttpPost("AU2055B")]
        public IActionResult AU2055B(AU2055BModel AU2055BModel_P)
        {
            var program = new AU2055B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
