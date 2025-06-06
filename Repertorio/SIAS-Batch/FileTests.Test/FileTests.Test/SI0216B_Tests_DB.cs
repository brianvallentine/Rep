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
using static Code.SI0216B;

namespace FileTests.Test_DB
{
    [Collection("SI0216B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0216B_Tests_DB
    {

        [Fact]
        public static void SI0216B_Database()
        {
            var program = new SI0216B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R020_LE_PROVISAO_DIA_DB_DECLARE_1(); program.R020_LE_PROVISAO_DIA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}