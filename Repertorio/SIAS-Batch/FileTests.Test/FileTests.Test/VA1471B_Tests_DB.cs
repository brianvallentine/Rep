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
using static Code.VA1471B;

namespace FileTests.Test_DB
{
    [Collection("VA1471B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA1471B_Tests_DB
    {

        [Fact]
        public static void VA1471B_Database()
        {
            var program = new VA1471B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/
                program.WHOST_DTH_INI.Value = "2020-01-01";
                program.WHOST_DTH_FIM.Value = "2020-01-01";
                program.SISTEMAS_DTMOVABE_10D.Value = "2020-01-01";
                program.SISTEMAS_DTMOVABE_1M.Value = "2020-01-01";
                program.WHOST_DTH_INI_BIL.Value = "2020-01-01";
                program.M_0000_PRINCIPAL_DB_DECLARE_1(); 
                program.M_0000_PRINCIPAL_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.M_0000_PRINCIPAL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0000_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0100_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0100_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.SISTEMAS_DTCURREN.Value = "2020-01-01";
                program.SISTEMAS_DTCURINI.Value = "2021-01-01";
                program.M_0100_CONTINUA_DB_SELECT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0100_CONTINUA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0100_CONTINUA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0100_CONTINUA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0200_INSERT_REPSAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0200_INSERT_REPSAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}