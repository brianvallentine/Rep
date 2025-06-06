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
using static Code.CB0055B;

namespace FileTests.Test_DB
{
    [Collection("CB0055B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0055B_Tests_DB
    {
        private static string pData = "2022-01-01";

        [Fact]
        public static void CB0055B_Database()
        {
            var program = new CB0055B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.WHOST_DTINIVIG.Value = pData;
                program.R0900_00_DECLARE_ENDOSSO_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_ENDOSSO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R2000_00_SELECT_ADIANTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}