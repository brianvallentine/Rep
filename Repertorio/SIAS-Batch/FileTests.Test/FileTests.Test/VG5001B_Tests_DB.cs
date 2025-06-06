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
using static Code.VG5001B;

namespace FileTests.Test_DB
{
    [Collection("VG5001B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG5001B_Tests_DB
    {

        [Fact]
        public static void VG5001B_Database()
        {
            var program = new VG5001B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_050_000_DECLARA_RELATORIO_DB_DECLARE_1(); program.M_050_000_DECLARA_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1(); program.M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}