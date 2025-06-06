using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI9104B;

namespace FileTests.Test
{
    [Collection("SI9104B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9104B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI9104B_C01_SIARDEVC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_IND_FAVORECIDO" , ""},
                { "SIARDEVC_CGCCPF" , ""},
                { "SIARDEVC_TIPO_PESSOA" , ""},
                { "SIARDEVC_NOM_FAVORECIDO" , ""},
                { "SIARDEVC_COD_BANCO" , ""},
                { "SIARDEVC_COD_AGENCIA" , ""},
                { "SIARDEVC_OPERACAO_CONTA" , ""},
                { "SIARDEVC_COD_CONTA" , ""},
                { "SIARDEVC_DV_CONTA" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_DATA_NEGOCIADA" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_VAL_MAO_OBRA" , ""},
                { "SIARDEVC_IND_FORMA_PAGTO" , ""},
                { "SIARDEVC_NOM_BAIRRO" , ""},
                { "SIARDEVC_NOM_CIDADE" , ""},
                { "SIARDEVC_COD_UF" , ""},
                { "SIARDEVC_NUM_CEP" , ""},
                { "SIARDEVC_NUM_DDD" , ""},
                { "SIARDEVC_NUM_TELEFONE" , ""},
                { "SIARDEVC_IND_DOC_FISCAL" , ""},
                { "SIARDEVC_NUM_DOC_FISCAL" , ""},
                { "SIARDEVC_SERIE_DOC_FISCAL" , ""},
                { "SIARDEVC_DATA_EMISSAO" , ""},
                { "SIARDEVC_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9104B_C01_SIARDEVC", q1);

            #endregion

            #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , ""},
                { "HOST_NUM_EXPEDIENTE_VC" , ""},
                { "HOST_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1600_00_LE_FONTES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_LE_FONTES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO" , ""},
                { "SIARDEVC_COD_FAVORECIDO" , ""},
                { "SIARDEVC_STA_RETORNO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI9104B_Tests_Fact()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI9104B_C01_SIARDEVC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "X"},
                { "SIARDEVC_SEQ_GERACAO" , "0"},
                { "SIARDEVC_TIPO_REGISTRO" , "1"},
                { "SIARDEVC_SEQ_REGISTRO" , "0"},
                { "SIARDEVC_NUM_APOL_SINISTRO" , "2"},
                { "SIARDEVC_NUM_SINISTRO_VC" , "3"},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "4"},
                { "SIARDEVC_IND_FAVORECIDO" , "5"},
                { "SIARDEVC_CGCCPF" , "123456"},
                { "SIARDEVC_TIPO_PESSOA" , "0"},
                { "SIARDEVC_NOM_FAVORECIDO" , "X"},
                { "SIARDEVC_COD_BANCO" , "1"},
                { "SIARDEVC_COD_AGENCIA" , "2"},
                { "SIARDEVC_OPERACAO_CONTA" , "3"},
                { "SIARDEVC_COD_CONTA" , "4"},
                { "SIARDEVC_DV_CONTA" , "5"},
                { "SIARDEVC_COD_OPERACAO" , "3001"},
                { "SIARDEVC_NUM_APOLICE" , "7"},
                { "SIARDEVC_NUM_ENDOSSO" , "8"},
                { "SIARDEVC_NUM_ITEM" , "9"},
                { "SIARDEVC_COD_RAMO" , "10"},
                { "SIARDEVC_COD_COBERTURA" , "11"},
                { "SIARDEVC_DATA_OCORRENCIA" , "2020-01-01"},
                { "SIARDEVC_DATA_NEGOCIADA" , "2020-01-01"},
                { "SIARDEVC_COD_CAUSA" , "1"},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "2"},
                { "SIARDEVC_VAL_MAO_OBRA" , "20"},
                { "SIARDEVC_IND_FORMA_PAGTO" , "0"},
                { "SIARDEVC_NOM_BAIRRO" , "X"},
                { "SIARDEVC_NOM_CIDADE" , "X"},
                { "SIARDEVC_COD_UF" , "1"},
                { "SIARDEVC_NUM_CEP" , "123"},
                { "SIARDEVC_NUM_DDD" , "11"},
                { "SIARDEVC_NUM_TELEFONE" , "70707070"},
                { "SIARDEVC_IND_DOC_FISCAL" , "0"},
                { "SIARDEVC_NUM_DOC_FISCAL" , "1"},
                { "SIARDEVC_SERIE_DOC_FISCAL" , "2"},
                { "SIARDEVC_DATA_EMISSAO" , "2020-01-01"},
                { "SIARDEVC_COD_FONTE" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI9104B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9104B_C01_SIARDEVC", q1);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SINISMES_SALDO_PAGAR_IX" , "10"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISMES_COD_PRODUTO" , "2"},
                { "SINISMES_COD_CAUSA" , "3"},
                { "SINISMES_OCORR_HISTORICO" , "4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "1"},
                { "HOST_NUM_EXPEDIENTE_VC" , "2"},
                { "HOST_COD_COBERTURA" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1600_00_LE_FONTES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_SIT_REGISTRO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_LE_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_LE_FONTES_DB_SELECT_1_Query1", q4);

                #endregion

               
                #endregion
                var program = new SI9104B();
                program.Execute();


                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1



                var envList35 = AppSettings.TestSet.DynamicData["R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList35?.Count > 1);
                Assert.True(envList35[1].TryGetValue("SIARDEVC_COD_ERRO", out var SIARDEVC_COD_ERRO) && SIARDEVC_COD_ERRO == "0022");
                Assert.True(envList35[1].TryGetValue("IND_COD_ERRO", out var IND_COD_ERRO) && IND_COD_ERRO == "0000");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_STA_PROCESSAMENTO", out var SIARDEVC_STA_PROCESSAMENTO) && SIARDEVC_STA_PROCESSAMENTO == "2");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_OCORR_HISTORICO", out var SIARDEVC_OCORR_HISTORICO) && SIARDEVC_OCORR_HISTORICO == "0000");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_ORDEM_PAGAMENTO", out var SIARDEVC_ORDEM_PAGAMENTO) && SIARDEVC_ORDEM_PAGAMENTO == "000000000");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_COD_FAVORECIDO", out var SIARDEVC_COD_FAVORECIDO) && SIARDEVC_COD_FAVORECIDO == "000000000");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_STA_RETORNO", out var SIARDEVC_STA_RETORNO) && SIARDEVC_STA_RETORNO == "1");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_TIPO_REGISTRO", out var SIARDEVC_TIPO_REGISTRO) && SIARDEVC_TIPO_REGISTRO == "1");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_SEQ_REGISTRO", out var SIARDEVC_SEQ_REGISTRO) && SIARDEVC_SEQ_REGISTRO == "000000000");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_NOM_ARQUIVO", out var SIARDEVC_NOM_ARQUIVO) && SIARDEVC_NOM_ARQUIVO == "X       ");
                Assert.True(envList35[1].TryGetValue("SIARDEVC_SEQ_GERACAO", out var SIARDEVC_SEQ_GERACAO) && SIARDEVC_SEQ_GERACAO == "000000000");

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void SI9104B_Tests99_Fact()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI9104B_C01_SIARDEVC

                var q1 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Remove("SI9104B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9104B_C01_SIARDEVC", q1);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SINISMES_SALDO_PAGAR_IX" , "10"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISMES_COD_PRODUTO" , "2"},
                { "SINISMES_COD_CAUSA" , "3"},
                { "SINISMES_OCORR_HISTORICO" , "4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "1"},
                { "HOST_NUM_EXPEDIENTE_VC" , "2"},
                { "HOST_COD_COBERTURA" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1600_00_LE_FONTES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_SIT_REGISTRO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_LE_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_LE_FONTES_DB_SELECT_1_Query1", q4);

                #endregion


                #endregion
                var program = new SI9104B();
                program.Execute();


             

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}