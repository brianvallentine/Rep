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
using Dclgens;
using Code;
using static Code.SI9105B;

namespace FileTests.Test
{
    [Collection("SI9105B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9105B_Tests
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

            #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI9105B_C01_SIARDEVC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9105B_C01_SIARDEVC", q2);

            #endregion

            #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , ""},
                { "HOST_NUM_EXPEDIENTE_VC" , ""},
                { "HOST_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI9105B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();
                SI1032S_Tests.Load_Parameters();
                SI1001S_Tests.Load_Parameters();   

                SI1000S_Tests.Load_Parameters();               
                #region PARAMETERS

                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                q100.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", q100);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "0"}
            });
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "0"}
            });
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", q5);

                #endregion
                
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-10-10"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2020-10-10"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q11);

                #endregion
                
                #region SI9105B_C01_SIARDEVC

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "X"},
                { "SIARDEVC_SEQ_GERACAO" , "0"},
                { "SIARDEVC_TIPO_REGISTRO" , "1"},
                { "SIARDEVC_SEQ_REGISTRO" , "2"},
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123"},
                { "SIARDEVC_NUM_SINISTRO_VC" , "123"},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "123"},
                { "SIARDEVC_COD_OPERACAO" , "1"},
                { "SIARDEVC_NUM_APOLICE" , "123"},
                { "SIARDEVC_NUM_ENDOSSO" , "23"},
                { "SIARDEVC_NUM_ITEM" , "123"},
                { "SIARDEVC_COD_COBERTURA" , "1"},
                { "SIARDEVC_DATA_OCORRENCIA" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI9105B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9105B_C01_SIARDEVC", q12);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SINISMES_SALDO_PAGAR_IX" , "2"},
                { "SINISMES_COD_FONTE" , "3"},
                { "SINISMES_COD_PRODUTO" , "4"},
                { "SINISMES_OCORR_HISTORICO" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "123"},
                { "HOST_NUM_EXPEDIENTE_VC" , "123"},
                { "HOST_COD_COBERTURA" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q16);

                #endregion

              
                
                #endregion
               
                var program = new SI9105B();
                program.Execute();


                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1            

                var envList = AppSettings.TestSet.DynamicData["R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("SIARDEVC_NUM_APOL_SINISTRO", out var SIARDEVC_NUM_APOL_SINISTRO) && SIARDEVC_NUM_APOL_SINISTRO == "0000000000123");
                Assert.True(envList[1].TryGetValue("SINISMES_OCORR_HISTORICO", out var SINISMES_OCORR_HISTORICO) && SINISMES_OCORR_HISTORICO == "0006");
                Assert.True(envList[1].TryGetValue("SINISHIS_COD_OPERACAO", out var SINISHIS_COD_OPERACAO) && SINISHIS_COD_OPERACAO == "0001");
                Assert.True(envList[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2020-10-10");
                Assert.True(envList[1].TryGetValue("SINISHIS_NOME_FAVORECIDO", out var SINISHIS_NOME_FAVORECIDO) && SINISHIS_NOME_FAVORECIDO == "                                        ");
                Assert.True(envList[1].TryGetValue("SINISHIS_VAL_OPERACAO", out var SINISHIS_VAL_OPERACAO) && SINISHIS_VAL_OPERACAO == "0000000000000.00");
                Assert.True(envList[1].TryGetValue("SINISHIS_TIPO_FAVORECIDO", out var SINISHIS_TIPO_FAVORECIDO) && SINISHIS_TIPO_FAVORECIDO == " ");
                Assert.True(envList[1].TryGetValue("SINISMES_COD_FONTE", out var SINISMES_COD_FONTE) && SINISMES_COD_FONTE == "0003");
                Assert.True(envList[1].TryGetValue("SINISHIS_SIT_CONTABIL", out var SINISHIS_SIT_CONTABIL) && SINISHIS_SIT_CONTABIL == " ");
                Assert.True(envList[1].TryGetValue("SINISHIS_SIT_REGISTRO", out var SINISHIS_SIT_REGISTRO) && SINISHIS_SIT_REGISTRO == "1");
                Assert.True(envList[1].TryGetValue("SIARDEVC_NUM_APOLICE", out var SIARDEVC_NUM_APOLICE) && SIARDEVC_NUM_APOLICE == "0000000000123");
                Assert.True(envList[1].TryGetValue("SINISMES_COD_PRODUTO", out var SINISMES_COD_PRODUTO) && SINISMES_COD_PRODUTO == "0004");

                #endregion

                #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var envList1 = AppSettings.TestSet.DynamicData["R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("SINISMES_OCORR_HISTORICO", out var SINISMES_OCORR_HISTORICO1) && SINISMES_OCORR_HISTORICO1 == "0006");
                Assert.True(envList1[1].TryGetValue("SINISMES_SALDO_PAGAR_IX", out var SINISMES_SALDO_PAGAR_IX) && SINISMES_SALDO_PAGAR_IX == "0000000002.00000");
                Assert.True(envList1[1].TryGetValue("SINISMES_SIT_REGISTRO", out var SINISMES_SIT_REGISTRO) && SINISMES_SIT_REGISTRO == "2");
                Assert.True(envList1[1].TryGetValue("SIARDEVC_NUM_APOL_SINISTRO", out var SIARDEVC_NUM_APOL_SINISTRO1) && SIARDEVC_NUM_APOL_SINISTRO1 == "0000000000123");
            
                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var envList2 = AppSettings.TestSet.DynamicData["R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("SIARDEVC_COD_ERRO", out var SIARDEVC_COD_ERRO) && SIARDEVC_COD_ERRO == "0000");
                Assert.True(envList2[1].TryGetValue("IND_COD_ERRO", out var IND_COD_ERRO) && IND_COD_ERRO == "-001");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_STA_PROCESSAMENTO", out var SIARDEVC_STA_PROCESSAMENTO) && SIARDEVC_STA_PROCESSAMENTO == "1");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_OCORR_HISTORICO", out var SIARDEVC_OCORR_HISTORICO) && SIARDEVC_OCORR_HISTORICO == "0006");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_TIPO_REGISTRO", out var SIARDEVC_TIPO_REGISTRO) && SIARDEVC_TIPO_REGISTRO == "1");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_SEQ_REGISTRO", out var SIARDEVC_SEQ_REGISTRO) && SIARDEVC_SEQ_REGISTRO == "000000002");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_NOM_ARQUIVO", out var SIARDEVC_NOM_ARQUIVO) && SIARDEVC_NOM_ARQUIVO == "X       ");
                Assert.True(envList2[1].TryGetValue("SIARDEVC_SEQ_GERACAO", out var SIARDEVC_SEQ_GERACAO) && SIARDEVC_SEQ_GERACAO == "000000000");

                #endregion

                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Fact]
        public static void SI9105B_Tests99_Fact()
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

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9105B_C01_SIARDEVC
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI9105B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9105B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SINISMES_SALDO_PAGAR_IX" , "2"},
                { "SINISMES_COD_FONTE" , "3"},
                { "SINISMES_COD_PRODUTO" , "4"},
                { "SINISMES_OCORR_HISTORICO" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "123"},
                { "HOST_NUM_EXPEDIENTE_VC" , "123"},
                { "HOST_COD_COBERTURA" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "1"},
                { "SINISMES_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SINISHIS_NOME_FAVORECIDO" , "2"},
                { "SINISHIS_VAL_OPERACAO" , "120"},
                { "SINISHIS_TIPO_FAVORECIDO" , "1"},
                { "SINISMES_COD_FONTE" , "1"},
                { "SINISHIS_SIT_CONTABIL" , "1"},
                { "SINISHIS_SIT_REGISTRO" , "1"},
                { "SIARDEVC_NUM_APOLICE" , "123"},
                { "SINISMES_COD_PRODUTO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , "1"},
                { "SINISMES_SALDO_PAGAR_IX" , "120"},
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SIARDEVC_NUM_APOL_SINISTRO" , "13"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion

                var program = new SI9105B();
                program.Execute();
              
                Assert.True(program.RETURN_CODE == 99);

            }
        }

    }
}