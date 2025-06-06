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
using static Code.GE0355S;

namespace FileTests.Test_DB
{
    [Collection("GE0355S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0355S_Tests_DB
    {

        [Fact]
        public static void GE0355S_Database()
        {
            var program = new GE0355S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.WS_DATA_VENCIMENTO.Value = "2020-01-01";
                program.R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}