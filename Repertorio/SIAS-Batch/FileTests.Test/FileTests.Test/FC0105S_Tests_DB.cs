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
using static Code.FC0105S;

namespace FileTests.Test_DB
{
    [Collection("FC0105S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class FC0105S_Tests_DB
    {

        [Fact]
        public static void FC0105S_Database()
        {
            var program = new FC0105S();
            program.W77_NUM_NSA.Value = "2000-10-10";
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.P000_PRINCIPAL_DB_CALL_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}