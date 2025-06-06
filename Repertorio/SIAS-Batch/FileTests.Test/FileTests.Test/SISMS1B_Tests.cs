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
using static Code.SISMS1B;

namespace FileTests.Test
{
    [Collection("SISMS1B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SISMS1B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R005_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DATA_CORRENTE" , ""},
                { "HOST_HORA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R005_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SISMS1B_MOVDEBCC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "GE367_NUM_PESSOA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "OD002_NOM_PESSOA" , ""},
                { "OD002_NUM_CPF" , ""},
                { "OD002_NUM_DV_CPF" , ""},
                { "OD005_DES_EMAIL" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISMS1B_MOVDEBCC", q1);

            #endregion

            #region SISMS1B_TELEFONE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD004_NUM_PESSOA" , ""},
                { "OD004_SEQ_TELEFONE" , ""},
                { "OD004_NUM_DDI" , ""},
                { "OD004_NUM_DDD" , ""},
                { "OD004_COD_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISMS1B_TELEFONE", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SISMS1B_1_t1", "SISMS1B_2_t1")]
        public static void SISMS1B_Tests_Theory_ReturnCode00(string ARQSMSCS_FILE_NAME_P, string ARQMOVSS_FILE_NAME_P)
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
                #region R005_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                    { "HOST_DATA_CORRENTE" , "2020-02-02"},
                    { "HOST_HORA_CORRENTE" , "01:11:11"},
                });
                AppSettings.TestSet.DynamicData.Remove("R005_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R005_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SISMS1B_MOVDEBCC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "GE367_NUM_PESSOA" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_ENVIO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_RETORNO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_MOVIMENTO" , "2020-01-01"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "MOVDEBCE_VLR_CREDITO" , ""},
                    { "GE369_COD_BANCO" , ""},
                    { "GE369_COD_AGENCIA" , ""},
                    { "GE369_NUM_CONTA_CNB" , ""},
                    { "GE369_NUM_DV_CONTA_CNB" , ""},
                    { "CLIENTES_NOME_RAZAO" , ""},
                    { "CLIENTES_CGCCPF" , ""},
                    { "OD002_NOM_PESSOA" , ""},
                    { "OD002_NUM_CPF" , ""},
                    { "OD002_NUM_DV_CPF" , ""},
                    { "OD005_DES_EMAIL" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SISMS1B_MOVDEBCC");
                AppSettings.TestSet.DynamicData.Add("SISMS1B_MOVDEBCC", q1);

                #endregion

                #region SISMS1B_TELEFONE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "OD004_NUM_PESSOA" , ""},
                    { "OD004_SEQ_TELEFONE" , ""},
                    { "OD004_NUM_DDI" , ""},
                    { "OD004_NUM_DDD" , ""},
                    { "OD004_COD_TELEFONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SISMS1B_TELEFONE");
                AppSettings.TestSet.DynamicData.Add("SISMS1B_TELEFONE", q2);

                #endregion
                #endregion
                var program = new SISMS1B();
                program.Execute(ARQSMSCS_FILE_NAME_P, ARQMOVSS_FILE_NAME_P);

                var envSelectSistemas = AppSettings.TestSet.DynamicData["R005_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envSelectSistemas);
                var envSelectMovDebCc = AppSettings.TestSet.DynamicData["SISMS1B_MOVDEBCC"].DynamicList;
                Assert.Empty(envSelectMovDebCc);
                var envSelectTelefone = AppSettings.TestSet.DynamicData["SISMS1B_TELEFONE"].DynamicList;
                Assert.Empty(envSelectTelefone);


                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("SISMS1B_1_t2", "SISMS1B_2_t2")]
        public static void SISMS1B_Tests_Theory_ReturnCode99(string ARQSMSCS_FILE_NAME_P, string ARQMOVSS_FILE_NAME_P)
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
                #region R005_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                    { "HOST_DATA_CORRENTE" , "2020-02-02"},
                    { "HOST_HORA_CORRENTE" , "01:11:11"},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R005_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R005_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SISMS1B_MOVDEBCC

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "GE367_NUM_PESSOA" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_ENVIO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_RETORNO" , "2020-01-01"},
                    { "MOVDEBCE_DATA_MOVIMENTO" , "2020-01-01"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "MOVDEBCE_VLR_CREDITO" , ""},
                    { "GE369_COD_BANCO" , ""},
                    { "GE369_COD_AGENCIA" , ""},
                    { "GE369_NUM_CONTA_CNB" , ""},
                    { "GE369_NUM_DV_CONTA_CNB" , ""},
                    { "CLIENTES_NOME_RAZAO" , ""},
                    { "CLIENTES_CGCCPF" , ""},
                    { "OD002_NOM_PESSOA" , ""},
                    { "OD002_NUM_CPF" , ""},
                    { "OD002_NUM_DV_CPF" , ""},
                    { "OD005_DES_EMAIL" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SISMS1B_MOVDEBCC");
                AppSettings.TestSet.DynamicData.Add("SISMS1B_MOVDEBCC", q1);

                #endregion

                #region SISMS1B_TELEFONE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "OD004_NUM_PESSOA" , ""},
                    { "OD004_SEQ_TELEFONE" , ""},
                    { "OD004_NUM_DDI" , ""},
                    { "OD004_NUM_DDD" , ""},
                    { "OD004_COD_TELEFONE" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SISMS1B_TELEFONE");
                AppSettings.TestSet.DynamicData.Add("SISMS1B_TELEFONE", q2);

                #endregion
                #endregion
                var program = new SISMS1B();
                program.Execute(ARQSMSCS_FILE_NAME_P, ARQMOVSS_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}