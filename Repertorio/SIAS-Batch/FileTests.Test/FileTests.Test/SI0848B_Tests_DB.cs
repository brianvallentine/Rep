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
using static Code.SI0848B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0848B_Tests_DB")]
    public class SI0848B_Tests_DB
    {

        [Fact]
        public static void SI0848B_Database()
        {
            var program = new SI0848B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*2*/
                program.V0SIST_DTMOVABE.Value = "2024-01-01";
                program.Execute_DB_SELECT_2(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try 
            { /*3*/
                program.V0SIST_DTMOVABE.Value = "2024-01-01";
                program.R0000_90_FINALIZACAO_2_DB_DELETE_1(); 
            } 
            catch (Exception ex) 
            {
                _.ThreatableTestError(ex); 
            }
            
            try 
            { /*4*/

                program.V0RELAT_PERI_INICIAL.Value = "2024-01-01";
                program.V0RELAT_PERI_FINAL.Value = "2024-01-01";

                program.M_100_DECLARE_V0SINISTROS_DB_DECLARE_1(); 
                program.M_100_DECLARE_V0SINISTROS_DB_OPEN_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

        }
    }
}