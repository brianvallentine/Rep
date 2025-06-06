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
using static Code.GE0302B;

namespace FileTests.Test_DB
{
    [Collection("GE0302B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0302B_Tests_DB
    {

        [Fact]
        public static void GE0302B_Database()
        {
            var program = new GE0302B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.RXYZ_PULA_SINICHEQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.Execute_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.Execute_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.Execute_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}