using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.GE0530S;

namespace FileTests.Test_DB
{
    [Collection("GE0530S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0530S_Tests_DB
    {
        [Fact]
        public static void GE0530S_Database()
        {
            var program = new GE0530S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/
                //The statement failed because the authorization ID does not have the required authorization or privilege to perform the operation.  Authorization ID: "SISSMZ1H".  
                program.R2320_ABRR_CURSOR_C001_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                //The statement failed because the authorization ID does not have the required authorization or privilege to perform the operation.  Authorization ID: "SISSMZ1H".  
                program.R2420_ABRR_CURSOR_C002_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/program.R1200_00_DATA_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                //The statement failed because the authorization ID does not have the required authorization or privilege to perform the operation.  Authorization ID: "SISSMZ1H".  
                program.R2100_00_CONSULTAR_PEP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}