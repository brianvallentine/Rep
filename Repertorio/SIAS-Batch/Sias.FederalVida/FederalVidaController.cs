
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.FederalVida.Model;
using IA_ConverterCommons;
using static Code.VF0118B;
using Code;

namespace Sias.FederalVida
{
    [ApiController]
    [Route("FederalVida")]
    public class FederalVidaController : ControllerBase
    {

        [HttpPost("VF0118B")]
        public IActionResult VF0118B(VF0118BModel VF0118BModel_P)
        {
            var program = new VF0118B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VF0340B")]
        public IActionResult VF0340B(VF0340BModel VF0340BModel_P)
        {
            var program = new VF0340B();
            var result = program.Execute(VF0340BModel_P.MVDB6131);
            return Ok(result);
        }

        [HttpPost("VF0341B")]
        public IActionResult VF0341B(VF0341BModel VF0341BModel_P)
        {
            var program = new VF0341B();
            var result = program.Execute(VF0341BModel_P.MVDB6131);
            return Ok(result);
        }

        [HttpPost("VF0402B")]
        public IActionResult VF0402B(VF0402BModel VF0402BModel_P)
        {
            var program = new VF0402B();
            var result = program.Execute(VF0402BModel_P.PRINTER, VF0402BModel_P.SVF0402B);
            return Ok(result);
        }

        [HttpPost("VF0403B")]
        public IActionResult VF0403B(VF0403BModel VF0403BModel_P)
        {
            var program = new VF0403B();
            var result = program.Execute(VF0403BModel_P.PRINTER, VF0403BModel_P.SVF0403B);
            return Ok(result);
        }

        [HttpPost("VF0408B")]
        public IActionResult VF0408B(VF0408BModel VF0408BModel_P)
        {
            var program = new VF0408B();
            var result = program.Execute(VF0408BModel_P.PRINTER, VF0408BModel_P.SVF0408B);
            return Ok(result);
        }

        [HttpPost("VF0813B")]
        public IActionResult VF0813B(VF0813BModel VF0813BModel_P)
        {
            var program = new VF0813B();
            var result = program.Execute(VF0813BModel_P.RETDEB, VF0813BModel_P.RETERR);
            return Ok(result);
        }

        [HttpPost("VF0851B")]
        public IActionResult VF0851B(VF0851BModel VF0851BModel_P)
        {
            var program = new VF0851B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VF0853B")]
        public IActionResult VF0853B(VF0853BModel VF0853BModel_P)
        {
            var program = new VF0853B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
