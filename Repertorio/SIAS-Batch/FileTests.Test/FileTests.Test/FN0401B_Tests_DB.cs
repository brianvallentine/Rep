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
using static Code.FN0401B;

namespace FileTests.Test_DB
{
    [Collection("FN0401B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class FN0401B_Tests_DB
    {

        [Fact]
        public static void FN0401B_Database()
        {
            var program = new FN0401B();
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLARE_V1HISTOPARC_DB_DECLARE_1(); program.R0900_00_DECLARE_V1HISTOPARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V0ENDO_DTINIVIG.Value = fullDataMock;
                program.R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}