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
using static Code.CB0999B;

namespace FileTests.Test_DB
{
    [Collection("CB0999B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0999B_Tests_DB
    {
        private static string pData = "2020-02-02";

        [Fact]
        public static void CB0999B_Database()
        {
            var program = new CB0999B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.V0RELA_DT_SOLIC.Value = pData;
                program.V0RELA_PERI_INIC.Value = pData;
                program.V0RELA_PERI_FINAL.Value = pData;
                program.V0RELA_DATA_REFER.Value = pData;
                program.R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}