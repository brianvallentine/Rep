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
using static Code.CB7537B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("CB7537B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB7537B_Tests_DB
    {

        [Fact]
        public static void CB7537B_Database()
        {
            var program = new CB7537B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2023-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Value = "2025-01-01";
                program.R0250_00_DECLARE_V0MOVICOB_DB_DECLARE_1(); program.R0250_00_DECLARE_V0MOVICOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 123;
                program.R0520_00_SELECT_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 123;
                program.R0530_00_SELECT_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}