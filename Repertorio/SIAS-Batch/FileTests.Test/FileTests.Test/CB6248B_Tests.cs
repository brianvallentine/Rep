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
using static Code.CB6248B;

namespace FileTests.Test
{
    [Collection("CB6248B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    
    public class CB6248B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_TIMESTAMP" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_NUM_TITULO_MAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1", q7);

            #endregion

            #region R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_NUM_SICOB" , ""},
                { "CONVERSI_COD_EMPRESA_SIVPF" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "CONVERSI_AGEPGTO" , ""},
                { "CONVERSI_DATA_OPERACAO" , ""},
                { "CONVERSI_DATA_QUITACAO" , ""},
                { "CONVERSI_VAL_RCAP" , ""},
                { "CONVERSI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_TIMESTAMP" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB6248B_Full.txt")]
        public static void CB6248B_Tests_Theory_FileProcessed_ReturnCode0(string MOVIMENTO_FILE_NAME_P)
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
                #region R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "120"},
                { "CEDENTE_NUM_TITULO_MAX" , "130"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q5);

                #endregion
                #region R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "1019790324"},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_TIMESTAMP" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                var program = new CB6248B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("CEDENTE_NUM_TITULO", out var valor0) && valor0.Contains("124"));

                //R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("CONVERSI_COD_PRODUTO_SIVPF", out var valor1) && valor1.Contains("8105"));
                Assert.True(envList1.Count > 1);

                //R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("BILHETE_NUM_BILHETE", out var valor2) && valor2.Contains("124"));
                Assert.True(envList2.Count > 1);

                //R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MOVIMCOB_COD_BANCO", out var valor3) && valor3.Contains("0104"));
                Assert.True(envList3.Count > 1);

                //R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1
                var envList4 = AppSettings.TestSet.DynamicData["R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList4.Count == 0);
            }
        }
        [Theory]
        [InlineData("CB6248B_EmptyFile.txt")]
        public static void CB6248B_Tests_Theory_EmptyFile_ReturnCode00(string MOVIMENTO_FILE_NAME_P)
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
                var program = new CB6248B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("CB6248B_Full.txt")]
        public static void CB6248B_Tests_Theory_RangeMumerationValidationError_ReturnCode99(string MOVIMENTO_FILE_NAME_P)
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
                #region R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , "150"},
                { "CEDENTE_NUM_TITULO_MAX" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q5);

                #endregion
                #region R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "1019790324"},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_TIMESTAMP" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                var program = new CB6248B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }

        [Theory]
        [InlineData("CB6248B_HeaderFileError.txt")]
        public static void CB6248B_Tests_Theory_FileHeaderValidationError_ReturnCode99(string MOVIMENTO_FILE_NAME_P)
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
                var program = new CB6248B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}