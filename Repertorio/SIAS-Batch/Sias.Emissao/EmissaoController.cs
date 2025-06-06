
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Emissao.Model;
using IA_ConverterCommons;
using static Code.EM0005B;
using Code;

namespace Sias.Emissao
{
    [ApiController]
    [Route("Emissao")]
    public class EmissaoController : ControllerBase
    {

        [HttpPost("EM0005B")]
        public IActionResult EM0005B(EM0005BModel EM0005BModel_P)
        {
            var program = new EM0005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0006B")]
        public IActionResult EM0006B(EM0006BModel EM0006BModel_P)
        {
            var program = new EM0006B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0120B")]
        public IActionResult EM0120B(EM0120BModel EM0120BModel_P)
        {
            var program = new EM0120B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0135B")]
        public IActionResult EM0135B(EM0135BModel EM0135BModel_P)
        {
            var program = new EM0135B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0202B")]
        public IActionResult EM0202B(EM0202BModel EM0202BModel_P)
        {
            var program = new EM0202B();
            var result = program.Execute(EM0202BModel_P.REM0202B);
            return Ok(result);
        }

        [HttpPost("EM0229B")]
        public IActionResult EM0229B(EM0229BModel EM0229BModel_P)
        {
            var program = new EM0229B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0901S")]
        public IActionResult EM0901S(EM0901SModel EM0901SModel_P)
        {
            var program = new EM0901S();
            var result = program.Execute(EM0901SModel_P.CALCULOS);
            return Ok(result);
        }

        [HttpPost("EM0903S")]
        public IActionResult EM0903S(EM0903SModel EM0903SModel_P)
        {
            var program = new EM0903S();
            var result = program.Execute(EM0903SModel_P.CALCULOS);
            return Ok(result);
        }

        [HttpPost("EM0904S")]
        public IActionResult EM0904S(EM0904SModel EM0904SModel_P)
        {
            var program = new EM0904S();
            var result = program.Execute(EM0904SModel_P.CALCULOS);
            return Ok(result);
        }

        [HttpPost("EM0905S")]
        public IActionResult EM0905S(EM0905SModel EM0905SModel_P)
        {
            var program = new EM0905S();
            var result = program.Execute(EM0905SModel_P.CALCULOS);
            return Ok(result);
        }

        [HttpPost("EM0910S")]
        public IActionResult EM0910S(EM0910SModel EM0910SModel_P)
        {
            var program = new EM0910S();
            var result = program.Execute(EM0910SModel_P.LK_PROPOSTA);
            return Ok(result);
        }

        [HttpPost("EM0911S")]
        public IActionResult EM0911S(EM0911SModel EM0911SModel_P)
        {
            var program = new EM0911S();
            var result = program.Execute(EM0911SModel_P.LK_PROPOSTA);
            return Ok(result);
        }

        [HttpPost("EM0912S")]
        public IActionResult EM0912S(EM0912SModel EM0912SModel_P)
        {
            var program = new EM0912S();
            var result = program.Execute(EM0912SModel_P.LK_PROPOSTA);
            return Ok(result);
        }

        [HttpPost("EM0913S")]
        public IActionResult EM0913S(EM0913SModel EM0913SModel_P)
        {
            var program = new EM0913S();
            var result = program.Execute(EM0913SModel_P.LK_PROPOSTA);
            return Ok(result);
        }

        [HttpPost("EM0914S")]
        public IActionResult EM0914S(EM0914SModel EM0914SModel_P)
        {
            var program = new EM0914S();
            var result = program.Execute(EM0914SModel_P.LK_PROPOSTA);
            return Ok(result);
        }

        [HttpPost("EM0925S")]
        public IActionResult EM0925S(EM0925SModel EM0925SModel_P)
        {
            var program = new EM0925S();
            var result = program.Execute(EM0925SModel_P.LPARM);
            return Ok(result);
        }

        [HttpPost("EM1139B")]
        public IActionResult EM1139B(EM1139BModel EM1139BModel_P)
        {
            var program = new EM1139B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0010B")]
        public IActionResult EM0010B(EM0010BModel EM0010BModel_P)
        {
            var program = new EM0010B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0015B")]
        public IActionResult EM0015B(EM0015BModel EM0015BModel_P)
        {
            var program = new EM0015B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM0030B")]
        public IActionResult EM0030B(EM0030BModel EM0030BModel_P)
        {
            var program = new EM0030B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("EM8007B")]
        public IActionResult EM8007B(EM8007BModel EM8007BModel_P)
        {
            var program = new EM8007B();
            var result = program.Execute(EM8007BModel_P.SORTWK01, EM8007BModel_P.ENTRADA, EM8007BModel_P.ARQCOB01, EM8007BModel_P.ARQCOB02, EM8007BModel_P.ARQCOB03, EM8007BModel_P.ARQCOB04, EM8007BModel_P.ARQCOB05, EM8007BModel_P.ARQCOB06, EM8007BModel_P.ARQCOB07, EM8007BModel_P.ARQCOB08, EM8007BModel_P.ARQCOB09, EM8007BModel_P.ARQCOB10, EM8007BModel_P.ARQCOB11, EM8007BModel_P.ARQCOB12, EM8007BModel_P.ARQCOB13, EM8007BModel_P.ARQCOB14, EM8007BModel_P.ARQCOB15, EM8007BModel_P.ARQCOB16, EM8007BModel_P.ARQCOB17, EM8007BModel_P.ARQCOB18, EM8007BModel_P.ARQCOB19, EM8007BModel_P.ARQCOB20, EM8007BModel_P.ARQCOB21, EM8007BModel_P.ARQCOB22, EM8007BModel_P.ARQCOB23, EM8007BModel_P.ARQCOB24, EM8007BModel_P.ARQCOB25);
            return Ok(result);
        }

        [HttpPost("EM8008B")]
        public IActionResult EM8008B(EM8008BModel EM8008BModel_P)
        {
            var program = new EM8008B();
            var result = program.Execute(EM8008BModel_P.SORTWK01, EM8008BModel_P.ENTRADA, EM8008BModel_P.ARQCOV01, EM8008BModel_P.ARQCOV02, EM8008BModel_P.ARQCOV03, EM8008BModel_P.ARQCOV04, EM8008BModel_P.ARQCOV05, EM8008BModel_P.ARQCOV06, EM8008BModel_P.ARQCOV07, EM8008BModel_P.ARQCOV08, EM8008BModel_P.ARQCOV09, EM8008BModel_P.ARQCOV10, EM8008BModel_P.ARQCOV11, EM8008BModel_P.ARQCOV12, EM8008BModel_P.ARQCOV13, EM8008BModel_P.ARQCOV14, EM8008BModel_P.ARQCOV15);
            return Ok(result);
        }

        [HttpPost("EM8009B")]
        public IActionResult EM8009B(EM8009BModel EM8009BModel_P)
        {
            var program = new EM8009B();
            var result = program.Execute(EM8009BModel_P.SORTWK01, EM8009BModel_P.ENTRADA, EM8009BModel_P.ARQCAP01, EM8009BModel_P.ARQCAP02, EM8009BModel_P.ARQCAP03, EM8009BModel_P.ARQCAP04);
            return Ok(result);
        }

        [HttpPost("EM8010B")]
        public IActionResult EM8010B(EM8010BModel EM8010BModel_P)
        {
            var program = new EM8010B();
            var result = program.Execute(EM8010BModel_P.SORTWK01, EM8010BModel_P.ENTRADA, EM8010BModel_P.ARQSIG01);
            return Ok(result);
        }

        [HttpPost("EM8006B")]
        public IActionResult EM8006B(EM8006BModel EM8006BModel_P)
        {
            var program = new EM8006B();
            var result = program.Execute(EM8006BModel_P.ARQH, EM8006BModel_P.SICOV, EM8006BModel_P.SICAP, EM8006BModel_P.SICOB, EM8006BModel_P.SIGPF, EM8006BModel_P.CARTAO, EM8006BModel_P.CHEQUE, EM8006BModel_P.SIACC, EM8006BModel_P.BANCOOB);
            return Ok(result);
        }

        [HttpPost("EM8012B")]
        public IActionResult EM8012B(EM8012BModel EM8012BModel_P)
        {
            var program = new EM8012B();
            var result = program.Execute(EM8012BModel_P.SORTWK01, EM8012BModel_P.ENTRADA, EM8012BModel_P.ARQCOB01, EM8012BModel_P.ARQCOB02, EM8012BModel_P.ARQCOB03);
            return Ok(result);
        }

        [HttpPost("EM8020B")]
        public IActionResult EM8020B(EM8020BModel EM8020BModel_P)
        {
            var program = new EM8020B();
            var result = program.Execute(EM8020BModel_P.SORTWK01, EM8020BModel_P.SIACC, EM8020BModel_P.MV921286);
            return Ok(result);
        }

        [HttpPost("EM8021B")]
        public IActionResult EM8021B(EM8021BModel EM8021BModel_P)
        {
            var program = new EM8021B();
            var result = program.Execute(EM8021BModel_P.SORTWK01, EM8021BModel_P.SIACC, EM8021BModel_P.MV043350);
            return Ok(result);
        }

        [HttpPost("EM8024B")]
        public IActionResult EM8024B(EM8024BModel EM8024BModel_P)
        {
            var program = new EM8024B();
            var result = program.Execute(EM8024BModel_P.MOVCIELO, EM8024BModel_P.CCADESAO, EM8024BModel_P.CCDEMAIS);
            return Ok(result);
        }

        [HttpPost("EM8051B")]
        public IActionResult EM8051B(EM8051BModel EM8051BModel_P)
        {
            var program = new EM8051B();
            var result = program.Execute(EM8051BModel_P.ARQH);
            return Ok(result);
        }

    }
}
