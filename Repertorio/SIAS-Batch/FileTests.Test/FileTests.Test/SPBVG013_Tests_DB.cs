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
using static Code.SPBVG013;

namespace FileTests.Test_DB
{
    [Collection("SPBVG013_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SPBVG013_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void SPBVG013_Database()
        {
            var program = new SPBVG013();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.P0050_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.VG135.DCLVG_ACOPLADO.VG135_DTA_MOVIMENTO.Value = pData;
                program.VG135.DCLVG_ACOPLADO.VG135_DTH_CADASTRAMENTO.Value = pData;
                program.P0200_05_INICIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P0210_05_INICIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.P0250_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.VG137.DCLVG_ACOPLADO_HIST.VG137_DTH_CADASTRAMENTO.Value = pData;
                program.VG137.DCLVG_ACOPLADO_HIST.VG137_DTA_MOVIMENTO.Value = pData;
                program.P0300_05_INICIO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/

                program.VG139.DCLVG_ACOPLADO_ERRO.VG139_DTH_CADASTRAMENTO.Value = pData;
                program.P0400_05_INICIO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.P0460_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.P0540_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.P0851_01_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}