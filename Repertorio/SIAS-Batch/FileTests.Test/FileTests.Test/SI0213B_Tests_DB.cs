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
using static Code.SI0213B;

namespace FileTests.Test_DB
{
    [Collection("SI0213B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0213B_Tests_DB
    {

        [Fact]
        public static void SI0213B_Database()
        {
            var program = new SI0213B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0300_00_LE_EMPRESAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/

                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2000-10-10";


                program.R0500_00_VERIFICA_DATA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0600_00_LE_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0650_00_CONTA_REPASSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0700_00_LE_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0800_00_EXCLUI_RELATORI_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0900_00_DECLARA_SINISHIS_DB_DECLARE_1(); program.R0900_00_DECLARA_SINISHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2900_00_DECLARA_SINISHIS_DB_DECLARE_1(); program.R2900_00_DECLARA_SINISHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1110_00_MAX_FIPADOFI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1120_00_INCLUI_FIPADOFI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1210_00_LE_SINNUMLO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1220_00_INCLUI_SINNUMLO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                
                program.SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_TIMESTAMP.Value = "1995-09-12 20:32:44.821";


                program.R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                //foreign key
                program.R1240_00_INCLUI_SINISCAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1300_00_ALTERA_SINISCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2100_00_LE_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2200_00_INCLUI_SINISLAN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2300_00_ALTERA_SINISHIS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2400_00_LE_SINIITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2500_00_LE_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2500_00_LE_SINISHIS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2600_00_LE_SINCREIN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2700_00_LE_SINIHAB1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R4500_00_LE_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R4500_00_LE_SINISHIS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}