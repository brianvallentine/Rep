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
using static Code.VA0133B;

namespace FileTests.Test_DB
{

    [Collection("VA0133B_Tests_DB")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0133B_Tests_DB
    {

        [Fact]
        public static void VA0133B_Database()
        {
            var program = new VA0133B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try
            { /*1*/
                program.WS_DTPARM.Value = "2023-01-01";
                program.P1000_INICIALIZA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}