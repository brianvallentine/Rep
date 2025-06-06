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
using static Code.SI0108B;

namespace FileTests.Test_DB
{
    [Collection("SI0108B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI0108B_Tests_DB
    {

        [Fact]
        public static void SI0108B_Database()
        {
            var program = new SI0108B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_015_000_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.TSISTEM_DTMOVABE.Value = "2020-01-01";
                program.M_080_000_CURSOR_RELATO_DB_DECLARE_1(); program.M_080_000_CURSOR_RELATO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.RELSIN_DTINIVIG.Value = "2020-01-01";
                program.RELSIN_DTTERVIG.Value = "2020-01-01";
                program.M_090_000_ABRIR_CURSOR_DB_DECLARE_1(); program.M_090_000_ABRIR_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.WH_FONTE.Value = 1;
                program.M_180_000_LER_TGEFONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.TSISTEM_DTMOVABE.Value = "2020-01-01" ;
                program.M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.WGEUNIMO_DTINIVIG.Value ="2020-01-01";
                program.WGEUNIMO_DTTERVIG.Value = "2020-01-01";
                program.WMOEDA.Value = 1;
                program.M_610_000_LER_TGEUNIMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.WMOEDA.Value = 1;
                program.M_620_000_LER_TMESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}