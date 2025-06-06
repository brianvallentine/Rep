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
using static Code.LT3150S;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("LT3150S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3150S_Tests_DB
    {

        [Fact]
        public static void LT3150S_Database()
        {
            var program = new LT3150S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.Value = "2025-03-10";
                program.R0300_00_LER_TAXA_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.Value = "2025-03-10";
                program.R0400_00_LER_COEF_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}