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
using static Code.SI0900B;

namespace FileTests.Test_DB
{
    [Collection("SI0900B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0900B_Tests_DB
    {

        [Fact]
        public static void SI0900B_Database()
        {
            var program = new SI0900B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.V0SISTEMA_DTULTPCS.Value = "2020-01-01";
                program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.V0SISTEMA_DTULTPCS.Value = "2020-01-01";
                program.Execute_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}