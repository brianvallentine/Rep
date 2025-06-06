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
using static Code.VA0340B;

namespace FileTests.Test_DB
{
    [Collection("VA0340B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0340B_Tests_DB
    {

        [Fact]
        public static void VA0340B_Database()
        {
            var program = new VA0340B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0050_00_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0050_00_INICIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0050_00_INICIO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0050_00_INICIO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SIST_DTMAXDEB.Value = "2000-01-01";
                program.R0300_00_DECLARE_V0HCONTAVA_DB_DECLARE_1(); 
                program.R0300_00_DECLARE_V0HCONTAVA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/ 
                program.NRCERTIF.Value = 10001634618;
                program.R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.DTVENCTO.Value = "2020-01-01";
                program.R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/ program.R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R9000_00_FINALIZA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R9000_00_FINALIZA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R9000_00_FINALIZA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}