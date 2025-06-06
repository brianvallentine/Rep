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
using static Code.SI0181B;
namespace FileTests.Test_DB
{
    [Collection("SI0181B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0181B_Tests_DB
    {
        [Fact]
        public static void SI0181B_Database()
        {
            var program = new SI0181B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_00_DECLARE_PRINCIPAL_DB_DECLARE_1(); program.R0110_00_DECLARE_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}