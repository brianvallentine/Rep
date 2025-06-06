
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.VidaEmpresarial.Model;
using IA_ConverterCommons;
using Code;

namespace Sias.VidaEmpresarial
{
    [ApiController]
    [Route("VidaEmpresarial")]
    public class VidaEmpresarialController : ControllerBase
    {

        [HttpPost("VE1111B")]
        public IActionResult VE1111B(VE1111BModel VE1111BModel_P)
        {
            var program = new VE1111B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE2640B")]
        public IActionResult VE2640B(VE2640BModel VE2640BModel_P)
        {
            var program = new VE2640B();
            var result = program.Execute(VE2640BModel_P.ARQVDGLB, VE2640BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("VE0029B")]
        public IActionResult VE0029B(VE0029BModel VE0029BModel_P)
        {
            var program = new VE0029B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0030B")]
        public IActionResult VE0030B(VE0030BModel VE0030BModel_P)
        {
            var program = new VE0030B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0031B")]
        public IActionResult VE0031B(VE0031BModel VE0031BModel_P)
        {
            var program = new VE0031B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0032B")]
        public IActionResult VE0032B(VE0032BModel VE0032BModel_P)
        {
            var program = new VE0032B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0123B")]
        public IActionResult VE0123B(VE0123BModel VE0123BModel_P)
        {
            var program = new VE0123B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0125B")]
        public IActionResult VE0125B(VE0125BModel VE0125BModel_P)
        {
            var program = new VE0125B();
            var result = program.Execute(VE0125BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("VE0130B")]
        public IActionResult VE0130B(VE0130BModel VE0130BModel_P)
        {
            var program = new VE0130B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VE0414B")]
        public IActionResult VE0414B(VE0414BModel VE0414BModel_P)
        {
            var program = new VE0414B();
            var result = program.Execute(VE0414BModel_P.VE0414B1, VE0414BModel_P.VE0414BI, VE0414BModel_P.VE0414BP, VE0414BModel_P.VE0414BH, VE0414BModel_P.SORTWK01, VE0414BModel_P.VE0414B2);
            return Ok(result);
        }

        [HttpPost("VE0505B")]
        public IActionResult VE0505B(VE0505BModel VE0505BModel_P)
        {
            var program = new VE0505B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
