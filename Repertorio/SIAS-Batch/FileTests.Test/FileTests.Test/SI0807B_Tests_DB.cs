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
using static Code.SI0807B;

namespace FileTests.Test_DB
{
    [Collection("SI0807B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0807B_Tests_DB
    {

        [Fact]
        public static void SI0807B_Database()
        {
            var program = new SI0807B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_00_PREPARA_CABECALHO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V1RELA_CODUNIMO.Value = 1 ;
                program.M_0000_00_PREPARA_CABECALHO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V1APOL_NUM_APOLICE.Value = 1 ;  
                program.M_0000_00_SELECT_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ 
                program.V1SEGU_NRCERTIF.Value = 1 ;
                program.M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.WHOST_CODCLIEN.Value = 1 ;  
                program.M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.WHOST_CODUNIMO.Value = 1;
                program.WHOST_DTINIVIG.Value = "2020-01-01";
                program.M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.V0MEST_NUM_APOL_I.Value = 1;
                program.V0MEST_NUM_APOL_F.Value = 2;
                program.V1RELA_PERI_INI.Value = "2020-01-01";
                program.V1RELA_PERI_FIM.Value = "2020-01-01";
                program.M_0000_00_DECLARE_V0MESTSINI_DB_DECLARE_1(); program.M_0000_00_DECLARE_V0MESTSINI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ 
                program.V0MEST_NUM_APOL_SINI.Value = 1;
                program.M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}