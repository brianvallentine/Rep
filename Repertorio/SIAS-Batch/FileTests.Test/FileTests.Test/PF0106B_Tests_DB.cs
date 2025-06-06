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
using static Code.PF0106B;

namespace FileTests.Test_DB
{
    [Collection("PF0106B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0106B_Tests_DB
    {

        [Fact]
        public static void PF0106B_Database()
        {
            var program = new PF0106B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0260_LER_DADOS_PAGADOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO.Value = "2021-01-01";
                program.R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ 
                program.R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.PF038.DCLPF_PGTO_SIVPF.PF038_DTH_QUITACAO.Value = "2020-01-01";
                program.R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1(); 

            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}