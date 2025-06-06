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
using static Code.SI0803B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0803B_Tests_DB")]
    public class SI0803B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void SI0803B_Database()
        {
            var program = new SI0803B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_510_000_LER_TEMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SIST_DTMOVABE.Value = pData;
                program.SIST_DTCURRENT.Value = pData;
                program.M_520_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.SIST_DTMOVABE.Value = pData;
                program.M_530_000_CURSOR_TRELSIN_DB_DECLARE_1(); program.M_530_000_CURSOR_TRELSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.WDATA_INI.Value = pData;
                program.WDATA_FIM.Value = pData;
                program.M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1(); program.M_550_000_CURSOR_TMESTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_570_000_LER_TCLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_570_000_LER_TCLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_575_000_LER_TFONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_580_000_LER_TAPOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.SIST_DTMOVABE.Value = pData;
                program.M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}