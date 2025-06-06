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
using static Code.SI0200B;

namespace FileTests.Test_DB
{
    [Collection("SI0200B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0200B_Tests_DB
    {

        [Fact]
        public static void SI0200B_Database()
        {
            var program = new SI0200B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_000_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_000_00_DELETE_V0RELATORIO_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/

                program.V0RELA_DATA_REFER.Value = "2000-10-10";
                program.V0RELA_DT_SOLIC.Value = "2000-10-10";
                program.V0RELA_PERI_INIC.Value = "2000-10-10";
                program.V0RELA_PERI_FINAL.Value = "2000-10-10";

                program.R0500_00_INSERT_V0RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}