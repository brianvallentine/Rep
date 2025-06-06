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
using Code;
using static Code.PF0711B;

namespace FileTests.Test_DB
{
    [Collection("PF0711B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PF0711B_Tests_DB
    {
        private static string pData = "2022-01-01";

        [Fact]
        public static void PF0711B_Database()
        {
            var program = new PF0711B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_VALIDAR_CONVENIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.Value = pData;
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.Value = pData;
                program.R0250_00_TRATA_EMPRESA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = pData;
                program.R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/ program.R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0330_00_ATUALIZAR_IOF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = pData;
                program.R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO.Value = pData;
                program.RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.Value = pData;
                program.R0763_00_LER_RCAP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*14*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = pData;
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = pData;
                program.R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R2100_00_TB_CONTROLE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}