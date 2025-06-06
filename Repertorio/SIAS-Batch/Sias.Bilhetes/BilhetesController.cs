
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Bilhetes.Model;
using IA_ConverterCommons;
using static Code.BI0003S;
using Code;

namespace Sias.Bilhetes
{
    [ApiController]
    [Route("Bilhetes")]
    public class BilhetesController : ControllerBase
    {

        [HttpPost("BI0003S")]
        public IActionResult BI0003S(BI0003SModel BI0003SModel_P)
        {
            var program = new BI0003S();
            var result = program.Execute(BI0003SModel_P.BI0003L_LINKAGE);
            return Ok(result);
        }

        [HttpPost("BI0004S")]
        public IActionResult BI0004S(BI0004SModel BI0004SModel_P)
        {
            var program = new BI0004S();
            var result = program.Execute(BI0004SModel_P.BI0004L_LINKAGE);
            return Ok(result);
        }

        [HttpPost("BI0005B")]
        public IActionResult BI0005B(BI0005BModel BI0005BModel_P)
        {
            var program = new BI0005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0005S")]
        public IActionResult BI0005S(BI0005SModel BI0005SModel_P)
        {
            var program = new BI0005S();
            var result = program.Execute(BI0005SModel_P.BI0005L_LINKAGE);
            return Ok(result);
        }

        [HttpPost("BI0027B")]
        public IActionResult BI0027B(BI0027BModel BI0027BModel_P)
        {
            var program = new BI0027B();
            var result = program.Execute(BI0027BModel_P.SAI0027B);
            return Ok(result);
        }

        [HttpPost("BI0030B")]
        public IActionResult BI0030B(BI0030BModel BI0030BModel_P)
        {
            var program = new BI0030B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0032B")]
        public IActionResult BI0032B(BI0032BModel BI0032BModel_P)
        {
            var program = new BI0032B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0033B")]
        public IActionResult BI0033B(BI0033BModel BI0033BModel_P)
        {
            var program = new BI0033B();
            var result = program.Execute(BI0033BModel_P.MVDBCCOR, BI0033BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("BI0031B")]
        public IActionResult BI0031B(BI0031BModel BI0031BModel_P)
        {
            var program = new BI0031B();
            var result = program.Execute(BI0031BModel_P.MVDBCCOR, BI0031BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("BI0071B")]
        public IActionResult BI0071B(BI0071BModel BI0071BModel_P)
        {
            var program = new BI0071B();
            var result = program.Execute(BI0071BModel_P.MVDBSCRE, BI0071BModel_P.PRINTER, BI0071BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("BI0060B")]
        public IActionResult BI0060B(BI0060BModel BI0060BModel_P)
        {
            var program = new BI0060B();
            var result = program.Execute(BI0060BModel_P.BI0060B1, BI0060BModel_P.BI0060B2, BI0060BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("BI0072B")]
        public IActionResult BI0072B(BI0072BModel BI0072BModel_P)
        {
            var program = new BI0072B();
            var result = program.Execute(BI0072BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("BI0073B")]
        public IActionResult BI0073B(BI0073BModel BI0073BModel_P)
        {
            var program = new BI0073B();
            var result = program.Execute(BI0073BModel_P.MV370056);
            return Ok(result);
        }

        [HttpPost("BI0070B")]
        public IActionResult BI0070B(BI0070BModel BI0070BModel_P)
        {
            var program = new BI0070B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0074B")]
        public IActionResult BI0074B(BI0074BModel BI0074BModel_P)
        {
            var program = new BI0074B();
            var result = program.Execute(BI0074BModel_P.SORTWK01, BI0074BModel_P.ARQTXT);
            return Ok(result);
        }

        [HttpPost("BI0075B")]
        public IActionResult BI0075B(BI0075BModel BI0075BModel_P)
        {
            var program = new BI0075B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0097B")]
        public IActionResult BI0097B(BI0097BModel BI0097BModel_P)
        {
            var program = new BI0097B();
            var result = program.Execute(BI0097BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("BI0077B")]
        public IActionResult BI0077B(BI0077BModel BI0077BModel_P)
        {
            var program = new BI0077B();
            var result = program.Execute(BI0077BModel_P.MVCANCEL);
            return Ok(result);
        }

        [HttpPost("BI0078B")]
        public IActionResult BI0078B(BI0078BModel BI0078BModel_P)
        {
            var program = new BI0078B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI0229B")]
        public IActionResult BI0229B(BI0229BModel BI0229BModel_P)
        {
            var program = new BI0229B();
            var result = program.Execute(BI0229BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("BI0094B")]
        public IActionResult BI0094B(BI0094BModel BI0094BModel_P)
        {
            var program = new BI0094B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI3605B")]
        public IActionResult BI3605B(BI3605BModel BI3605BModel_P)
        {
            var program = new BI3605B();
            var result = program.Execute(BI3605BModel_P.STASCRED);
            return Ok(result);
        }

        [HttpPost("BI0230B")]
        public IActionResult BI0230B(BI0230BModel BI0230BModel_P)
        {
            var program = new BI0230B();
            var result = program.Execute(BI0230BModel_P.LK_PARAM, BI0230BModel_P.ARQSIG01, BI0230BModel_P.ARQSIG02);
            return Ok(result);
        }

        [HttpPost("BI5166B")]
        public IActionResult BI5166B(BI5166BModel BI5166BModel_P)
        {
            var program = new BI5166B();
            var result = program.Execute(BI5166BModel_P.ARQSAI1, BI5166BModel_P.ARQSAI2, BI5166BModel_P.ARQSAI3, BI5166BModel_P.ARQSAI4);
            return Ok(result);
        }

        [HttpPost("BI0602B")]
        public IActionResult BI0602B(BI0602BModel BI0602BModel_P)
        {
            var program = new BI0602B();
            var result = program.Execute(BI0602BModel_P.RELATORI);
            return Ok(result);
        }

        [HttpPost("BI1466B")]
        public IActionResult BI1466B(BI1466BModel BI1466BModel_P)
        {
            var program = new BI1466B();
            var result = program.Execute(BI1466BModel_P.SORTWK01, BI1466BModel_P.ABI1466B, BI1466BModel_P.DBI1466B);
            return Ok(result);
        }

        [HttpPost("BI6005B")]
        public IActionResult BI6005B(BI6005BModel BI6005BModel_P)
        {
            var program = new BI6005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI1610B")]
        public IActionResult BI1610B(BI1610BModel BI1610BModel_P)
        {
            var program = new BI1610B();
            var result = program.Execute(BI1610BModel_P.BI1610I1, BI1610BModel_P.BI1610O1);
            return Ok(result);
        }

        [HttpPost("BI6016B")]
        public IActionResult BI6016B(BI6016BModel BI6016BModel_P)
        {
            var program = new BI6016B();
            var result = program.Execute(BI6016BModel_P.SORTWK01, BI6016BModel_P.RBI6016B, BI6016BModel_P.RBI6016C);
            return Ok(result);
        }

        [HttpPost("BI1630B")]
        public IActionResult BI1630B(BI1630BModel BI1630BModel_P)
        {
            var program = new BI1630B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI2002B")]
        public IActionResult BI2002B(BI2002BModel BI2002BModel_P)
        {
            var program = new BI2002B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI6017B")]
        public IActionResult BI6017B(BI6017BModel BI6017BModel_P)
        {
            var program = new BI6017B();
            var result = program.Execute(BI6017BModel_P.SORTWK01, BI6017BModel_P.RBI6017B, BI6017BModel_P.RBI6017C);
            return Ok(result);
        }

        [HttpPost("BI6254B")]
        public IActionResult BI6254B(BI6254BModel BI6254BModel_P)
        {
            var program = new BI6254B();
            var result = program.Execute(BI6254BModel_P.MV023000, BI6254BModel_P.ARQTXT);
            return Ok(result);
        }

        [HttpPost("BI6032B")]
        public IActionResult BI6032B(BI6032BModel BI6032BModel_P)
        {
            var program = new BI6032B();
            var result = program.Execute(BI6032BModel_P.MVCRCCOR, BI6032BModel_P.BI6032B1);
            return Ok(result);
        }

        [HttpPost("BI6256B")]
        public IActionResult BI6256B(BI6256BModel BI6256BModel_P)
        {
            var program = new BI6256B();
            var result = program.Execute(BI6256BModel_P.MV012000, BI6256BModel_P.ARQTXT);
            return Ok(result);
        }

        [HttpPost("BI6252B")]
        public IActionResult BI6252B(BI6252BModel BI6252BModel_P)
        {
            var program = new BI6252B();
            var result = program.Execute(BI6252BModel_P.ARQTXT);
            return Ok(result);
        }

        [HttpPost("BI7028B")]
        public IActionResult BI7028B(BI7028BModel BI7028BModel_P)
        {
            var program = new BI7028B();
            var result = program.Execute(BI7028BModel_P.BI7028B1, BI7028BModel_P.BI7028B2, BI7028BModel_P.BI7028B3, BI7028BModel_P.BI7028B4, BI7028BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("BI6253B")]
        public IActionResult BI6253B(BI6253BModel BI6253BModel_P)
        {
            var program = new BI6253B();
            var result = program.Execute(BI6253BModel_P.SORTWK01, BI6253BModel_P.ARQTXT);
            return Ok(result);
        }

        [HttpPost("BI7401B")]
        public IActionResult BI7401B(BI7401BModel BI7401BModel_P)
        {
            var program = new BI7401B();
            var result = program.Execute(BI7401BModel_P.SORTWK01, BI7401BModel_P.ARQSAI1, BI7401BModel_P.ARQSAI2);
            return Ok(result);
        }

        [HttpPost("BI8005B")]
        public IActionResult BI8005B(BI8005BModel BI8005BModel_P)
        {
            var program = new BI8005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI8070B")]
        public IActionResult BI8070B(BI8070BModel BI8070BModel_P)
        {
            var program = new BI8070B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("BI8172B")]
        public IActionResult BI8172B(BI8172BModel BI8172BModel_P)
        {
            var program = new BI8172B();
            var result = program.Execute(BI8172BModel_P.BI8172A1, BI8172BModel_P.BI8172B1);
            return Ok(result);
        }

        [HttpPost("BI8173B")]
        public IActionResult BI8173B(BI8173BModel BI8173BModel_P)
        {
            var program = new BI8173B();
            var result = program.Execute(BI8173BModel_P.BI8173A1);
            return Ok(result);
        }

    }
}
