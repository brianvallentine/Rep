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
using static Code.SI0220B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0220B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0220B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_DATA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0220B_PROVISAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COD_AGENCIA_CONTRATO" , ""},
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI112_DTH_ACORDO" , ""},
                { "SI112_QTD_PARCELAS" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "HOST_VALOR_RECEBIDO" , ""},
                { "HOST_DATA_BAIXA_SIAS" , ""},
                { "HOST_VALOR_PRELIB_REPASSE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0220B_PROVISAO", q2);

            #endregion

            #region SI0220B_CREDITO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_CGCCPF" , ""},
                { "APOLICRE_NUM_FATURA" , ""},
                { "APOLICRE_DATA_INIVIGENCIA" , ""},
                { "APOLICRE_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0220B_CREDITO", q3);

            #endregion

            #region R110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIHAB1_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1", q5);

            #endregion

            #region R120_BUSCA_CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R120_BUSCA_CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , ""},
                { "AGENCCEF_NOME_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0220B_SAIDA.txt")]
        public static void SI0220B_Tests_Theory(string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                                                                                                               "}
            });
                AppSettings.TestSet.DynamicData.Add("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R010_LE_SISTEMAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2000-10-10"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_DATA_CORRENTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new SI0220B();
                program.Execute(REG_RET_FILE_NAME_P);

                Assert.True(File.Exists(program.REG_RET.FilePath));
                Assert.True(new FileInfo(program.REG_RET.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("SI0220B_SAIDA.txt")]
        public static void SI0220B_Tests_Erro(string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
              
                #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new SI0220B();
                program.Execute(REG_RET_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}