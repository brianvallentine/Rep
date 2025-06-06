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
using static Code.BI0032B;

namespace FileTests.Test_DB
{
    [Collection("BI0032B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0032B_Tests_DB
    {
        [Fact]
        public static void BI0032B_Database()
        {
            var program = new BI0032B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.V0CALE_DTMOVTO.Value = "2000-10-10";
            program.V0MOVDE_DTMOVTO.Value = "2000-10-10";
            program.V0MOVDE_DTVENCTO.Value = "2000-10-10";
            program.WDATA_BASE.Value = "2000-10-10";


            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0400_00_DECLARE_RELATORIO_DB_DECLARE_1(); program.R0400_00_DECLARE_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0600_00_SELEC_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1050_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1400_00_SELECT_V0FERIADOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}