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
using static Code.SI0101B;

namespace FileTests.Test_DB
{
    [Collection("SI0101B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0101B_Tests_DB
    {        
        [Fact]
        public static void SI0101B_Database()
        {
            var program = new SI0101B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_015_000_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.SIST_DTMOVABE.Value = "2020-01-01";
                program.M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1(); program.M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.RELSIN_APOLICE.Value = 123465;
                program.W_DTINIVIG.Value =  "2020-01-01";
                program.W_DTTERVIG.Value = "2020-01-01";
                program.M_240_000_CURSOR_TMESTSIN_DB_DECLARE_1(); program.M_240_000_CURSOR_TMESTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.MEST_APOL_SINI.Value = 123465;
                program.M_270_000_CURSOR_THISTSIN_DB_DECLARE_1(); program.M_270_000_CURSOR_THISTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.RELSIN_APOLICE.Value = 123465 ;
                program.MEST_CODSUBES.Value = 123;
                program.M_260_000_LER_TCLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.CLIE_COD_CLIENTE.Value = 123;
                program.M_260_000_LER_TCLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.W_SINISTRO.Value = 123;
                program.M_330_000_LER_TAPOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.W_SINISTRO.Value = 123456;
                program.M_360_010_ACESSA_V0SINICAUSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SIST_DTMOVABE.Value =  "2020-01-01" ;
                program.M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.WGEUNIMO_DTINIVIG.Value = "1991-02-06";
                program.WGEUNIMO_DTTERVIG.Value = "1991-02-06";
                program.WMOEDA.Value = 3;
                program.M_610_000_LER_TGEUNIMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}