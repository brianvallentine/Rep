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
using static Code.CB0139B;

namespace FileTests.Test.FileTests.Test
{
    [Collection("CB0139B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class CB0139B_Tests_DB
    {

        [Fact]
        public static void CB0139B_Database()
        {
            var program = new CB0139B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*3*/

                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Value = "2024-01-01";

                program.R0410_00_DECLARE_V0EXTRATO_DB_DECLARE_1();
                program.R0410_00_DECLARE_V0EXTRATO_DB_OPEN_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

        }
    }
}