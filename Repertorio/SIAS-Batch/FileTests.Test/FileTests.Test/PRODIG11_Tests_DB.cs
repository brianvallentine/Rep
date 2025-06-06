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
using static Code.PRODIG11;

namespace FileTests.Test_DB
{
    [Collection("PRODIG11_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PRODIG11_Tests_DB
    {

        [Fact]
        public static void PRODIG11_Database()
        {
            var program = new PRODIG11();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

        }
    }
}