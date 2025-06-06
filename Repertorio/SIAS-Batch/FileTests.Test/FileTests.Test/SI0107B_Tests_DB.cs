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
using static Code.SI0107B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0107B_Tests_DB")]
    public class SI0107B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void SI0107B_Database()
        {
            var program = new SI0107B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ 
                program.TSISTEMA_DTMOVABE.Value = pData;
                program.TSISTEMA_DTCURRENT.Value = pData;
                program.M_010_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_015_000_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.TSISTEMA_DTMOVABE.Value = pData;
                program.M_020_000_DECLARE_TRELSIN_DB_DECLARE_1(); program.M_020_000_DECLARE_TRELSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.TRELSIN_DTINIVIG.Value = pData;
                program.TRELSIN_DTTERVIG.Value = pData;
                program.M_050_000_DECLARE_JOIN_DB_DECLARE_1(); program.M_050_000_DECLARE_JOIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_080_000_LER_TCLIFOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.TSISTEMA_DTMOVABE.Value = pData;
                program.M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}