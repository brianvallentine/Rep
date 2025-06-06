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
using static Code.VG1139B;

namespace FileTests.Test_DB
{
    [Collection("VG1139B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1139B_Tests_DB
    {

        [Fact]
        public static void VG1139B_Database()
        {
            var program = new VG1139B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_DECLARE_1(); program.R0000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0910_00_FETCH_HCTBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.V0ENDO_DATPRO.Value = "2024-12-10";
                program.V0ENDO_DT_LIBER.Value = "2024-12-10";
                program.V0ENDO_DTEMIS.Value = "2024-12-10";
                program.V0ENDO_DTINIVIG.Value = "2024-12-09";
                program.V0ENDO_DTTERVIG.Value = "2024-12-10";
                program.V0ENDO_DATARCAP.Value = "2024-12-10";
                program.V0ENDO_DTVENCTO.Value = "2024-12-10";
                program.R1000_10_LOOP_PROPAUTOM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1000_10_LOOP_PROPAUTOM_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1100_00_ACUMULA_PREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1100_00_ACUMULA_PREMIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1102_00_SELECT_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*26*/
                program.V1RIND_DTINIVIG.Value = "2024-12-10";
                program.R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_12(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1110_00_VERIFICA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1110_00_VERIFICA_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1110_00_VERIFICA_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1110_00_VERIFICA_RCAP_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1(); program.R1300_00_GRAVA_COSSEGURO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*33*/
                program.V1RCAC_HORAOPER.Value = "00:00:00";
                program.V1RCAC_DTMOVTO.Value = "2024-12-10";
                program.R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*34*/
                program.V1SIST_DTMOVACB.Value = "2024-12-10";
                program.V1RCAC_DTCADAST.Value = "2024-12-10";
                program.R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R1210_00_ACUMULA_IS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*40*/
                program.V0HISP_DTMOVTO.Value = "2024-12-10";
                program.V0HISP_DTVENCTO.Value = "2024-12-10";
                program.V0HISP_DTQITBCO.Value = "2024-12-10";

                program.R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1480_00_UPDATE_V0RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*42*/
                program.V0COBA_DATA_INIVI.Value = "2024-12-09";
                program.V0COBA_DATA_TERVI.Value = "2024-12-10";
                program.R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*43*/
                program.V0EDIA_DTMOVTO.Value = "2024-12-10";
                program.R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}