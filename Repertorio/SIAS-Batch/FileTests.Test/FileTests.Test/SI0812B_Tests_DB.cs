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
using static Code.SI0812B;

namespace FileTests.Test_DB
{
    [Collection("SI0812B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0812B_Tests_DB
    {

        [Fact]
        public static void SI0812B_Database()
        {
            var program = new SI0812B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_510_000_LER_TEMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_520_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SIST_DTMOVABE.Value = "2020-01-01";
                program.M_530_000_CURSOR_TRELSIN_DB_DECLARE_1(); program.M_530_000_CURSOR_TRELSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.RELSIN_APOLICE.Value = 12346;
                program.WDATA_INI.Value = "2020-01-01";
                program.WDATA_FIM.Value = "2020-01-01";
                program.M_550_000_CURSOR_TMESTSIN_DB_DECLARE_1(); program.M_550_000_CURSOR_TMESTSIN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.RELSIN_APOLICE.Value = 123456;
                program.MEST_CODSUBES.Value  = 1;
                program.M_570_000_LER_SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.RELSIN_APOLICE.Value = 123456;
                program.MEST_CODSUBES.Value  = 1;
                program.MEST_NRCERTIF.Value  = 123456;
                program.M_571_000_LER_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.CLIE_COD_CLIENTE.Value = 1;
                program.M_572_000_LER_TCLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.MEST_FONTE.Value = 1;
                program.M_575_000_LER_TFONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.RELSIN_APOLICE.Value =123456 ;
                program.M_580_000_LER_TAPOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.MEST_CODCAU.Value = 1;
                program.MEST_RAMO.Value = 1;
                program.M_585_000_LER_SINICAU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SIST_DTMOVABE.Value = "2020-01-01";
                program.M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}