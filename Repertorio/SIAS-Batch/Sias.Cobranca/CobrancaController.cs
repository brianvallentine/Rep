
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Cobranca.Model;
using IA_ConverterCommons;
using static Code.CB0003B;
using Code;

namespace Sias.Cobranca
{
    [ApiController]
    [Route("Cobranca")]
    public class CobrancaController : ControllerBase
    {

        [HttpPost("CB0003B")]
        public IActionResult CB0003B(CB0003BModel CB0003BModel_P)
        {
            var program = new CB0003B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB0005B")]
        public IActionResult CB0005B(CB0005BModel CB0005BModel_P)
        {
            var program = new CB0005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB0123B")]
        public IActionResult CB0123B(CB0123BModel CB0123BModel_P)
        {
            var program = new CB0123B();
            var result = program.Execute(CB0123BModel_P.CCADESAO);
            return Ok(result);
        }

        [HttpPost("CB0009B")]
        public IActionResult CB0009B(CB0009BModel CB0009BModel_P)
        {
            var program = new CB0009B();
            var result = program.Execute(CB0009BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("CB0055B")]
        public IActionResult CB0055B(CB0055BModel CB0055BModel_P)
        {
            var program = new CB0055B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB0065B")]
        public IActionResult CB0065B(CB0065BModel CB0065BModel_P)
        {
            var program = new CB0065B();
            var result = program.Execute(CB0065BModel_P.MV605100, CB0065BModel_P.MV600139, CB0065BModel_P.MV600140, CB0065BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("CB0124B")]
        public IActionResult CB0124B(CB0124BModel CB0124BModel_P)
        {
            var program = new CB0124B();
            var result = program.Execute(CB0124BModel_P.CCDEMAIS);
            return Ok(result);
        }

        [HttpPost("CB0139B")]
        public IActionResult CB0139B(CB0139BModel CB0139BModel_P)
        {
            var program = new CB0139B();
            var result = program.Execute(CB0139BModel_P.ARQSORT, CB0139BModel_P.ARQCE1);
            return Ok(result);
        }

        [HttpPost("CB0110B")]
        public IActionResult CB0110B(CB0110BModel CB0110BModel_P)
        {
            var program = new CB0110B();
            var result = program.Execute(CB0110BModel_P.CB0110S1);
            return Ok(result);
        }

        [HttpPost("CB0111B")]
        public IActionResult CB0111B(CB0111BModel CB0111BModel_P)
        {
            var program = new CB0111B();
            var result = program.Execute(CB0111BModel_P.MVDBCARD, CB0111BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("CB0155B")]
        public IActionResult CB0155B(CB0155BModel CB0155BModel_P)
        {
            var program = new CB0155B();
            var result = program.Execute(CB0155BModel_P.SORTWK01, CB0155BModel_P.ARQSAI1, CB0155BModel_P.ARQSAI2, CB0155BModel_P.ARQSAI3);
            return Ok(result);
        }

        [HttpPost("CB0999B")]
        public IActionResult CB0999B(CB0999BModel CB0999BModel_P)
        {
            var program = new CB0999B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB1000B")]
        public IActionResult CB1000B(CB1000BModel CB1000BModel_P)
        {
            var program = new CB1000B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB0112B")]
        public IActionResult CB0112B(CB0112BModel CB0112BModel_P)
        {
            var program = new CB0112B();
            var result = program.Execute(CB0112BModel_P.MVDBCARD, CB0112BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("CB1262B")]
        public IActionResult CB1262B(CB1262BModel CB1262BModel_P)
        {
            var program = new CB1262B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB1264B")]
        public IActionResult CB1264B(CB1264BModel CB1264BModel_P)
        {
            var program = new CB1264B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB1127B")]
        public IActionResult CB1127B(CB1127BModel CB1127BModel_P)
        {
            var program = new CB1127B();
            var result = program.Execute(CB1127BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("CB1280B")]
        public IActionResult CB1280B(CB1280BModel CB1280BModel_P)
        {
            var program = new CB1280B();
            var result = program.Execute(CB1280BModel_P.CB1280S1, CB1280BModel_P.CB1280S2, CB1280BModel_P.CB1280S3);
            return Ok(result);
        }

        [HttpPost("CB1260B")]
        public IActionResult CB1260B(CB1260BModel CB1260BModel_P)
        {
            var program = new CB1260B();
            var result = program.Execute(CB1260BModel_P.CB1260B1);
            return Ok(result);
        }

        [HttpPost("CB7537B")]
        public IActionResult CB7537B(CB7537BModel CB7537BModel_P)
        {
            var program = new CB7537B();
            var result = program.Execute(CB7537BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("CB2005B")]
        public IActionResult CB2005B(CB2005BModel CB2005BModel_P)
        {
            var program = new CB2005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("CB6241B")]
        public IActionResult CB6241B(CB6241BModel CB6241BModel_P)
        {
            var program = new CB6241B();
            var result = program.Execute(CB6241BModel_P.MV911241);
            return Ok(result);
        }

        [HttpPost("CB6248B")]
        public IActionResult CB6248B(CB6248BModel CB6248BModel_P)
        {
            var program = new CB6248B();
            var result = program.Execute(CB6248BModel_P.MV911334);
            return Ok(result);
        }

        [HttpPost("CB6249B")]
        public IActionResult CB6249B(CB6249BModel CB6249BModel_P)
        {
            var program = new CB6249B();
            var result = program.Execute(CB6249BModel_P.MV912014);
            return Ok(result);
        }

        [HttpPost("CB6259B")]
        public IActionResult CB6259B(CB6259BModel CB6259BModel_P)
        {
            var program = new CB6259B();
            var result = program.Execute(CB6259BModel_P.SORTWK01);
            return Ok(result);
        }

    }
}
