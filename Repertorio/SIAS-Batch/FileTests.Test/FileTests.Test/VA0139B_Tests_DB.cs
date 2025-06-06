using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VA0139B;

namespace FileTests.Test_DB
{
    [Collection("VA0139B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VA0139B_Tests_DB
    {

        [Fact]
        public static void VA0139B_Database()
        {
            var program = new VA0139B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var monthMock = DateTime.Now.AddDays(-100).Month;
            var yearMock = DateTime.Now.AddDays(-100).Month;
            var hourMock = DateTime.Now.AddDays(-100).ToString("HH:mm:ss");

            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_DECLARE_1(); program.R0000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_CURSOR_DB_DECLARE_1(); program.R0900_00_DECLARE_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.V0RELA_DATA_SOLICITACAO.Value = fullDataMock;
                program.V0RELA_PERI_INICIAL.Value = fullDataMock;
                program.V0RELA_PERI_FINAL.Value = fullDataMock;
                program.V0RELA_DATA_REFERENCIA.Value = fullDataMock;
                program.V0RELA_MES_REFERENCIA.Value = monthMock;
                program.V0RELA_ANO_REFERENCIA.Value = yearMock;

                program.R0000_00_PRINCIPAL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0000_00_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0915_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0916_00_SELECT_PRODUVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0930_00_SELECT_HCTBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0940_00_SELECT_HCTBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.V0ENDO_DTINIVIG.Value = fullDataMock;

                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.V0ENDO_DT_LIBER.Value = fullDataMock;
                program.V0ENDO_DATPRO.Value = fullDataMock;
                program.V0ENDO_DTEMIS.Value = fullDataMock;
                program.V0ENDO_DTINIVIG.Value = fullDataMock;
                program.V0ENDO_DTTERVIG.Value = fullDataMock;
                program.V0ENDO_DTVENCTO.Value = fullDataMock;
                program.V0ENDO_DATARCAP.Value = fullDataMock;
                program.VIND_DTVENCTO.Value = yearMock;
                program.VIND_DATARCAP.Value = yearMock;

                program.R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1102_00_SELECT_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1102_00_SELECT_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1102_00_SELECT_RCAP_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*27*/
                program.V1RIND_DTINIVIG.Value = fullDataMock;

                program.R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1109_00_CALCULA_RTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1110_00_VERIFICA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1110_00_VERIFICA_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1110_00_VERIFICA_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1110_00_VERIFICA_RCAP_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1110_00_VERIFICA_RCAP_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1(); program.R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*36*/
                program.V1RCAC_DTMOVTO.Value = fullDataMock;
                program.V1RCAC_HORAOPER.Value = hourMock;

                program.R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*37*/
                program.V1SIST_DTMOVACB.Value = fullDataMock;
                program.V1RCAC_DATARCAP.Value = fullDataMock;
                program.V1RCAC_DTCADAST.Value = fullDataMock;

                program.R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1(); program.R1300_00_GRAVA_COSSEGURO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R1220_00_LE_PREMIO_DIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1225_00_LE_PREMIO_DIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*46*/
                program.V0HISP_DTMOVTO.Value = fullDataMock;
                program.V0HISP_DTVENCTO.Value = fullDataMock;
                program.V0HISP_DTQITBCO.Value = fullDataMock;
                program.VIND_DTQITBCO.Value = yearMock;

                program.R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*47*/
                program.V0COBA_DATA_INIVI.Value = fullDataMock;
                program.V0COBA_DATA_TERVI.Value = fullDataMock;

                program.R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*48*/
                program.V0EDIA_DTMOVTO.Value = fullDataMock;

                program.R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}