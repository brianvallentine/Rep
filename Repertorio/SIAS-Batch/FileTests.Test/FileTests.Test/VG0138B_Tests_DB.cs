using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0138B;

namespace FileTests.Test_DB
{
    [Collection("VG0138B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VG0138B_Tests_DB
    {

        [Fact]
        public static void VG0138B_Database()
        {
            var program = new VG0138B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDateMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var yearMock = DateTime.Now.AddDays(-100).Year;

            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_DECLARE_1(); program.R0000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.V0ENDO_DTINIVIG.Value = fullDateMock;

                program.R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();
                program.R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0910_00_FETCH_HCTBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.V0ENDO_DATPRO.Value = fullDateMock;
                program.V0ENDO_DT_LIBER.Value = fullDateMock;
                program.V0ENDO_DTEMIS.Value = fullDateMock;
                program.V0ENDO_DACRCAP.Value = fullDateMock;
                program.V0ENDO_DTINIVIG.Value = fullDateMock;
                program.V0ENDO_DTTERVIG.Value = fullDateMock;
                program.V0ENDO_DATARCAP.Value = fullDateMock;
                program.VIND_DATARCAP.Value = yearMock;
                program.V0ENDO_DTVENCTO.Value = fullDateMock;
                program.VIND_DTVENCTO.Value = yearMock;

                program.R1000_10_LOOP_PROPAUTOM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_10_LOOP_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1000_10_LOOP_PROPAUTOM_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1100_00_ACUMULA_PREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1100_00_ACUMULA_PREMIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.V1RIND_DTINIVIG.Value = fullDateMock;

                program.R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.V0PARC_DTVENCTO.Value = fullDateMock;

                program.R1210_00_ACUMULA_IS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*26*/

                program.V0HISP_DTMOVTO.Value = fullDateMock;
                program.V0HISP_DTVENCTO.Value = fullDateMock;
                program.V0HISP_DTQITBCO.Value = fullDateMock;
                program.VIND_DTQITBCO.Value = yearMock;

                program.R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*27*/
                program.V0COBA_DATA_TERVI.Value = fullDateMock;
                program.V0COBA_DATA_INIVI.Value = fullDateMock;
                program.V0COBA_DATA_TERVI.Value = fullDateMock;

                program.R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*28*/
                program.V0EDIA_DTMOVTO.Value = fullDateMock;

                program.R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}