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
using static Code.EM1139B;

namespace FileTests.Test_DB
{
    [Collection("EM1139B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM1139B_Tests_DB
    {

        [Fact]
        public static void EM1139B_Database()
        { 
            var program = new EM1139B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_DECLARE_V0PARCEHIS_DB_DECLARE_1(); program.R0300_00_DECLARE_V0PARCEHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0510_00_INSERT_GE397_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0520_00_INSERT_GE398_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}