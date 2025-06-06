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
using static Code.VP0050B;

namespace FileTests.Test_DB
{
    [Collection("VP0050B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0050B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void VP0050B_Database()
        {
            var program = new VP0050B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_V1RELATORIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0210_00_DELETE_V0RELATORIO_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0500_00_MONTA_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0900_00_DECLARE_V0FUNCIOCEF_DB_DECLARE_1(); program.R0900_00_DECLARE_V0FUNCIOCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R5001_00_DECLER_V0SEGURAVG_DB_DECLARE_1(); program.R5001_00_DECLER_V0SEGURAVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1300_SELECT_SUREG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V1RELA_DATA_REFER.Value = pData;
                program.R5004_00_DECLER_V0HISTCOBVA_DB_DECLARE_1(); program.R5004_00_DECLER_V0HISTCOBVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R6001_00_DECLER_V0AVERBCEF_DB_DECLARE_1(); program.R6001_00_DECLER_V0AVERBCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R5020_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R6030_00_SELECT_COBERTURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R6030_00_SELECT_COBERTURAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R9100_00_INSERT_V0RELATORIO_DB_INSERT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}