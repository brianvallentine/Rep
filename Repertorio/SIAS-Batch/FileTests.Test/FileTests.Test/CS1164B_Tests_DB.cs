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
using static Code.CS1164B;

namespace FileTests.Test_DB
{
    [Collection("CS1164B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CS1164B_Tests_DB
    {

        [Fact]
        public static void CS1164B_Database()
        {
            var program = new CS1164B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/
                program.WHOST_DATA_10DIAS.Value = "2020-01-01";
                program.R1300_00_OPEN_CURS01_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1200_00_SELECT_EMPRESAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}