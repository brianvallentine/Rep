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
using static Code.SI0106B;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0106B_Tests_DB")]
    public class SI0106B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void SI0106B_Database()
        {
            var program = new SI0106B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_015_000_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SIST_DTMOVABE.Value = pData;
                program.M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1(); program.M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.RELSIN_DTINIVIG.Value = pData;
                program.RELSIN_DTTERVIG.Value = pData;
                program.M_130_000_CURSOR_THISTSIN_DB_DECLARE_1(); program.M_130_000_CURSOR_THISTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.WGEUNIMO_DTINIVIG.Value = pData;
                program.WGEUNIMO_DTTERVIG.Value = pData;
                program.M_610_000_LER_TGEUNIMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_620_000_LER_TMESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SIST_DTMOVABE.Value = pData;
                program.M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}