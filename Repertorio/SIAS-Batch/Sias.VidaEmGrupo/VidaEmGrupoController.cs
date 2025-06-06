
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.VidaEmGrupo.Model;
using IA_ConverterCommons;
using static Code.VG0000B;
using Code;

namespace Sias.VidaEmGrupo
{
    [ApiController]
    [Route("VidaEmGrupo")]
    public class VidaEmGrupoController : ControllerBase
    {

        [HttpPost("VG0000B")]
        public IActionResult VG0000B(VG0000BModel VG0000BModel_P)
        {
            var program = new VG0000B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0001B")]
        public IActionResult VG0001B(VG0001BModel VG0001BModel_P)
        {
            var program = new VG0001B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0004B")]
        public IActionResult VG0004B(VG0004BModel VG0004BModel_P)
        {
            var program = new VG0004B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0010B")]
        public IActionResult VG0010B(VG0010BModel VG0010BModel_P)
        {
            var program = new VG0010B();
            var result = program.Execute(VG0010BModel_P.DVG0010D, VG0010BModel_P.DVG0010S);
            return Ok(result);
        }

        [HttpPost("VG0014B")]
        public IActionResult VG0014B(VG0014BModel VG0014BModel_P)
        {
            var program = new VG0014B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0015B")]
        public IActionResult VG0015B(VG0015BModel VG0015BModel_P)
        {
            var program = new VG0015B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0016B")]
        public IActionResult VG0016B(VG0016BModel VG0016BModel_P)
        {
            var program = new VG0016B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0020B")]
        public IActionResult VG0020B(VG0020BModel VG0020BModel_P)
        {
            var program = new VG0020B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0030B")]
        public IActionResult VG0030B(VG0030BModel VG0030BModel_P)
        {
            var program = new VG0030B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0031B")]
        public IActionResult VG0031B(VG0031BModel VG0031BModel_P)
        {
            var program = new VG0031B();
            var result = program.Execute(VG0031BModel_P.DVG0031D, VG0031BModel_P.DVG0031S);
            return Ok(result);
        }

        [HttpPost("VG0032B")]
        public IActionResult VG0032B(VG0032BModel VG0032BModel_P)
        {
            var program = new VG0032B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0035B")]
        public IActionResult VG0035B(VG0035BModel VG0035BModel_P)
        {
            var program = new VG0035B();
            var result = program.Execute(VG0035BModel_P.DVG0035B);
            return Ok(result);
        }

        [HttpPost("VG0040B")]
        public IActionResult VG0040B(VG0040BModel VG0040BModel_P)
        {
            var program = new VG0040B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0095B")]
        public IActionResult VG0095B(VG0095BModel VG0095BModel_P)
        {
            var program = new VG0095B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0100B")]
        public IActionResult VG0100B(VG0100BModel VG0100BModel_P)
        {
            var program = new VG0100B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0105B")]
        public IActionResult VG0105B(VG0105BModel VG0105BModel_P)
        {
            var program = new VG0105B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0105S")]
        public IActionResult VG0105S(VG0105SModel VG0105SModel_P)
        {
            var program = new VG0105S();
            var result = program.Execute(VG0105SModel_P.LK_NUM_PLANO, VG0105SModel_P.LK_NUM_SERIE, VG0105SModel_P.LK_NUM_TITULO, VG0105SModel_P.LK_NUM_PROPOSTA, VG0105SModel_P.LK_QTD_TITULOS, VG0105SModel_P.LK_VLR_TITULO, VG0105SModel_P.LK_EMP_PARCEIRA, VG0105SModel_P.LK_COD_RAMO, VG0105SModel_P.LK_COD_USUARIO, VG0105SModel_P.LK_NUM_NSA, VG0105SModel_P.LK_TRACE, VG0105SModel_P.LK_OUT_COD_RETORNO, VG0105SModel_P.LK_OUT_SQLCODE, VG0105SModel_P.LK_OUT_MENSAGEM, VG0105SModel_P.LK_OUT_SQLERRMC, VG0105SModel_P.LK_OUT_SQLSTATE);
            return Ok(result);
        }

        [HttpPost("VG0106B")]
        public IActionResult VG0106B(VG0106BModel VG0106BModel_P)
        {
            var program = new VG0106B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0120B")]
        public IActionResult VG0120B(VG0120BModel VG0120BModel_P)
        {
            var program = new VG0120B();
            var result = program.Execute(VG0120BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0121B")]
        public IActionResult VG0121B(VG0121BModel VG0121BModel_P)
        {
            var program = new VG0121B();
            var result = program.Execute(VG0121BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0122B")]
        public IActionResult VG0122B(VG0122BModel VG0122BModel_P)
        {
            var program = new VG0122B();
            var result = program.Execute(VG0122BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0123B")]
        public IActionResult VG0123B(VG0123BModel VG0123BModel_P)
        {
            var program = new VG0123B();
            var result = program.Execute(VG0123BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0130B")]
        public IActionResult VG0130B(VG0130BModel VG0130BModel_P)
        {
            var program = new VG0130B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0133B")]
        public IActionResult VG0133B(VG0133BModel VG0133BModel_P)
        {
            var program = new VG0133B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0134B")]
        public IActionResult VG0134B(VG0134BModel VG0134BModel_P)
        {
            var program = new VG0134B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0138B")]
        public IActionResult VG0138B(VG0138BModel VG0138BModel_P)
        {
            var program = new VG0138B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0139B")]
        public IActionResult VG0139B(VG0139BModel VG0139BModel_P)
        {
            var program = new VG0139B();
            var result = program.Execute(VG0139BModel_P.SORTWK01, VG0139BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("VG0145B")]
        public IActionResult VG0145B(VG0145BModel VG0145BModel_P)
        {
            var program = new VG0145B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0267B")]
        public IActionResult VG0267B(VG0267BModel VG0267BModel_P)
        {
            var program = new VG0267B();
            var result = program.Execute(VG0267BModel_P.LK_PARAM, VG0267BModel_P.VG0267B1, VG0267BModel_P.SORTWK01, VG0267BModel_P.VG0267B2);
            return Ok(result);
        }

        [HttpPost("VG0268B")]
        public IActionResult VG0268B(VG0268BModel VG0268BModel_P)
        {
            var program = new VG0268B();
            var result = program.Execute(VG0268BModel_P.VG0268B1, VG0268BModel_P.SORTWK01, VG0268BModel_P.VG0268B2);
            return Ok(result);
        }

        [HttpPost("VG0282B")]
        public IActionResult VG0282B(VG0282BModel VG0282BModel_P)
        {
            var program = new VG0282B();
            var result = program.Execute(VG0282BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0283B")]
        public IActionResult VG0283B(VG0283BModel VG0283BModel_P)
        {
            var program = new VG0283B();
            var result = program.Execute(VG0283BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0410B")]
        public IActionResult VG0410B(VG0410BModel VG0410BModel_P)
        {
            var program = new VG0410B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0601B")]
        public IActionResult VG0601B(VG0601BModel VG0601BModel_P)
        {
            var program = new VG0601B();
            var result = program.Execute(VG0601BModel_P.WPARM_PARAMETRO, VG0601BModel_P.QUADRO11);
            return Ok(result);
        }

        [HttpPost("VG0656B")]
        public IActionResult VG0656B(VG0656BModel VG0656BModel_P)
        {
            var program = new VG0656B();
            var result = program.Execute(VG0656BModel_P.WPAR_PARAMETROS, VG0656BModel_P.MDETALHE, VG0656BModel_P.MPRODUTO, VG0656BModel_P.MTRAB, VG0656BModel_P.SORTWK01, VG0656BModel_P.SORTWK02);
            return Ok(result);
        }

        [HttpPost("VG0702S")]
        public IActionResult VG0702S(VG0702SModel VG0702SModel_P)
        {
            var program = new VG0702S();
            var result = program.Execute(VG0702SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VG0705B")]
        public IActionResult VG0705B(VG0705BModel VG0705BModel_P)
        {
            var program = new VG0705B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0710S")]
        public IActionResult VG0710S(VG0710SModel VG0710SModel_P)
        {
            var program = new VG0710S();
            var result = program.Execute(VG0710SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VG0711S")]
        public IActionResult VG0711S(VG0711SModel VG0711SModel_P)
        {
            var program = new VG0711S();
            var result = program.Execute(VG0711SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VG0712S")]
        public IActionResult VG0712S(VG0712SModel VG0712SModel_P)
        {
            var program = new VG0712S();
            var result = program.Execute(VG0712SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VG0716S")]
        public IActionResult VG0716S(VG0716SModel VG0716SModel_P)
        {
            var program = new VG0716S();
            var result = program.Execute(VG0716SModel_P.VG0716S_COD_FONTE, VG0716SModel_P.VG0716S_COD_PRODUTO, VG0716SModel_P.VG0716S_NUM_PROPOSTA, VG0716SModel_P.VG0716S_VLR_MENSALIDADE, VG0716SModel_P.VG0716S_NUM_PLANO, VG0716SModel_P.VG0716S_NUM_SERIE, VG0716SModel_P.VG0716S_NUM_TITULO, VG0716SModel_P.VG0716S_IND_DV, VG0716SModel_P.VG0716S_DTH_INI_VIGENCIA, VG0716SModel_P.VG0716S_DTH_FIM_VIGENCIA, VG0716SModel_P.VG0716S_DES_COMBINACAO, VG0716SModel_P.VG0716S_COD_STA_TITULO, VG0716SModel_P.VG0716S_SQLCODE, VG0716SModel_P.VG0716S_COD_RETORNO, VG0716SModel_P.VG0716S_DES_MENSAGEM);
            return Ok(result);
        }

        [HttpPost("VG0781B")]
        public IActionResult VG0781B(VG0781BModel VG0781BModel_P)
        {
            var program = new VG0781B();
            var result = program.Execute(VG0781BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VG0816B")]
        public IActionResult VG0816B(VG0816BModel VG0816BModel_P)
        {
            var program = new VG0816B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0817B")]
        public IActionResult VG0817B(VG0817BModel VG0817BModel_P)
        {
            var program = new VG0817B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG0852B")]
        public IActionResult VG0852B(VG0852BModel VG0852BModel_P)
        {
            var program = new VG0852B();
            var result = program.Execute(VG0852BModel_P.STSASSE);
            return Ok(result);
        }

        [HttpPost("VG0853B")]
        public IActionResult VG0853B(VG0853BModel VG0853BModel_P)
        {
            var program = new VG0853B();
            var result = program.Execute(VG0853BModel_P.DVG0853D, VG0853BModel_P.DVG0853S, VG0853BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("VG1139B")]
        public IActionResult VG1139B(VG1139BModel VG1139BModel_P)
        {
            var program = new VG1139B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1473B")]
        public IActionResult VG1473B(VG1473BModel VG1473BModel_P)
        {
            var program = new VG1473B();
            var result = program.Execute(VG1473BModel_P.DVG1473B);
            return Ok(result);
        }

        [HttpPost("VG1601B")]
        public IActionResult VG1601B(VG1601BModel VG1601BModel_P)
        {
            var program = new VG1601B();
            var result = program.Execute(VG1601BModel_P.ARQGRAV);
            return Ok(result);
        }

        [HttpPost("VG1613B")]
        public IActionResult VG1613B(VG1613BModel VG1613BModel_P)
        {
            var program = new VG1613B();
            var result = program.Execute(VG1613BModel_P.MESPECE, VG1613BModel_P.SORTWK01, VG1613BModel_P.MESPECS);
            return Ok(result);
        }

        [HttpPost("VG1617B")]
        public IActionResult VG1617B(VG1617BModel VG1617BModel_P)
        {
            var program = new VG1617B();
            var result = program.Execute(VG1617BModel_P.MVBENEFC, VG1617BModel_P.RVG1617B);
            return Ok(result);
        }

        [HttpPost("VG1625B")]
        public IActionResult VG1625B(VG1625BModel VG1625BModel_P)
        {
            var program = new VG1625B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1626B")]
        public IActionResult VG1626B(VG1626BModel VG1626BModel_P)
        {
            var program = new VG1626B();
            var result = program.Execute(VG1626BModel_P.VG1626BO, VG1626BModel_P.VG1626BD);
            return Ok(result);
        }

        [HttpPost("VG1650B")]
        public IActionResult VG1650B(VG1650BModel VG1650BModel_P)
        {
            var program = new VG1650B();
            var result = program.Execute(VG1650BModel_P.MOVSIM);
            return Ok(result);
        }

        [HttpPost("VG1651B")]
        public IActionResult VG1651B(VG1651BModel VG1651BModel_P)
        {
            var program = new VG1651B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1652B")]
        public IActionResult VG1652B(VG1652BModel VG1652BModel_P)
        {
            var program = new VG1652B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1705B")]
        public IActionResult VG1705B(VG1705BModel VG1705BModel_P)
        {
            var program = new VG1705B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1706B")]
        public IActionResult VG1706B(VG1706BModel VG1706BModel_P)
        {
            var program = new VG1706B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG1853B")]
        public IActionResult VG1853B(VG1853BModel VG1853BModel_P)
        {
            var program = new VG1853B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG2600B")]
        public IActionResult VG2600B(VG2600BModel VG2600BModel_P)
        {
            var program = new VG2600B();
            var result = program.Execute(VG2600BModel_P.MVPORTAL, VG2600BModel_P.RVG2600B);
            return Ok(result);
        }

        [HttpPost("VG2853B")]
        public IActionResult VG2853B(VG2853BModel VG2853BModel_P)
        {
            var program = new VG2853B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG4267B")]
        public IActionResult VG4267B(VG4267BModel VG4267BModel_P)
        {
            var program = new VG4267B();
            var result = program.Execute(VG4267BModel_P.VG4267B1, VG4267BModel_P.SORTWK01, VG4267BModel_P.VG4267B2);
            return Ok(result);
        }

        [HttpPost("VG5001B")]
        public IActionResult VG5001B(VG5001BModel VG5001BModel_P)
        {
            var program = new VG5001B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG5705B")]
        public IActionResult VG5705B(VG5705BModel VG5705BModel_P)
        {
            var program = new VG5705B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG5706B")]
        public IActionResult VG5706B(VG5706BModel VG5706BModel_P)
        {
            var program = new VG5706B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG9020S")]
        public IActionResult VG9020S(VG9020SModel VG9020SModel_P)
        {
            var program = new VG9020S();
            var result = program.Execute(VG9020SModel_P.CSP_NRCERTIF, VG9020SModel_P.H_OUT_COD_RETORNO, VG9020SModel_P.H_OUT_COD_RETORNO_SQL, VG9020SModel_P.H_OUT_MENSAGEM, VG9020SModel_P.H_OUT_SQLERRMC, VG9020SModel_P.H_OUT_SQLSTATE);
            return Ok(result);
        }

        [HttpPost("VG9521B")]
        public IActionResult VG9521B(VG9521BModel VG9521BModel_P)
        {
            var program = new VG9521B();
            var result = program.Execute(VG9521BModel_P.DVG9521B);
            return Ok(result);
        }

        [HttpPost("VG9545B")]
        public IActionResult VG9545B(VG9545BModel VG9545BModel_P)
        {
            var program = new VG9545B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG9546B")]
        public IActionResult VG9546B(VG9546BModel VG9546BModel_P)
        {
            var program = new VG9546B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VG9550B")]
        public IActionResult VG9550B(VG9550BModel VG9550BModel_P)
        {
            var program = new VG9550B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP0020B")]
        public IActionResult VP0020B(VP0020BModel VP0020BModel_P)
        {
            var program = new VP0020B();
            var result = program.Execute(VP0020BModel_P.CADCEF);
            return Ok(result);
        }

        [HttpPost("VP0050B")]
        public IActionResult VP0050B(VP0050BModel VP0050BModel_P)
        {
            var program = new VP0050B();
            var result = program.Execute(VP0050BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VP0099B")]
        public IActionResult VP0099B(VP0099BModel VP0099BModel_P)
        {
            var program = new VP0099B();
            var result = program.Execute(VP0099BModel_P.ARQTEMPO);
            return Ok(result);
        }

        [HttpPost("VP0105B")]
        public IActionResult VP0105B(VP0105BModel VP0105BModel_P)
        {
            var program = new VP0105B();
            var result = program.Execute(VP0105BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VP0106B")]
        public IActionResult VP0106B(VP0106BModel VP0106BModel_P)
        {
            var program = new VP0106B();
            var result = program.Execute(VP0106BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VP0107B")]
        public IActionResult VP0107B(VP0107BModel VP0107BModel_P)
        {
            var program = new VP0107B();
            var result = program.Execute(VP0107BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VP0108B")]
        public IActionResult VP0108B(VP0108BModel VP0108BModel_P)
        {
            var program = new VP0108B();
            var result = program.Execute(VP0108BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VP0118B")]
        public IActionResult VP0118B(VP0118BModel VP0118BModel_P)
        {
            var program = new VP0118B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP0121B")]
        public IActionResult VP0121B(VP0121BModel VP0121BModel_P)
        {
            var program = new VP0121B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP0437B")]
        public IActionResult VP0437B(VP0437BModel VP0437BModel_P)
        {
            var program = new VP0437B();
            var result = program.Execute(VP0437BModel_P.VP0437B1, VP0437BModel_P.SORTWK01, VP0437BModel_P.VP0437B2);
            return Ok(result);
        }

        [HttpPost("VP0601B")]
        public IActionResult VP0601B(VP0601BModel VP0601BModel_P)
        {
            var program = new VP0601B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP1110B")]
        public IActionResult VP1110B(VP1110BModel VP1110BModel_P)
        {
            var program = new VP1110B();
            var result = program.Execute(VP1110BModel_P.VP1110S1);
            return Ok(result);
        }

        [HttpPost("VP1111B")]
        public IActionResult VP1111B(VP1111BModel VP1111BModel_P)
        {
            var program = new VP1111B();
            var result = program.Execute(VP1111BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("VP5705B")]
        public IActionResult VP5705B(VP5705BModel VP5705BModel_P)
        {
            var program = new VP5705B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP5706B")]
        public IActionResult VP5706B(VP5706BModel VP5706BModel_P)
        {
            var program = new VP5706B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP6705B")]
        public IActionResult VP6705B(VP6705BModel VP6705BModel_P)
        {
            var program = new VP6705B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VP6706B")]
        public IActionResult VP6706B(VP6706BModel VP6706BModel_P)
        {
            var program = new VP6706B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
