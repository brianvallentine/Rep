
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Geral.Model;
using IA_ConverterCommons;
using static Code.GE0005S;
using Code;

namespace Sias.Geral
{
    [ApiController]
    [Route("Geral")]
    public class GeralController : ControllerBase
    {

        [HttpPost("GE0005S")]
        public IActionResult GE0005S(GE0005SModel GE0005SModel_P)
        {
            var program = new GE0005S();
            var result = program.Execute(GE0005SModel_P.GE0005S_LINKAGE);
            return Ok(result);
        }

        [HttpPost("GE0006S")]
        public IActionResult GE0006S(GE0006SModel GE0006SModel_P)
        {
            var program = new GE0006S();
            var result = program.Execute(GE0006SModel_P.GE0006S_LINKAGE);
            return Ok(result);
        }

        [HttpPost("GE0070S")]
        public IActionResult GE0070S(GE0070SModel GE0070SModel_P)
        {
            var program = new GE0070S();
            var result = program.Execute(GE0070SModel_P.GE0070W);
            return Ok(result);
        }

        [HttpPost("GE0071S")]
        public IActionResult GE0071S(GE0071SModel GE0071SModel_P)
        {
            var program = new GE0071S();
            var result = program.Execute(GE0071SModel_P.GE0071W, GE0071SModel_P.LK_0071_S_ARR);
            return Ok(result);
        }

        [HttpPost("GE0080B")]
        public IActionResult GE0080B(GE0080BModel GE0080BModel_P)
        {
            var program = new GE0080B();
            var result = program.Execute(GE0080BModel_P.REG_LK_BANCOS);
            return Ok(result);
        }

        [HttpPost("GE0200B")]
        public IActionResult GE0200B(GE0200BModel GE0200BModel_P)
        {
            var program = new GE0200B();
            var result = program.Execute(GE0200BModel_P.ARQDIREC);
            return Ok(result);
        }

        [HttpPost("GE0300B")]
        public IActionResult GE0300B(GE0300BModel GE0300BModel_P)
        {
            var program = new GE0300B();
            var result = program.Execute(GE0300BModel_P.REGISTRO_LINKAGE_GE0300B);
            return Ok(result);
        }

        [HttpPost("GE0302B")]
        public IActionResult GE0302B(GE0302BModel GE0302BModel_P)
        {
            var program = new GE0302B();
            var result = program.Execute(GE0302BModel_P.REGISTRO_LINKAGE_GE0302B);
            return Ok(result);
        }

        [HttpPost("GE0306B")]
        public IActionResult GE0306B(GE0306BModel GE0306BModel_P)
        {
            var program = new GE0306B();
            var result = program.Execute(GE0306BModel_P.REGISTRO_LINKAGE_GE0306B);
            return Ok(result);
        }

        [HttpPost("GE0310B")]
        public IActionResult GE0310B(GE0310BModel GE0310BModel_P)
        {
            var program = new GE0310B();
            var result = program.Execute(GE0310BModel_P.REGISTRO_LINKAGE);
            return Ok(result);
        }

        [HttpPost("GE0350S")]
        public IActionResult GE0350S(GE0350SModel GE0350SModel_P)
        {
            var program = new GE0350S();
            var result = program.Execute(GE0350SModel_P.REGISTRO_LINKAGE_GE0350S);
            return Ok(result);
        }

        [HttpPost("GE0501B")]
        public IActionResult GE0501B(GE0501BModel GE0501BModel_P)
        {
            var program = new GE0501B();
            var result = program.Execute(GE0501BModel_P.LINK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("GE0355S")]
        public IActionResult GE0355S(GE0355SModel GE0355SModel_P)
        {
            var program = new GE0355S();
            var result = program.Execute(GE0355SModel_P.REGISTRO_LINKAGE_GE0355S);
            return Ok(result);
        }

        [HttpPost("GE0502B")]
        public IActionResult GE0502B(GE0502BModel GE0502BModel_P)
        {
            var program = new GE0502B();
            var result = program.Execute(GE0502BModel_P.LINK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("GE0503B")]
        public IActionResult GE0503B(GE0503BModel GE0503BModel_P)
        {
            var program = new GE0503B();
            var result = program.Execute(GE0503BModel_P.LINK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("GE0500B")]
        public IActionResult GE0500B(GE0500BModel GE0500BModel_P)
        {
            var program = new GE0500B();
            var result = program.Execute(GE0500BModel_P.LINK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("GE0510S")]
        public IActionResult GE0510S(GE0510SModel GE0510SModel_P)
        {
            var program = new GE0510S();
            var result = program.Execute(GE0510SModel_P.REGISTRO_LINKAGE_GE0510S);
            return Ok(result);
        }

        [HttpPost("GE0530S")]
        public IActionResult GE0530S(GE0530SModel GE0530SModel_P)
        {
            var program = new GE0530S();
            var result = program.Execute(GE0530SModel_P.LK_GE0530);
            return Ok(result);
        }

        [HttpPost("GE0531S")]
        public IActionResult GE0531S(GE0531SModel GE0531SModel_P)
        {
            var program = new GE0531S();
            var result = program.Execute(GE0531SModel_P.LK_GE0531);
            return Ok(result);
        }

        [HttpPost("GE0540S")]
        public IActionResult GE0540S(GE0540SModel GE0540SModel_P)
        {
            var program = new GE0540S();
            var result = program.Execute(GE0540SModel_P.WPARAMETROS);
            return Ok(result);
        }

        [HttpPost("GE0550B")]
        public IActionResult GE0550B(GE0550BModel GE0550BModel_P)
        {
            var program = new GE0550B();
            var result = program.Execute(GE0550BModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("GE0853S")]
        public IActionResult GE0853S(GE0853SModel GE0853SModel_P)
        {
            var program = new GE0853S();
            var result = program.Execute(GE0853SModel_P.REGISTRO_LINKAGE_GE0853S);
            return Ok(result);
        }

        [HttpPost("GECPB100")]
        public IActionResult GECPB100(GECPB100Model GECPB100Model_P)
        {
            var program = new GECPB100();
            var result = program.Execute(GECPB100Model_P.CPB100S1, GECPB100Model_P.CP100T01, GECPB100Model_P.CP100T02, GECPB100Model_P.CP100T03, GECPB100Model_P.CP100T04, GECPB100Model_P.CP100T05, GECPB100Model_P.CP100T67, GECPB100Model_P.CP100T08, GECPB100Model_P.CP100T09, GECPB100Model_P.CP100T10);
            return Ok(result);
        }

        [HttpPost("GECPB101")]
        public IActionResult GECPB101(GECPB101Model GECPB101Model_P)
        {
            var program = new GECPB101();
            var result = program.Execute(GECPB101Model_P.CPB101S1, GECPB101Model_P.CPB101S2);
            return Ok(result);
        }

        [HttpPost("GEJVS002")]
        public IActionResult GEJVS002(GEJVS002Model GEJVS002Model_P)
        {
            var program = new GEJVS002();
            var result = program.Execute(GEJVS002Model_P.GEJVW002, GEJVS002Model_P.GEJVWCNT);
            return Ok(result);
        }

    }
}
