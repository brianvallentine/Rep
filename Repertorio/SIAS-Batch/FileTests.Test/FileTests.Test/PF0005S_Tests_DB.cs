using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Dclgens;
using Code;
using static Code.PF0005S;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("PF0005S_Tests_DB")]
    public class PF0005S_Tests_DB
    {

        [Fact]
        public static void PF0005S_Database()
        {
            var program = new PF0005S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.P0050_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.Value = 1;
                program.P0110_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.PFMOTPRO.DCLPF_MOTIVO_PROPOSTA.PFMOTPRO_SIT_MOTIVO_SIVPF.Value = 1;
                program.P0111_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO.Value = "2020-01-01";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA.Value = "X";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF.Value = 1;
                program.P0401_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_IDENTIFICACAO.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DATA_SITUACAO.Value = "2020-01-01";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSAS_SIVPF.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NSL.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_PROPOSTA.Value = "X";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF.Value = "X";
                program.NU006_SIT_COBRANCA_SIVPF.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_MOTIVO_SIVPF.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_EMPRESA_SIVPF.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_PRODUTO_SIVPF.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_ACAO.Value = "x";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_TP_SENSIBILIZACAO.Value = "x";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_IND_ENVIO.Value = "x";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_INI_VIGENCIA.Value = "2020-01-01";
                program.NU006_DTA_INI_VIGENCIA.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_FIM_VIGENCIA.Value = "2020-01-01";
                program.NU006_DTA_FIM_VIGENCIA.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NUM_PARCELA.Value = 1;
                program.NU006_NUM_PARCELA.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_TP_LANCAMENTO.Value = 1;
                program.NU006_COD_TP_LANCAMENTO.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_VLR_PREMIO.Value = 1;
                program.NU006_VLR_PREMIO.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_ERRO.Value = 1;
                program.NU006_COD_ERRO.Value = 1;
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_COD_USUARIO.Value = "x";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_NOM_PROGRAMA.Value ="x";
                program.HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_DTA_PROCESSAMENTO_CEF.Value = "2020-01-01";
                program.NU006_DTA_PROCESSAMENTO_CEF.Value = 1;

                program.P8000_05_INICIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}