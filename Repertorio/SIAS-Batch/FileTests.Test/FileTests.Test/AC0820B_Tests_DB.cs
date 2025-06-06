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
using static Code.AC0820B;

namespace FileTests.Test_DB
{
    [Collection("AC0820B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class AC0820B_Tests_DB
    {
        private static string pData = "2022-03-03";

        [Fact]
        public static void AC0820B_Database()
        {
            var program = new AC0820B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_SELECT_V0EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V0SIST_DTMOVABE_FI.Value = pData;
                program.R0300_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1(); 
                program.R0300_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ 
                program.V0CCCH_DTMOVTAC.Value = pData;
                program.R1100_00_DECLARE_V0COSSEG_CED_DB_DECLARE_1(); 
                program.R1100_00_DECLARE_V0COSSEG_CED_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/ program.R0600_00_SELECT_V0EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0800_00_SELECT_V0CONGENERE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1600_00_DECLARE_V0COSHISTPRE_DB_DECLARE_1(); program.R1600_00_DECLARE_V0COSHISTPRE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2100_00_DECLARE_V0COSHISTSIN_DB_DECLARE_1(); program.R2100_00_DECLARE_V0COSHISTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}