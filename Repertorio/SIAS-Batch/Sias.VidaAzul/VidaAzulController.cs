
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.VidaAzul.Model;
using IA_ConverterCommons;
using static Code.VA0128B;
using Code;

namespace Sias.VidaAzul
{
    [ApiController]
    [Route("VidaAzul")]
    public class VidaAzulController : ControllerBase
    {

        [HttpPost("VA0128B")]
        public IActionResult VA0128B(VA0128BModel VA0128BModel_P)
        {
            var program = new VA0128B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0130B")]
        public IActionResult VA0130B(VA0130BModel VA0130BModel_P)
        {
            var program = new VA0130B();
            var result = program.Execute(VA0130BModel_P.LK_PARAMETRO, VA0130BModel_P.VAMOVTO, VA0130BModel_P.MOVCORR, VA0130BModel_P.MOVDESP);
            return Ok(result);
        }

        [HttpPost("VA0132B")]
        public IActionResult VA0132B(VA0132BModel VA0132BModel_P)
        {
            var program = new VA0132B();
            var result = program.Execute(VA0132BModel_P.CARENCIA, VA0132BModel_P.RARENCIA);
            return Ok(result);
        }

        [HttpPost("VA0133B")]
        public IActionResult VA0133B(VA0133BModel VA0133BModel_P)
        {
            var program = new VA0133B();
            var result = program.Execute(VA0133BModel_P.WS_DTPARM, VA0133BModel_P.VA0133B1, VA0133BModel_P.VA0133B2);
            return Ok(result);
        }

        [HttpPost("VA0134B")]
        public IActionResult VA0134B(VA0134BModel VA0134BModel_P)
        {
            var program = new VA0134B();
            var result = program.Execute(VA0134BModel_P.WS_DTPARM, VA0134BModel_P.VA0134B1, VA0134BModel_P.VA0134B2);
            return Ok(result);
        }

        [HttpPost("VA0139B")]
        public IActionResult VA0139B(VA0139BModel VA0139BModel_P)
        {
            var program = new VA0139B();
            var result = program.Execute(VA0139BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0140B")]
        public IActionResult VA0140B(VA0140BModel VA0140BModel_P)
        {
            var program = new VA0140B();
            var result = program.Execute(VA0140BModel_P.SORTWK01, VA0140BModel_P.ARQSAI1, VA0140BModel_P.ARQSAI2);
            return Ok(result);
        }

        [HttpPost("VA0141B")]
        public IActionResult VA0141B(VA0141BModel VA0141BModel_P)
        {
            var program = new VA0141B();
            var result = program.Execute(VA0141BModel_P.SORTWK01, VA0141BModel_P.ARQENT1, VA0141BModel_P.ARQSAI1);
            return Ok(result);
        }

        [HttpPost("VA0142B")]
        public IActionResult VA0142B(VA0142BModel VA0142BModel_P)
        {
            var program = new VA0142B();
            var result = program.Execute(VA0142BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0143B")]
        public IActionResult VA0143B(VA0143BModel VA0143BModel_P)
        {
            var program = new VA0143B();
            var result = program.Execute(VA0143BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0152B")]
        public IActionResult VA0152B(VA0152BModel VA0152BModel_P)
        {
            var program = new VA0152B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0280B")]
        public IActionResult VA0280B(VA0280BModel VA0280BModel_P)
        {
            var program = new VA0280B();
            var result = program.Execute(VA0280BModel_P.MOVSOER, VA0280BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("VA0340B")]
        public IActionResult VA0340B(VA0340BModel VA0340BModel_P)
        {
            var program = new VA0340B();
            var result = program.Execute(VA0340BModel_P.MVDB6088);
            return Ok(result);
        }

        [HttpPost("VA0341B")]
        public IActionResult VA0341B(VA0341BModel VA0341BModel_P)
        {
            var program = new VA0341B();
            var result = program.Execute(VA0341BModel_P.MVDP6090, VA0341BModel_P.OUTROSBC);
            return Ok(result);
        }

        [HttpPost("VA0344B")]
        public IActionResult VA0344B(VA0344BModel VA0344BModel_P)
        {
            var program = new VA0344B();
            var result = program.Execute(VA0344BModel_P.MVES6088);
            return Ok(result);
        }

        [HttpPost("VA0345B")]
        public IActionResult VA0345B(VA0345BModel VA0345BModel_P)
        {
            var program = new VA0345B();
            var result = program.Execute(VA0345BModel_P.MVES6090);
            return Ok(result);
        }

        [HttpPost("VA0415B")]
        public IActionResult VA0415B(VA0415BModel VA0415BModel_P)
        {
            var program = new VA0415B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0416B")]
        public IActionResult VA0416B(VA0416BModel VA0416BModel_P)
        {
            var program = new VA0416B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0417B")]
        public IActionResult VA0417B(VA0417BModel VA0417BModel_P)
        {
            var program = new VA0417B();
            var result = program.Execute(VA0417BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VA0445B")]
        public IActionResult VA0445B(VA0445BModel VA0445BModel_P)
        {
            var program = new VA0445B();
            var result = program.Execute(VA0445BModel_P.SORTWK01, VA0445BModel_P.AVA0445B, VA0445BModel_P.DVA0445B, VA0445BModel_P.DVA0445D, VA0445BModel_P.DVA0445S);
            return Ok(result);
        }

        [HttpPost("VA0458B")]
        public IActionResult VA0458B(VA0458BModel VA0458BModel_P)
        {
            var program = new VA0458B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0459B")]
        public IActionResult VA0459B(VA0459BModel VA0459BModel_P)
        {
            var program = new VA0459B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0460B")]
        public IActionResult VA0460B(VA0460BModel VA0460BModel_P)
        {
            var program = new VA0460B();
            var result = program.Execute(VA0460BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VA0469B")]
        public IActionResult VA0469B(VA0469BModel VA0469BModel_P)
        {
            var program = new VA0469B();
            var result = program.Execute(VA0469BModel_P.ARQCHEQ);
            return Ok(result);
        }

        [HttpPost("VA0506B")]
        public IActionResult VA0506B(VA0506BModel VA0506BModel_P)
        {
            var program = new VA0506B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0590B")]
        public IActionResult VA0590B(VA0590BModel VA0590BModel_P)
        {
            var program = new VA0590B();
            var result = program.Execute(VA0590BModel_P.ARQVA590);
            return Ok(result);
        }

        [HttpPost("VA0600B")]
        public IActionResult VA0600B(VA0600BModel VA0600BModel_P)
        {
            var program = new VA0600B();
            var result = program.Execute(VA0600BModel_P.MOVSIGAT, VA0600BModel_P.ARQVDEMP, VA0600BModel_P.RVA0600B);
            return Ok(result);
        }

        [HttpPost("VA0601B")]
        public IActionResult VA0601B(VA0601BModel VA0601BModel_P)
        {
            var program = new VA0601B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0681B")]
        public IActionResult VA0681B(VA0681BModel VA0681BModel_P)
        {
            var program = new VA0681B();
            var result = program.Execute(VA0681BModel_P.VA0681BA, VA0681BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0685B")]
        public IActionResult VA0685B(VA0685BModel VA0685BModel_P)
        {
            var program = new VA0685B();
            var result = program.Execute(VA0685BModel_P.SORTWK01, VA0685BModel_P.VA0685BS);
            return Ok(result);
        }

        [HttpPost("VA0805B")]
        public IActionResult VA0805B(VA0805BModel VA0805BModel_P)
        {
            var program = new VA0805B();
            var result = program.Execute(VA0805BModel_P.PRINTER1, VA0805BModel_P.RETCEF, VA0805BModel_P.RETOPT, VA0805BModel_P.RETDEB, VA0805BModel_P.RETCRE, VA0805BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0806B")]
        public IActionResult VA0806B(VA0806BModel VA0806BModel_P)
        {
            var program = new VA0806B();
            var result = program.Execute(VA0806BModel_P.RETDEB, VA0806BModel_P.RETCRE);
            return Ok(result);
        }

        [HttpPost("VA0812B")]
        public IActionResult VA0812B(VA0812BModel VA0812BModel_P)
        {
            var program = new VA0812B();
            var result = program.Execute(VA0812BModel_P.RETCRE, VA0812BModel_P.RETINVC);
            return Ok(result);
        }

        [HttpPost("VA0813B")]
        public IActionResult VA0813B(VA0813BModel VA0813BModel_P)
        {
            var program = new VA0813B();
            var result = program.Execute(VA0813BModel_P.RETDEB, VA0813BModel_P.RETERR, VA0813BModel_P.MAUDIT, VA0813BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA0850B")]
        public IActionResult VA0850B(VA0850BModel VA0850BModel_P)
        {
            var program = new VA0850B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0853B")]
        public IActionResult VA0853B(VA0853BModel VA0853BModel_P)
        {
            var program = new VA0853B();
            var result = program.Execute(VA0853BModel_P.LK_PARAMETROS, VA0853BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("VA0860B")]
        public IActionResult VA0860B(VA0860BModel VA0860BModel_P)
        {
            var program = new VA0860B();
            var result = program.Execute(VA0860BModel_P.RETDEB, VA0860BModel_P.AVA0860B);
            return Ok(result);
        }

        [HttpPost("VA0010B")]
        public IActionResult VA0010B(VA0010BModel VA0010BModel_P)
        {
            var program = new VA0010B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0050B")]
        public IActionResult VA0050B(VA0050BModel VA0050BModel_P)
        {
            var program = new VA0050B();
            var result = program.Execute(VA0050BModel_P.MVICRIVO);
            return Ok(result);
        }

        [HttpPost("VA0055B")]
        public IActionResult VA0055B(VA0055BModel VA0055BModel_P)
        {
            var program = new VA0055B();
            var result = program.Execute(VA0055BModel_P.MRECRIVO);
            return Ok(result);
        }

        [HttpPost("VA0056B")]
        public IActionResult VA0056B(VA0056BModel VA0056BModel_P)
        {
            var program = new VA0056B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0061B")]
        public IActionResult VA0061B(VA0061BModel VA0061BModel_P)
        {
            var program = new VA0061B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0100S")]
        public IActionResult VA0100S(VA0100SModel VA0100SModel_P)
        {
            var program = new VA0100S();
            var result = program.Execute(VA0100SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VA0101S")]
        public IActionResult VA0101S(VA0101SModel VA0101SModel_P)
        {
            var program = new VA0101S();
            var result = program.Execute(VA0101SModel_P.PARAMETROS);
            return Ok(result);
        }

        [HttpPost("VA0930B")]
        public IActionResult VA0930B(VA0930BModel VA0930BModel_P)
        {
            var program = new VA0930B();
            var result = program.Execute(VA0930BModel_P.LK_PARAMETRO, VA0930BModel_P.SORTWK01, VA0930BModel_P.AVA0930B);
            return Ok(result);
        }

        [HttpPost("VA0951B")]
        public IActionResult VA0951B(VA0951BModel VA0951BModel_P)
        {
            var program = new VA0951B();
            var result = program.Execute(VA0951BModel_P.WPAR_PARAMETROS, VA0951BModel_P.SORTWK01, VA0951BModel_P.AVA0951B);
            return Ok(result);
        }

        [HttpPost("VA0952B")]
        public IActionResult VA0952B(VA0952BModel VA0952BModel_P)
        {
            var program = new VA0952B();
            var result = program.Execute(VA0952BModel_P.WPAR_PARAMETROS, VA0952BModel_P.SORTWK01, VA0952BModel_P.AVA0952B);
            return Ok(result);
        }

        [HttpPost("VA0118B")]
        public IActionResult VA0118B(VA0118BModel VA0118BModel_P)
        {
            var program = new VA0118B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0953B")]
        public IActionResult VA0953B(VA0953BModel VA0953BModel_P)
        {
            var program = new VA0953B();
            var result = program.Execute(VA0953BModel_P.ARQSORT, VA0953BModel_P.RVA0953B);
            return Ok(result);
        }

        [HttpPost("VA0123B")]
        public IActionResult VA0123B(VA0123BModel VA0123BModel_P)
        {
            var program = new VA0123B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0955B")]
        public IActionResult VA0955B(VA0955BModel VA0955BModel_P)
        {
            var program = new VA0955B();
            var result = program.Execute(VA0955BModel_P.ARQSORT, VA0955BModel_P.RVA0955B);
            return Ok(result);
        }

        [HttpPost("VA0126B")]
        public IActionResult VA0126B(VA0126BModel VA0126BModel_P)
        {
            var program = new VA0126B();
            var result = program.Execute(VA0126BModel_P.PRPSASSE);
            return Ok(result);
        }

        [HttpPost("VA0127B")]
        public IActionResult VA0127B(VA0127BModel VA0127BModel_P)
        {
            var program = new VA0127B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA0956B")]
        public IActionResult VA0956B(VA0956BModel VA0956BModel_P)
        {
            var program = new VA0956B();
            var result = program.Execute(VA0956BModel_P.ARQSORT, VA0956BModel_P.RVA0956B);
            return Ok(result);
        }

        [HttpPost("VA0964B")]
        public IActionResult VA0964B(VA0964BModel VA0964BModel_P)
        {
            var program = new VA0964B();
            var result = program.Execute(VA0964BModel_P.SAI0964B);
            return Ok(result);
        }

        [HttpPost("VA0965B")]
        public IActionResult VA0965B(VA0965BModel VA0965BModel_P)
        {
            var program = new VA0965B();
            var result = program.Execute(VA0965BModel_P.AREA_DE_WORK, VA0965BModel_P.ARQSAIDA_FILE_NAME);
            return Ok(result);
        }

        [HttpPost("VA0966B")]
        public IActionResult VA0966B(VA0966BModel VA0966BModel_P)
        {
            var program = new VA0966B();
            var result = program.Execute(VA0966BModel_P.AREA_DE_WORK, VA0966BModel_P.SAI0966B);
            return Ok(result);
        }

        [HttpPost("VA0967B")]
        public IActionResult VA0967B(VA0967BModel VA0967BModel_P)
        {
            var program = new VA0967B();
            var result = program.Execute(VA0967BModel_P.AREA_DE_WORK, VA0967BModel_P.SAI0967B);
            return Ok(result);
        }

        [HttpPost("VA0970B")]
        public IActionResult VA0970B(VA0970BModel VA0970BModel_P)
        {
            var program = new VA0970B();
            var result = program.Execute(VA0970BModel_P.AREA_DE_WORK, VA0970BModel_P.ARQSAIDA_FILE_NAME);
            return Ok(result);
        }

        [HttpPost("VA0972B")]
        public IActionResult VA0972B(VA0972BModel VA0972BModel_P)
        {
            var program = new VA0972B();
            var result = program.Execute(VA0972BModel_P.DEVCIELO);
            return Ok(result);
        }

        [HttpPost("VA0973B")]
        public IActionResult VA0973B(VA0973BModel VA0973BModel_P)
        {
            var program = new VA0973B();
            var result = program.Execute(VA0973BModel_P.RETCIELO);
            return Ok(result);
        }

        [HttpPost("VA1139B")]
        public IActionResult VA1139B(VA1139BModel VA1139BModel_P)
        {
            var program = new VA1139B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA1180B")]
        public IActionResult VA1180B(VA1180BModel VA1180BModel_P)
        {
            var program = new VA1180B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA1184B")]
        public IActionResult VA1184B(VA1184BModel VA1184BModel_P)
        {
            var program = new VA1184B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA1300B")]
        public IActionResult VA1300B(VA1300BModel VA1300BModel_P)
        {
            var program = new VA1300B();
            var result = program.Execute(VA1300BModel_P.SORTWK01, VA1300BModel_P.OUTROSBC, VA1300BModel_P.MV001313, VA1300BModel_P.RELAT);
            return Ok(result);
        }

        [HttpPost("VA1416B")]
        public IActionResult VA1416B(VA1416BModel VA1416BModel_P)
        {
            var program = new VA1416B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA1417B")]
        public IActionResult VA1417B(VA1417BModel VA1417BModel_P)
        {
            var program = new VA1417B();
            var result = program.Execute(VA1417BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VA1426B")]
        public IActionResult VA1426B(VA1426BModel VA1426BModel_P)
        {
            var program = new VA1426B();
            var result = program.Execute(VA1426BModel_P.RVA1426B, VA1426BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA1466B")]
        public IActionResult VA1466B(VA1466BModel VA1466BModel_P)
        {
            var program = new VA1466B();
            var result = program.Execute(VA1466BModel_P.SORTWK01, VA1466BModel_P.AVA1466B, VA1466BModel_P.DVA1466B);
            return Ok(result);
        }

        [HttpPost("VA1471B")]
        public IActionResult VA1471B(VA1471BModel VA1471BModel_P)
        {
            var program = new VA1471B();
            var result = program.Execute(VA1471BModel_P.WPAR_PARAMETROS, VA1471BModel_P.DVA1471B, VA1471BModel_P.RVA1471B);
            return Ok(result);
        }

        [HttpPost("VA1473B")]
        public IActionResult VA1473B(VA1473BModel VA1473BModel_P)
        {
            var program = new VA1473B();
            var result = program.Execute(VA1473BModel_P.DVA1473B);
            return Ok(result);
        }

        [HttpPost("VA1474B")]
        public IActionResult VA1474B(VA1474BModel VA1474BModel_P)
        {
            var program = new VA1474B();
            var result = program.Execute(VA1474BModel_P.DVA1474B);
            return Ok(result);
        }

        [HttpPost("VA1476B")]
        public IActionResult VA1476B(VA1476BModel VA1476BModel_P)
        {
            var program = new VA1476B();
            var result = program.Execute(VA1476BModel_P.WPAR_PARAMETROS, VA1476BModel_P.MVA1476B, VA1476BModel_P.PVA1476B, VA1476BModel_P.RVA1476B, VA1476BModel_P.M1476BHM, VA1476BModel_P.P1476BHM, VA1476BModel_P.R1476BHM);
            return Ok(result);
        }

        [HttpPost("VA1813B")]
        public IActionResult VA1813B(VA1813BModel VA1813BModel_P)
        {
            var program = new VA1813B();
            var result = program.Execute(VA1813BModel_P.RETDEB, VA1813BModel_P.RETERR, VA1813BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA1815B")]
        public IActionResult VA1815B(VA1815BModel VA1815BModel_P)
        {
            var program = new VA1815B();
            var result = program.Execute(VA1815BModel_P.RETREL);
            return Ok(result);
        }

        [HttpPost("VA2139B")]
        public IActionResult VA2139B(VA2139BModel VA2139BModel_P)
        {
            var program = new VA2139B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA2417B")]
        public IActionResult VA2417B(VA2417BModel VA2417BModel_P)
        {
            var program = new VA2417B();
            var result = program.Execute(VA2417BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("VA2426B")]
        public IActionResult VA2426B(VA2426BModel VA2426BModel_P)
        {
            var program = new VA2426B();
            var result = program.Execute(VA2426BModel_P.RVA2426B, VA2426BModel_P.SORTWK01);
            return Ok(result);
        }

        [HttpPost("VA2513B")]
        public IActionResult VA2513B(VA2513BModel VA2513BModel_P)
        {
            var program = new VA2513B();
            var result = program.Execute(VA2513BModel_P.VA2513B1, VA2513BModel_P.SORTWK01, VA2513BModel_P.VA2513B2);
            return Ok(result);
        }

        [HttpPost("VA2601B")]
        public IActionResult VA2601B(VA2601BModel VA2601BModel_P)
        {
            var program = new VA2601B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA2646B")]
        public IActionResult VA2646B(VA2646BModel VA2646BModel_P)
        {
            var program = new VA2646B();
            var result = program.Execute(VA2646BModel_P.AVA2646B, VA2646BModel_P.RVA2646B);
            return Ok(result);
        }

        [HttpPost("VA2720B")]
        public IActionResult VA2720B(VA2720BModel VA2720BModel_P)
        {
            var program = new VA2720B();
            var result = program.Execute(VA2720BModel_P.AVA2720B);
            return Ok(result);
        }

        [HttpPost("VA2721B")]
        public IActionResult VA2721B(VA2721BModel VA2721BModel_P)
        {
            var program = new VA2721B();
            var result = program.Execute(VA2721BModel_P.AVA2721B);
            return Ok(result);
        }

        [HttpPost("VA2722B")]
        public IActionResult VA2722B(VA2722BModel VA2722BModel_P)
        {
            var program = new VA2722B();
            var result = program.Execute(VA2722BModel_P.AVA2722S);
            return Ok(result);
        }

        [HttpPost("VA3118B")]
        public IActionResult VA3118B(VA3118BModel VA3118BModel_P)
        {
            var program = new VA3118B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA3139B")]
        public IActionResult VA3139B(VA3139BModel VA3139BModel_P)
        {
            var program = new VA3139B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA3437B")]
        public IActionResult VA3437B(VA3437BModel VA3437BModel_P)
        {
            var program = new VA3437B();
            var result = program.Execute(VA3437BModel_P.LK_PARAMETROS, VA3437BModel_P.VA3437B1, VA3437BModel_P.SORTWK01, VA3437BModel_P.VA3437B2, VA3437BModel_P.VA3437B3, VA3437BModel_P.VA3437B4, VA3437BModel_P.VA3437H1, VA3437BModel_P.VA3437H2);
            return Ok(result);
        }

        [HttpPost("VA3811B")]
        public IActionResult VA3811B(VA3811BModel VA3811BModel_P)
        {
            var program = new VA3811B();
            var result = program.Execute(VA3811BModel_P.RETDEB, VA3811BModel_P.RVA3811B);
            return Ok(result);
        }

        [HttpPost("VA3812B")]
        public IActionResult VA3812B(VA3812BModel VA3812BModel_P)
        {
            var program = new VA3812B();
            var result = program.Execute(VA3812BModel_P.RETCRE, VA3812BModel_P.RVA3812B);
            return Ok(result);
        }

        [HttpPost("VA4002B")]
        public IActionResult VA4002B(VA4002BModel VA4002BModel_P)
        {
            var program = new VA4002B();
            var result = program.Execute(VA4002BModel_P.ARQSAI);
            return Ok(result);
        }

        [HttpPost("VA4004B")]
        public IActionResult VA4004B(VA4004BModel VA4004BModel_P)
        {
            var program = new VA4004B();
            var result = program.Execute(VA4004BModel_P.SORTWK01, VA4004BModel_P.AVA4004B, VA4004BModel_P.DVA4004B, VA4004BModel_P.DVA4004D, VA4004BModel_P.DVA4004S);
            return Ok(result);
        }

        [HttpPost("VA4437B")]
        public IActionResult VA4437B(VA4437BModel VA4437BModel_P)
        {
            var program = new VA4437B();
            var result = program.Execute(VA4437BModel_P.LK_PARAMETROS, VA4437BModel_P.SORTWK01, VA4437BModel_P.VA4437B1, VA4437BModel_P.VA4437B2, VA4437BModel_P.VA4437B3, VA4437BModel_P.VA4437B4);
            return Ok(result);
        }

        [HttpPost("VA4648B")]
        public IActionResult VA4648B(VA4648BModel VA4648BModel_P)
        {
            var program = new VA4648B();
            var result = program.Execute(VA4648BModel_P.PRPPAR, VA4648BModel_P.PRPDIS);
            return Ok(result);
        }

        [HttpPost("VA5419B")]
        public IActionResult VA5419B(VA5419BModel VA5419BModel_P)
        {
            var program = new VA5419B();
            var result = program.Execute(VA5419BModel_P.RVA5419B, VA5419BModel_P.FUND001I, VA5419BModel_P.FUND001C, VA5419BModel_P.FUND001R, VA5419BModel_P.FUND001A);
            return Ok(result);
        }

        [HttpPost("VA5421B")]
        public IActionResult VA5421B(VA5421BModel VA5421BModel_P)
        {
            var program = new VA5421B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA5437B")]
        public IActionResult VA5437B(VA5437BModel VA5437BModel_P)
        {
            var program = new VA5437B();
            var result = program.Execute(VA5437BModel_P.VA5437B1, VA5437BModel_P.SORTWK01, VA5437BModel_P.VA5437B2, VA5437BModel_P.VA5437B3, VA5437BModel_P.VA5437B4, VA5437BModel_P.VA5437H1, VA5437BModel_P.VA5437H2);
            return Ok(result);
        }

        [HttpPost("VA6005B")]
        public IActionResult VA6005B(VA6005BModel VA6005BModel_P)
        {
            var program = new VA6005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("VA6421B")]
        public IActionResult VA6421B(VA6421BModel VA6421BModel_P)
        {
            var program = new VA6421B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
