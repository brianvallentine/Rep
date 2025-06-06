
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Outros.Model;
using IA_ConverterCommons;
using static Code.CI0500S;
using Code;

namespace Sias.Outros
{
    [ApiController]
    [Route("Outros")]
    public class OutrosController : ControllerBase
    {

        [HttpPost("CI0500S")]
        public IActionResult CI0500S(CI0500SModel CI0500SModel_P)
        {
            var program = new CI0500S();
            var result = program.Execute(CI0500SModel_P.LK_AREA_LINK);
            return Ok(result);
        }

        [HttpPost("CS0701S")]
        public IActionResult CS0701S(CS0701SModel CS0701SModel_P)
        {
            var program = new CS0701S();
            var result = program.Execute(CS0701SModel_P.CS0701S_AREA_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("CS1164B")]
        public IActionResult CS1164B(CS1164BModel CS1164BModel_P)
        {
            var program = new CS1164B();
            var result = program.Execute(CS1164BModel_P.CS1164B1);
            return Ok(result);
        }

        [HttpPost("CS1301B")]
        public IActionResult CS1301B(CS1301BModel CS1301BModel_P)
        {
            var program = new CS1301B();
            var result = program.Execute(CS1301BModel_P.CS1301BO);
            return Ok(result);
        }

        [HttpPost("CT0006S")]
        public IActionResult CT0006S(CT0006SModel CT0006SModel_P)
        {
            var program = new CT0006S();
            var result = program.Execute(CT0006SModel_P.CT0006S_LINKAGE);
            return Ok(result);
        }

        [HttpPost("CT0007S")]
        public IActionResult CT0007S(CT0007SModel CT0007SModel_P)
        {
            var program = new CT0007S();
            var result = program.Execute(CT0007SModel_P.WS_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("EF0100S")]
        public IActionResult EF0100S(EF0100SModel EF0100SModel_P)
        {
            var program = new EF0100S();
            var result = program.Execute(EF0100SModel_P.LS_V0HABIT4_NUM_FIAP, EF0100SModel_P.LS_V0MEST_DATORR, EF0100SModel_P.LS_V0END_COD_CLIENTE, EF0100SModel_P.LS_V0END_ENDER_IMOVEL, EF0100SModel_P.LS_V0END_NUM_IMOVEL, EF0100SModel_P.LS_V0END_COMPL_IMOVEL, EF0100SModel_P.LS_V0END_BAIRRO_IMOVEL, EF0100SModel_P.LS_V0END_CIDADE_IMOVEL, EF0100SModel_P.LS_V0END_UF_IMOVEL, EF0100SModel_P.LS_V0END_CEP_IMOVEL, EF0100SModel_P.LS_SQLCODE);
            return Ok(result);
        }

        [HttpPost("EF0101S")]
        public IActionResult EF0101S(EF0101SModel EF0101SModel_P)
        {
            var program = new EF0101S();
            var result = program.Execute(EF0101SModel_P.LS_V0HAB01_NUM_CONTRATO, EF0101SModel_P.LS_SINI_DATORR, EF0101SModel_P.LS_V0CONT_DATA_CONTRATO, EF0101SModel_P.LS_V0CONT_PRZ_VIGENCIA, EF0101SModel_P.LS_SQLCODE);
            return Ok(result);
        }

        [HttpPost("EF0102S")]
        public IActionResult EF0102S(EF0102SModel EF0102SModel_P)
        {
            var program = new EF0102S();
            var result = program.Execute(EF0102SModel_P.LS_V0HAB01_NUM_CONTRATO, EF0102SModel_P.LS_SINI_DATORR, EF0102SModel_P.LS_SQLCODE, EF0102SModel_P.LS_V0SEGU_NOME_SEGURADO);
            return Ok(result);
        }

        [HttpPost("EF148S")]
        public IActionResult EF148S(EF148SModel EF148SModel_P)
        {
            var program = new EF148S();
            var result = program.Execute(EF148SModel_P.LINKAGE_EF148S);
            return Ok(result);
        }

        [HttpPost("FI0100S")]
        public IActionResult FI0100S(FI0100SModel FI0100SModel_P)
        {
            var program = new FI0100S();
            var result = program.Execute(FI0100SModel_P.LK_IMPOSTOS);
            return Ok(result);
        }

        [HttpPost("FN0301B")]
        public IActionResult FN0301B(FN0301BModel FN0301BModel_P)
        {
            var program = new FN0301B();
            var result = program.Execute(FN0301BModel_P.FENPANA, FN0301BModel_P.FENEMIS, FN0301BModel_P.FENAUTO, FN0301BModel_P.FENAUT1, FN0301BModel_P.FENVIDA, FN0301BModel_P.FENOUTR, FN0301BModel_P.FENPARC, FN0301BModel_P.FENCOMI, FN0301BModel_P.FENCOSS, FN0301BModel_P.FENRESS);
            return Ok(result);
        }

        [HttpPost("FN0303B")]
        public IActionResult FN0303B(FN0303BModel FN0303BModel_P)
        {
            var program = new FN0303B();
            var result = program.Execute(FN0303BModel_P.MVFN0303);
            return Ok(result);
        }

        [HttpPost("FC0001S")]
        public IActionResult FC0001S(FC0001SModel FC0001SModel_P)
        {
            var program = new FC0001S();
            var result = program.Execute(FC0001SModel_P.LK_IN_COD_CPF, FC0001SModel_P.LK_OUT_COD_CPF, FC0001SModel_P.LK_OUT_COD_RETORNO, FC0001SModel_P.LK_OUT_MENSAGEM);
            return Ok(result);
        }

        [HttpPost("FC0038B")]
        public IActionResult FC0038B(FC0038BModel FC0038BModel_P)
        {
            var program = new FC0038B();
            var result = program.Execute(FC0038BModel_P.PARAM, FC0038BModel_P.IFC0038B, FC0038BModel_P.RFC038B1, FC0038BModel_P.RFC038B2, FC0038BModel_P.CEPERROS);
            return Ok(result);
        }

        [HttpPost("FC0105B")]
        public IActionResult FC0105B(FC0105BModel FC0105BModel_P)
        {
            var program = new FC0105B();
            var result = program.Execute(FC0105BModel_P.LK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("FC0105S")]
        public IActionResult FC0105S(FC0105SModel FC0105SModel_P)
        {
            var program = new FC0105S();
            var result = program.Execute(FC0105SModel_P.LK_NUM_PLANO, FC0105SModel_P.LK_NUM_SERIE, FC0105SModel_P.LK_NUM_TITULO, FC0105SModel_P.LK_NUM_PROPOSTA, FC0105SModel_P.LK_QTD_TITULOS, FC0105SModel_P.LK_VLR_TITULO, FC0105SModel_P.LK_EMP_PARCEIRA, FC0105SModel_P.LK_COD_RAMO, FC0105SModel_P.LK_NUM_NSA, FC0105SModel_P.LK_TRACE, FC0105SModel_P.LK_OUT_COD_RETORNO, FC0105SModel_P.LK_OUT_SQLCODE, FC0105SModel_P.LK_OUT_MENSAGEM, FC0105SModel_P.LK_OUT_SQLERRMC, FC0105SModel_P.LK_OUT_SQLSTATE);
            return Ok(result);
        }

        [HttpPost("FC1111S")]
        public IActionResult FC1111S(FC1111SModel FC1111SModel_P)
        {
            var program = new FC1111S();
            var result = program.Execute(FC1111SModel_P.REGISTRO_LINKAGE);
            return Ok(result);
        }

        [HttpPost("FC1112S")]
        public IActionResult FC1112S(FC1112SModel FC1112SModel_P)
        {
            var program = new FC1112S();
            var result = program.Execute(FC1112SModel_P.REGISTRO_LINKAFC);
            return Ok(result);
        }

        [HttpPost("FI0007B")]
        public IActionResult FI0007B(FI0007BModel FI0007BModel_P)
        {
            var program = new FI0007B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("PR0100B")]
        public IActionResult PR0100B(PR0100BModel PR0100BModel_P)
        {
            var program = new PR0100B();
            var result = program.Execute(PR0100BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("PROALN01")]
        public IActionResult PROALN01(PROALN01Model PROALN01Model_P)
        {
            var program = new PROALN01();
            var result = program.Execute(PROALN01Model_P.AREA_DE_LINK);
            return Ok(result);
        }

        [HttpPost("PROCBR01")]
        public IActionResult PROCBR01(PROCBR01Model PROCBR01Model_P)
        {
            var program = new PROCBR01();
            var result = program.Execute(PROCBR01Model_P.LINK_AREA);
            return Ok(result);
        }

        [HttpPost("PROCNPJ2")]
        public IActionResult PROCNPJ2(PROCNPJ2Model PROCNPJ2Model_P)
        {
            var program = new PROCNPJ2();
            var result = program.Execute(PROCNPJ2Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PROCONC1")]
        public IActionResult PROCONC1(PROCONC1Model PROCONC1Model_P)
        {
            var program = new PROCONC1();
            var result = program.Execute(PROCONC1Model_P.LPARM01);
            return Ok(result);
        }

        [HttpPost("PROCONV")]
        public IActionResult PROCONV(PROCONVModel PROCONVModel_P)
        {
            var program = new PROCONV();
            var result = program.Execute(PROCONVModel_P.LK_CONVERSAO);
            return Ok(result);
        }

        [HttpPost("PROCPF01")]
        public IActionResult PROCPF01(PROCPF01Model PROCPF01Model_P)
        {
            var program = new PROCPF01();
            var result = program.Execute(PROCPF01Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PROCPF02")]
        public IActionResult PROCPF02(PROCPF02Model PROCPF02Model_P)
        {
            var program = new PROCPF02();
            var result = program.Execute(PROCPF02Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PRODIFC1")]
        public IActionResult PRODIFC1(PRODIFC1Model PRODIFC1Model_P)
        {
            var program = new PRODIFC1();
            var result = program.Execute(PRODIFC1Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PRODIFD2")]
        public IActionResult PRODIFD2(PRODIFD2Model PRODIFD2Model_P)
        {
            var program = new PRODIFD2();
            var result = program.Execute(PRODIFD2Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PRODIG11")]
        public IActionResult PRODIG11(PRODIG11Model PRODIG11Model_P)
        {
            var program = new PRODIG11();
            var result = program.Execute(PRODIG11Model_P.LPARM01, PRODIG11Model_P.LPARM03);
            return Ok(result);
        }

        [HttpPost("PRODIGCX")]
        public IActionResult PRODIGCX(PRODIGCXModel PRODIGCXModel_P)
        {
            var program = new PRODIGCX();
            var result = program.Execute(PRODIGCXModel_P.LPARM01, PRODIGCXModel_P.LPARM03);
            return Ok(result);
        }

        [HttpPost("PROM1101")]
        public IActionResult PROM1101(PROM1101Model PROM1101Model_P)
        {
            var program = new PROM1101();
            var result = program.Execute(PROM1101Model_P.LPARM01X);
            return Ok(result);
        }

        [HttpPost("PROM1102")]
        public IActionResult PROM1102(PROM1102Model PROM1102Model_P)
        {
            var program = new PROM1102();
            var result = program.Execute(PROM1102Model_P.LPARM01X);
            return Ok(result);
        }

        [HttpPost("PROM11CF")]
        public IActionResult PROM11CF(PROM11CFModel PROM11CFModel_P)
        {
            var program = new PROM11CF();
            var result = program.Execute(PROM11CFModel_P.LPARM01X);
            return Ok(result);
        }

        [HttpPost("PROSOCU1")]
        public IActionResult PROSOCU1(PROSOCU1Model PROSOCU1Model_P)
        {
            var program = new PROSOCU1();
            var result = program.Execute(PROSOCU1Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PROSOCU2")]
        public IActionResult PROSOCU2(PROSOCU2Model PROSOCU2Model_P)
        {
            var program = new PROSOCU2();
            var result = program.Execute(PROSOCU2Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PROSOMC1")]
        public IActionResult PROSOMC1(PROSOMC1Model PROSOMC1Model_P)
        {
            var program = new PROSOMC1();
            var result = program.Execute(PROSOMC1Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PROTIT01")]
        public IActionResult PROTIT01(PROTIT01Model PROTIT01Model_P)
        {
            var program = new PROTIT01();
            var result = program.Execute(PROTIT01Model_P.LPARM01X);
            return Ok(result);
        }

        [HttpPost("PROVERC1")]
        public IActionResult PROVERC1(PROVERC1Model PROVERC1Model_P)
        {
            var program = new PROVERC1();
            var result = program.Execute(PROVERC1Model_P.LPARM);
            return Ok(result);
        }

        [HttpPost("PTACOM2S")]
        public IActionResult PTACOM2S(PTACOM2SModel PTACOM2SModel_P)
        {
            var program = new PTACOM2S();
            var result = program.Execute(PTACOM2SModel_P.PROTOCOLO_RECEBIDO, PTACOM2SModel_P.DCLSI_DOCUMENTO_ACOMP, PTACOM2SModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("PTACOMOS")]
        public IActionResult PTACOMOS(PTACOMOSModel PTACOMOSModel_P)
        {
            var program = new PTACOMOS();
            var result = program.Execute(PTACOMOSModel_P.PROTOCOLO_RECEBIDO, PTACOMOSModel_P.DCLSI_SINISTRO_ACOMP, PTACOMOSModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("PTACOMPS")]
        public IActionResult PTACOMPS(PTACOMPSModel PTACOMPSModel_P)
        {
            var program = new PTACOMPS();
            var result = program.Execute(PTACOMPSModel_P.PROTOCOLO_RECEBIDO, PTACOMPSModel_P.DCLGE_CARTA_ACOMP, PTACOMPSModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("PTCARTAS")]
        public IActionResult PTCARTAS(PTCARTASModel PTCARTASModel_P)
        {
            var program = new PTCARTAS();
            var result = program.Execute(PTCARTASModel_P.PROTOCOLO_RECEBIDO, PTCARTASModel_P.DCLGE_CARTA, PTCARTASModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("PTFASESS")]
        public IActionResult PTFASESS(PTFASESSModel PTFASESSModel_P)
        {
            var program = new PTFASESS();
            var result = program.Execute(PTFASESSModel_P.PROTOCOLO_RECEBIDO, PTFASESSModel_P.DCLSI_SINISTRO_FASE, PTFASESSModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("PTTEXTOS")]
        public IActionResult PTTEXTOS(PTTEXTOSModel PTTEXTOSModel_P)
        {
            var program = new PTTEXTOS();
            var result = program.Execute(PTTEXTOSModel_P.PROTOCOLO_RECEBIDO, PTTEXTOSModel_P.DCLGE_CARTA_TEXTO, PTTEXTOSModel_P.PROTOCOLO_ENVIO);
            return Ok(result);
        }

        [HttpPost("RE0001S")]
        public IActionResult RE0001S(RE0001SModel RE0001SModel_P)
        {
            var program = new RE0001S();
            var result = program.Execute(RE0001SModel_P.LK_RE0001S);
            return Ok(result);
        }

        [HttpPost("RE0002S")]
        public IActionResult RE0002S(RE0002SModel RE0002SModel_P)
        {
            var program = new RE0002S();
            var result = program.Execute(RE0002SModel_P.LK_RE0002S);
            return Ok(result);
        }

        [HttpPost("RG0805B")]
        public IActionResult RG0805B(RG0805BModel RG0805BModel_P)
        {
            var program = new RG0805B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("RSGESSTR")]
        public IActionResult RSGESSTR(RSGESSTRModel RSGESSTRModel_P)
        {
            var program = new RSGESSTR();
            var result = program.Execute(RSGESSTRModel_P.RSGEWSTR);
            return Ok(result);
        }

        [HttpPost("RSGESVDT")]
        public IActionResult RSGESVDT(RSGESVDTModel RSGESVDTModel_P)
        {
            var program = new RSGESVDT();
            var result = program.Execute(RSGESVDTModel_P.RSGEWVDT);
            return Ok(result);
        }

        [HttpPost("PR0011B")]
        public IActionResult PR0011B(PR0011BModel PR0011BModel_P)
        {
            var program = new PR0011B();
            var result = program.Execute(PR0011BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SPBFC003")]
        public IActionResult SPBFC003(SPBFC003Model SPBFC003Model_P)
        {
            var program = new SPBFC003();
            var result = program.Execute(SPBFC003Model_P.LK_IN_COD_SEQ, SPBFC003Model_P.LK_IN_QTD_SEQ, SPBFC003Model_P.LK_OUT_NUM_SEQ_INI, SPBFC003Model_P.LK_OUT_NUM_SEQ_FIM, SPBFC003Model_P.LK_OUT_COD_RETORNO, SPBFC003Model_P.LK_OUT_SQLCODE, SPBFC003Model_P.LK_OUT_MENSAGEM, SPBFC003Model_P.LK_OUT_SQLERRMC, SPBFC003Model_P.LK_OUT_SQLSTATE);
            return Ok(result);
        }

        [HttpPost("SPBGE053")]
        public IActionResult SPBGE053(SPBGE053Model SPBGE053Model_P)
        {
            var program = new SPBGE053();
            var result = program.Execute(SPBGE053Model_P.SPGE053W);
            return Ok(result);
        }

        [HttpPost("SPBVG001")]
        public IActionResult SPBVG001(SPBVG001Model SPBVG001Model_P)
        {
            var program = new SPBVG001();
            var result = program.Execute(SPBVG001Model_P.SPVG001W);
            return Ok(result);
        }

        [HttpPost("SPBVG009")]
        public IActionResult SPBVG009(SPBVG009Model SPBVG009Model_P)
        {
            var program = new SPBVG009();
            var result = program.Execute(SPBVG009Model_P.SPVG009W);
            return Ok(result);
        }

        [HttpPost("SPBVG011")]
        public IActionResult SPBVG011(SPBVG011Model SPBVG011Model_P)
        {
            var program = new SPBVG011();
            var result = program.Execute(SPBVG011Model_P.SPVG011W);
            return Ok(result);
        }

        [HttpPost("SPBVG013")]
        public IActionResult SPBVG013(SPBVG013Model SPBVG013Model_P)
        {
            var program = new SPBVG013();
            var result = program.Execute(SPBVG013Model_P.SPVG013W, SPBVG013Model_P.LBHCT002);
            return Ok(result);
        }

        [HttpPost("SPBVG015")]
        public IActionResult SPBVG015(SPBVG015Model SPBVG015Model_P)
        {
            var program = new SPBVG015();
            var result = program.Execute(SPBVG015Model_P.SPVG015W);
            return Ok(result);
        }

        [HttpPost("SPBVG017")]
        public IActionResult SPBVG017(SPBVG017Model SPBVG017Model_P)
        {
            var program = new SPBVG017();
            var result = program.Execute(SPBVG017Model_P.SPVG017W);
            return Ok(result);
        }

    }
}
