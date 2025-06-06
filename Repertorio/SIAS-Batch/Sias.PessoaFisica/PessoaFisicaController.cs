
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.PessoaFisica.Model;
using IA_ConverterCommons;
using static Code.PF0002B;
using Code;

namespace Sias.PessoaFisica
{
    [ApiController]
    [Route("PessoaFisica")]
    public class PessoaFisicaController : ControllerBase
    {

        [HttpPost("PF0002B")]
        public IActionResult PF0002B(PF0002BModel PF0002BModel_P)
        {
            var program = new PF0002B();
            var result = program.Execute(PF0002BModel_P.SORTWK01, PF0002BModel_P.MOVCOB, PF0002BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("PF0003B")]
        public IActionResult PF0003B(PF0003BModel PF0003BModel_P)
        {
            var program = new PF0003B();
            var result = program.Execute(PF0003BModel_P.SORTWK01, PF0003BModel_P.MOVCOB);
            return Ok(result);
        }

        [HttpPost("PF0005S")]
        public IActionResult PF0005S(PF0005SModel PF0005SModel_P)
        {
            var program = new PF0005S();
            var result = program.Execute(PF0005SModel_P.PF0005W);
            return Ok(result);
        }

        [HttpPost("PF0403B")]
        public IActionResult PF0403B(PF0403BModel PF0403BModel_P)
        {
            var program = new PF0403B();
            var result = program.Execute(PF0403BModel_P.MOVSIGAT, PF0403BModel_P.RPF0403B, PF0403BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("PF0100B")]
        public IActionResult PF0100B(PF0100BModel PF0100BModel_P)
        {
            var program = new PF0100B();
            var result = program.Execute(PF0100BModel_P.STASASSE, PF0100BModel_P.STAFPREV, PF0100BModel_P.STAFCAP);
            return Ok(result);
        }

        [HttpPost("PF0103B")]
        public IActionResult PF0103B(PF0103BModel PF0103BModel_P)
        {
            var program = new PF0103B();
            var result = program.Execute(PF0103BModel_P.ARQVCRUZ, PF0103BModel_P.ARQSIGPF, PF0103BModel_P.RPF0103B);
            return Ok(result);
        }

        [HttpPost("PF0106B")]
        public IActionResult PF0106B(PF0106BModel PF0106BModel_P)
        {
            var program = new PF0106B();
            var result = program.Execute(PF0106BModel_P.MOVSIGAT);
            return Ok(result);
        }

        [HttpPost("PF0110B")]
        public IActionResult PF0110B(PF0110BModel PF0110BModel_P)
        {
            var program = new PF0110B();
            var result = program.Execute(PF0110BModel_P.MOVSIGAT, PF0110BModel_P.ARQESP, PF0110BModel_P.ARQVP, PF0110BModel_P.ARQVG, PF0110BModel_P.ARQDESP, PF0110BModel_P.ARQCRESC);
            return Ok(result);
        }

        [HttpPost("PF0112B")]
        public IActionResult PF0112B(PF0112BModel PF0112BModel_P)
        {
            var program = new PF0112B();
            var result = program.Execute(PF0112BModel_P.MVJUNMOV, PF0112BModel_P.BILHETES);
            return Ok(result);
        }

        [HttpPost("PF0402B")]
        public IActionResult PF0402B(PF0402BModel PF0402BModel_P)
        {
            var program = new PF0402B();
            var result = program.Execute(PF0402BModel_P.RPF0402B, PF0402BModel_P.DPF0402B, PF0402BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("PF0600B")]
        public IActionResult PF0600B(PF0600BModel PF0600BModel_P)
        {
            var program = new PF0600B();
            var result = program.Execute(PF0600BModel_P.MOVSIGAT, PF0600BModel_P.ARQAUTO, PF0600BModel_P.ARQRISCO, PF0600BModel_P.ARQVDEMP, PF0600BModel_P.ARQCEF, PF0600BModel_P.RPF0600B);
            return Ok(result);
        }

        [HttpPost("PF0602B")]
        public IActionResult PF0602B(PF0602BModel PF0602BModel_P)
        {
            var program = new PF0602B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("PF0605B")]
        public IActionResult PF0605B(PF0605BModel PF0605BModel_P)
        {
            var program = new PF0605B();
            var result = program.Execute(PF0605BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0612B")]
        public IActionResult PF0612B(PF0612BModel PF0612BModel_P)
        {
            var program = new PF0612B();
            var result = program.Execute(PF0612BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("PF0617B")]
        public IActionResult PF0617B(PF0617BModel PF0617BModel_P)
        {
            var program = new PF0617B();
            var result = program.Execute(PF0617BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("PF0618B")]
        public IActionResult PF0618B(PF0618BModel PF0618BModel_P)
        {
            var program = new PF0618B();
            var result = program.Execute(PF0618BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0619B")]
        public IActionResult PF0619B(PF0619BModel PF0619BModel_P)
        {
            var program = new PF0619B();
            var result = program.Execute(PF0619BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("PF0623B")]
        public IActionResult PF0623B(PF0623BModel PF0623BModel_P)
        {
            var program = new PF0623B();
            var result = program.Execute(PF0623BModel_P.PRPSASSE, PF0623BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0630B")]
        public IActionResult PF0630B(PF0630BModel PF0630BModel_P)
        {
            var program = new PF0630B();
            var result = program.Execute(PF0630BModel_P.PARAMEI, PF0630BModel_P.PARAMEO);
            return Ok(result);
        }

        [HttpPost("PF0634B")]
        public IActionResult PF0634B(PF0634BModel PF0634BModel_P)
        {
            var program = new PF0634B();
            var result = program.Execute(PF0634BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0641B")]
        public IActionResult PF0641B(PF0641BModel PF0641BModel_P)
        {
            var program = new PF0641B();
            var result = program.Execute(PF0641BModel_P.ARQMR, PF0641BModel_P.ARQCEF, PF0641BModel_P.ARQFNAE);
            return Ok(result);
        }

        [HttpPost("PF0642B")]
        public IActionResult PF0642B(PF0642BModel PF0642BModel_P)
        {
            var program = new PF0642B();
            var result = program.Execute(PF0642BModel_P.PRPSASSE, PF0642BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0648B")]
        public IActionResult PF0648B(PF0648BModel PF0648BModel_P)
        {
            var program = new PF0648B();
            var result = program.Execute(PF0648BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("PF0705B")]
        public IActionResult PF0705B(PF0705BModel PF0705BModel_P)
        {
            var program = new PF0705B();
            var result = program.Execute(PF0705BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0706B")]
        public IActionResult PF0706B(PF0706BModel PF0706BModel_P)
        {
            var program = new PF0706B();
            var result = program.Execute(PF0706BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0709B")]
        public IActionResult PF0709B(PF0709BModel PF0709BModel_P)
        {
            var program = new PF0709B();
            var result = program.Execute(PF0709BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0711B")]
        public IActionResult PF0711B(PF0711BModel PF0711BModel_P)
        {
            var program = new PF0711B();
            var result = program.Execute(PF0711BModel_P.STAMR, PF0711BModel_P.STACEF, PF0711BModel_P.STAFNAE, PF0711BModel_P.RPF0711B);
            return Ok(result);
        }

        [HttpPost("PF0714B")]
        public IActionResult PF0714B(PF0714BModel PF0714BModel_P)
        {
            var program = new PF0714B();
            var result = program.Execute(PF0714BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0715B")]
        public IActionResult PF0715B(PF0715BModel PF0715BModel_P)
        {
            var program = new PF0715B();
            var result = program.Execute(PF0715BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0716B")]
        public IActionResult PF0716B(PF0716BModel PF0716BModel_P)
        {
            var program = new PF0716B();
            var result = program.Execute(PF0716BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0717B")]
        public IActionResult PF0717B(PF0717BModel PF0717BModel_P)
        {
            var program = new PF0717B();
            var result = program.Execute(PF0717BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0720B")]
        public IActionResult PF0720B(PF0720BModel PF0720BModel_P)
        {
            var program = new PF0720B();
            var result = program.Execute(PF0720BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0721B")]
        public IActionResult PF0721B(PF0721BModel PF0721BModel_P)
        {
            var program = new PF0721B();
            var result = program.Execute(PF0721BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0725B")]
        public IActionResult PF0725B(PF0725BModel PF0725BModel_P)
        {
            var program = new PF0725B();
            var result = program.Execute(PF0725BModel_P.WS_PARAMETRO, PF0725BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0726B")]
        public IActionResult PF0726B(PF0726BModel PF0726BModel_P)
        {
            var program = new PF0726B();
            var result = program.Execute(PF0726BModel_P.STASASSE);
            return Ok(result);
        }

        [HttpPost("PF0770B")]
        public IActionResult PF0770B(PF0770BModel PF0770BModel_P)
        {
            var program = new PF0770B();
            var result = program.Execute(PF0770BModel_P.ENTRADA1, PF0770BModel_P.SAIDA770);
            return Ok(result);
        }

        [HttpPost("PF0771B")]
        public IActionResult PF0771B(PF0771BModel PF0771BModel_P)
        {
            var program = new PF0771B();
            var result = program.Execute(PF0771BModel_P.ENTRADA1, PF0771BModel_P.SAIDA771);
            return Ok(result);
        }

        [HttpPost("PF2002B")]
        public IActionResult PF2002B(PF2002BModel PF2002BModel_P)
        {
            var program = new PF2002B();
            var result = program.Execute(PF2002BModel_P.PF2002B_SYSIN, PF2002BModel_P.SORTWK01, PF2002BModel_P.MOVCOB, PF2002BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("PF4001B")]
        public IActionResult PF4001B(PF4001BModel PF4001BModel_P)
        {
            var program = new PF4001B();
            var result = program.Execute(PF4001BModel_P.CVPRJPRP);
            return Ok(result);
        }

        [HttpPost("PF4002B")]
        public IActionResult PF4002B(PF4002BModel PF4002BModel_P)
        {
            var program = new PF4002B();
            var result = program.Execute(PF4002BModel_P.CVPRJEMI);
            return Ok(result);
        }

    }
}
