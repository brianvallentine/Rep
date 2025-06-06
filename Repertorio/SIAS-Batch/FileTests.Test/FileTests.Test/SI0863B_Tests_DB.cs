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
using static Code.SI0863B;
using Dclgens;
using Sias.Sinistro.DB2.SI0863B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0863B_Tests_DB")]
    public class SI0863B_Tests_DB
    {

        [Fact]
        public static void SI0863B_Database()
        {
            var program = new SI0863B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            try 
            { /*1*/ 
                program.R010_SELECT_SISTEMAS_DB_SELECT_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

            try 
            { /*2*/ 
                program.R020_DECLARE_CARTA_SINISTRO_DB_DECLARE_1(); 
                program.R020_DECLARE_CARTA_SINISTRO_DB_OPEN_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

            try 
            { /*3*/
                program.SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO.Value = 1;
                program.SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.Value = 1;
                program.SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE.Value = 1;
                program.SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE.Value = 1;

                program.R200_UPDATE_SITUACAO_DB_UPDATE_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex);
            }

            try 
            { /*4*/ 
                program.R300_GERA_OBJETO_DB_SELECT_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

            try 
            { /*5*/                
                program.R303_INSERT_OBJETO_DB_INSERT_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
        }
    }
}