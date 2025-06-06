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
using static Code.BI0602B;

namespace FileTests.Test_DB
{
    [Collection("BI0602B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0602B_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void BI0602B_Database()
        {
            var program = new BI0602B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/
                program.AREA_DE_WORK.WS_DATA_INICIO.Value = pData;
                program.AREA_DE_WORK.WS_DATA_FINAL.Value = pData;
                program.R1400_00_OPEN_CURSOR01_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/ program.R1951_00_BUSCA_MOTIVO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0250_00_CARREGA_ORIGEM_DB_DECLARE_1(); program.R0250_00_CARREGA_ORIGEM_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1501_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1501_00_SELECT_BILHETE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1502_00_SELECT_UNIDACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1503_00_SELECT_PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1503_00_SELECT_PROPOVA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}