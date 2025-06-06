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
using static Code.PRODIFD2;

namespace FileTests.Test_DB
{
    [Collection("PRODIFD2_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class PRODIFD2_Tests_DB
    {  
        [Fact]
        public static void PRODIFD2_Database()
        {
            var program = new PRODIFD2();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

        }
    }
}