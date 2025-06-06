using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SISMS1B;

namespace FileTests.Test_DB
{
    [Collection("SISMS1B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SISMS1B_Tests_DB
    {

        [Fact]
        public static void SISMS1B_Database()
        {
            var program = new SISMS1B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R005_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R010_DECLARE_MOVDEBCC_DB_DECLARE_1(); program.R010_DECLARE_MOVDEBCC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R200_DECLARE_TELEFONE_DB_DECLARE_1(); program.R200_DECLARE_TELEFONE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}