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

namespace FileTests.Test
{
    [Collection("PF0106B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0106B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PF039_NUM_CGC_CPF" , ""},
                { "PF039_NOM_PAGADOR" , ""},
                { "PF039_DTH_NASCIMENTO" , ""},
                { "PF039_NUM_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PF039_DTH_NASCIMENTO" , ""},
                { "PF039_NUM_TELEFONE" , ""},
                { "PF039_NOM_PAGADOR" , ""},
                { "PF039_NUM_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PF039_NUM_CGC_CPF" , ""},
                { "PF039_NOM_PAGADOR" , ""},
                { "PF039_DTH_NASCIMENTO" , ""},
                { "PF039_NUM_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PF038_NUM_TITULO_SIVPF" , ""},
                { "PF038_COD_PRODUTO_SIVPF" , ""},
                { "PF038_COD_AGENCIA" , ""},
                { "PF038_IND_PAGAMENTO" , ""},
                { "PF038_NUM_CGC_CPF" , ""},
                { "PF038_NUM_PROPOSTA" , ""},
                { "PF038_NUM_CERTIFICADO" , ""},
                { "PF038_NUM_PARCELA_PAGA" , ""},
                { "PF038_DTH_QUITACAO" , ""},
                { "PF038_VLR_PAGO" , ""},
                { "PF038_SIGLA_ARQUIVO" , ""},
                { "PF038_SISTEMA_ORIGEM" , ""},
                { "PF038_NSAS_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.GPF.MJUNMOV.D240924")]
        public static void PF0106B_Tests_Theory(string MOV_SIGAT_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0106B();
               program.Execute(MOV_SIGAT_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                var envList2 = AppSettings.TestSet.DynamicData["R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList1[1].TryGetValue("PF038_NUM_CGC_CPF", out string valor) && valor == "022222222222222");
                Assert.True(envList1[1].TryGetValue("PF038_NSAS_SIVPF", out valor) && valor == "000111112");

                Assert.True(envList2[1].TryGetValue("PF039_DTH_NASCIMENTO", out valor) && valor == "2222 22-22");
            }
        }

        [Theory]
        [InlineData("PRD.GPF.MJUNMOV.D240924")]
        public static void PF0106B_Tests_Theory_INSERIR_DADOS_PAGADOR(string MOV_SIGAT_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                var q1 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1");

                q1.AddDynamic(new Dictionary<string, string>{
                { "PF039_NUM_CGC_CPF" , ""},
                { "PF039_NOM_PAGADOR" , ""},
                { "PF039_DTH_NASCIMENTO" , ""},
                { "PF039_NUM_TELEFONE" , ""},
                }, new SQLCA(100));

                AppSettings.TestSet.DynamicData.Add("R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1", q1);

                #endregion
                var program = new PF0106B();
                program.Execute(MOV_SIGAT_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PF039_NOM_PAGADOR", out string valor) && valor == "2222222222222222222222222222222222222222");

            }
        }
    }
}