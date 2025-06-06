
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Loterico.Model;
using IA_ConverterCommons;
using static Code.LT3150S;
using Code;

namespace Sias.Loterico
{
    [ApiController]
    [Route("Loterico")]
    public class LotericoController : ControllerBase
    {

        [HttpPost("LT3150S")]
        public IActionResult LT3150S(LT3150SModel LT3150SModel_P)
        {
            var program = new LT3150S();
            var result = program.Execute(LT3150SModel_P.LT3150_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3151S")]
        public IActionResult LT3151S(LT3151SModel LT3151SModel_P)
        {
            var program = new LT3151S();
            var result = program.Execute(LT3151SModel_P.LT3151_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3159S")]
        public IActionResult LT3159S(LT3159SModel LT3159SModel_P)
        {
            var program = new LT3159S();
            var result = program.Execute(LT3159SModel_P.LT3159S_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3164S")]
        public IActionResult LT3164S(LT3164SModel LT3164SModel_P)
        {
            var program = new LT3164S();
            var result = program.Execute(LT3164SModel_P.LT3164S_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3171S")]
        public IActionResult LT3171S(LT3171SModel LT3171SModel_P)
        {
            var program = new LT3171S();
            var result = program.Execute(LT3171SModel_P.LT3171_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3214S")]
        public IActionResult LT3214S(LT3214SModel LT3214SModel_P)
        {
            var program = new LT3214S();
            var result = program.Execute(LT3214SModel_P.LT3214_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3250S")]
        public IActionResult LT3250S(LT3250SModel LT3250SModel_P)
        {
            var program = new LT3250S();
            var result = program.Execute(LT3250SModel_P.LT3250_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT2036B")]
        public IActionResult LT2036B(LT2036BModel LT2036BModel_P)
        {
            var program = new LT2036B();
            var result = program.Execute(LT2036BModel_P.MOV2036B, LT2036BModel_P.RLT2036B, LT2036BModel_P.ARQSORT);
            return Ok(result);
        }

        [HttpPost("LT2118S")]
        public IActionResult LT2118S(LT2118SModel LT2118SModel_P)
        {
            var program = new LT2118S();
            var result = program.Execute(LT2118SModel_P.LT2118S_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("LT3117S")]
        public IActionResult LT3117S(LT3117SModel LT3117SModel_P)
        {
            var program = new LT3117S();
            var result = program.Execute(LT3117SModel_P.LBLT3117);
            return Ok(result);
        }

        [HttpPost("LT3142S")]
        public IActionResult LT3142S(LT3142SModel LT3142SModel_P)
        {
            var program = new LT3142S();
            var result = program.Execute(LT3142SModel_P.LT3142_AREA_PARAMETROS);
            return Ok(result);
        }

    }
}
