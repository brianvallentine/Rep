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
using static Code.BI0094B;

namespace FileTests.Test_DB
{
    [Collection("BI0094B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0094B_Tests_DB
    {

        [Fact]
        public static void BI0094B_Database()
        {
            var program = new BI0094B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try
            { /*1*/
                //program.BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Value = "2024-01-01"; 
                //program.BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.Value = "2024-01-01";
                program.WSHOST_DATA060.Value = "2024-01-01";
                program.R0210_00_OPEN_DECLINA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECIONA_BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0400_00_ENCERRA_EXPI_PROD_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0260_00_SELECT_V0APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0270_00_SELECT_V0RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.Value = "2024-01-01";
                program.R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}