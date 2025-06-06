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
using static Code.CS0701S;

namespace FileTests.Test_DB
{
    [Collection("CS0701S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CS0701S_Tests_DB
    {

        [Fact]
        public static void CS0701S_Database()
        {
            var program = new CS0701S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.WS_DTINIVIG_PROPOSTA.Value = "2000-10-10";
            try { /*1*/ program.R1100_00_CONSULTA_GERAL_DB_DECLARE_1(); program.R1100_00_CONSULTA_GERAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}