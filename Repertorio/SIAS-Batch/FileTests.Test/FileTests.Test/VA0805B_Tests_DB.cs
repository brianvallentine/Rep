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
using static Code.VA0805B;

namespace FileTests.Test_DB
{
    [Collection("VA0805B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0805B_Tests_DB
    {

        [Fact]
        public static void VA0805B_Database()
        {
            var program = new VA0805B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0001_INICIO_PROCESSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0002_00_PROC_FITACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0011_CONSISTE_NSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0011_CONSISTE_NSA_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_2300_PESQUISA_NOME_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_2300_10_PESQUISA_CONTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_2300_20_PESQUISA_NOME_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_2300_10_PESQUISA_CONTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.FITCEF_DTRET.Value = "2021-02-02";
                program.M_5600_MOVIMENTO_VAZIO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}