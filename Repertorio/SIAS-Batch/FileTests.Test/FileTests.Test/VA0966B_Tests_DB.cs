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
using static Code.VA0966B;

namespace FileTests.Test_DB
{
    [Collection("VA0966B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0966B_Tests_DB
    {
        private static string pData = "2022-02-02";

        [Fact]
        public static void VA0966B_Database()
        {
            var program = new VA0966B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.AREA_DE_WORK.WHOST_DTH_INI.Value = pData;
                program.AREA_DE_WORK.WHOST_DTH_FIM.Value = pData;
                program.R0900_00_DECLARE_CURSOR_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_CURSOR_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1900_00_DECLARE_CURSOR_DB_DECLARE_1(); program.R1900_00_DECLARE_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1100_00_SELECT_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1200_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1300_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1400_00_SELECT_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1450_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1500_00_SELECT_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1500_00_SELECT_PRODUTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1510_00_SELECT_PRODUVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1500_00_SELECT_PRODUTO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.Value = 10;
                program.R1600_00_SELECT_COBERTURA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/ program.R2100_00_SELECT_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}