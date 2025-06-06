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
using static Code.SI0102B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("SI0102B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0102B_Tests_DB
    {

        [Fact]
        public static void SI0102B_Database()
        {
            var program = new SI0102B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ 
                program.M_015_000_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.M_070_000_LER_PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.TAPDCORR_NUM_APOL.Value = 1;
                program.TMESTSIN_CODSUBES.Value= 1;
                program.TMESTSIN_NRCERTIF.Value = 1;
                program.TMESTSIN_IDTPSEGU.Value = "1";
                program.M_071_000_LER_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.TMESTSIN_APOL_SINI.Value = 1;
                program.M_072_000_LER_SINIITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.TAPDCORR_NUM_APOL.Value = 1;
                program.M_073_000_LER_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ 
                program.SEGV_CLIENTE.Value = 1;
                program.M_074_000_LER_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.TSISTEMA_DTMOVABE.Value = "2020-01-01";
                program.M_090_000_CURSOR_TRELSIN_DB_DECLARE_1(); program.M_090_000_CURSOR_TRELSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.TRELSIN_CODCORR.Value = 1;
                program.W_DTINIVIG.Value = "2020-01-01";
                program.W_DTTERVIG.Value = "2020-01-02";
                program.M_170_000_CURSOR_TAPDCORR_DB_DECLARE_1(); program.M_170_000_CURSOR_TAPDCORR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.TMESTSIN_APOL_SINI.Value = 1;
                program.M_210_000_CURSOR_THISTSIN_DB_DECLARE_1(); program.M_210_000_CURSOR_THISTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.TAPDCORR_NUM_APOL.Value = 1;    
                program.M_260_000_ACESSA_TAPOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.TRELSIN_CODCORR.Value = 1;
                program.M_300_000_ACESSA_CORRETOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.TSISTEMA_DTMOVABE.Value = "2020-01-01";
                program.M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.WGEUNIMO_DTINIVIG.Value = "2020-01-01";
                program.WGEUNIMO_DTTERVIG.Value = "2020-01-01";
                program.WMOEDA.Value = 1;
                program.M_610_000_LER_TGEUNIMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}