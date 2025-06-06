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
using static Code.SI0007B;
namespace FileTests.Test_DB
{
    [Collection("SI0007B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0007B_Tests_DB
    {
        [Fact]
        public static void SI0007B_Database()
        {
            var program = new SI0007B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_110_00_TAB_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.AREAS_DE_WORK.W_DATA_PESQUISA.Value = "2000-10-10";
                program.M_210_00_DECLARE_HIST_AVISOS_DB_DECLARE_1(); program.M_210_00_DECLARE_HIST_AVISOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_231_00_ADIANTAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}