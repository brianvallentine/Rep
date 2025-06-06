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
using static Code.SI0808B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0808B_Tests_DB")]
    public class SI0808B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void SI0808B_Database()
        {
            var program = new SI0808B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.V1SIST_DTCURRENT.Value = pData;
                program.M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_00_PREPARA_CABECALHO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0000_00_PREPARA_CABECALHO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_00_SELECT_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ 
                program.WHOST_DTINIVIG.Value = pData;
                program.M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.V1RELA_PERI_INI.Value = pData;
                program.V1RELA_PERI_FIM.Value = pData;
                program.M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1(); program.M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ 
                program.V0MEST_DATCMD.Value = pData;
                program.V1RELA_PERI_INI.Value = pData;
                program.M_0000_00_DECLARE_PAGTO_ANT_DB_DECLARE_1(); program.M_0000_00_DECLARE_PAGTO_ANT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.V1RELA_PERI_INI.Value = pData;
                program.V1RELA_PERI_FIM.Value = pData;
                program.M_0000_00_DECLARE_PAGTO_PERI_DB_DECLARE_1(); program.M_0000_00_DECLARE_PAGTO_PERI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}