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
using static Code.EF0100S;

namespace FileTests.Test_DB
{
    [Collection("EF0100S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class EF0100S_Tests_DB
    {

        [Fact]
        public static void EF0100S_Database()
        {
            var program = new EF0100S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.D0000_PROCESSAMENTO_DB2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}