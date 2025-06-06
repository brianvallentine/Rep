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
using static Code.CB1264B;

namespace FileTests.Test
{
    [Collection("CB1264B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB1264B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB1264B_C0CBAPOVIG

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("CB1264B_C0CBAPOVIG", q1);

            #endregion

            #region CB1264B_C0PARCELAS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_HORA_OPERACAO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1264B_C0PARCELAS", q2);

            #endregion

            #region R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_SINISTROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_QTD_FOLLOW_UP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_CM_PRM_TARIFARIO" , ""},
                { "WS_CM_VAL_DESCONTO" , ""},
                { "WS_CM_PRM_LIQUIDO" , ""},
                { "WS_CM_ADICIONAL_FRACIO" , ""},
                { "WS_CM_VAL_CUSTO_EMISSAO" , ""},
                { "WS_CM_VAL_IOCC" , ""},
                { "WS_CM_PRM_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_HORA_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_HORA_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "WS_CM_PRM_TARIFARIO" , ""},
                { "WS_CM_VAL_DESCONTO" , ""},
                { "WS_CM_PRM_LIQUIDO" , ""},
                { "WS_CM_ADICIONAL_FRACIO" , ""},
                { "WS_CM_VAL_CUSTO_EMISSAO" , ""},
                { "WS_CM_VAL_IOCC" , ""},
                { "WS_CM_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3050_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "CBAPOVIG_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1", q14);

            #endregion

            #endregion
        }

        [Fact]
        public static void CB1264B_Tests_Fact_ProcessedOk_ReturnCode_0()
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-05-03"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , "10"},
                { "APOLICES_RAMO_EMISSOR" , "68"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1", q5);

                #endregion
                #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , "901500"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q6);

                #endregion
                #region CB1264B_C0PARCELAS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "6501000001"},
                { "PARCEHIS_NUM_ENDOSSO" , "123"},
                { "PARCEHIS_NUM_PARCELA" , "456"},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_HORA_OPERACAO" , "09:10:25"},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , "2024-07-31"},
                { "PARCEHIS_BCO_COBRANCA" , "104"},
                { "PARCEHIS_AGE_COBRANCA" , "630"},
                { "PARCELAS_OCORR_HISTORICO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1264B_C0PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1264B_C0PARCELAS", q2);

                #endregion
                #region CB1264B_C0CBAPOVIG

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , "101100002240"}
                });
                AppSettings.TestSet.DynamicData.Remove("CB1264B_C0CBAPOVIG");
                AppSettings.TestSet.DynamicData.Add("CB1264B_C0CBAPOVIG", q1);

                #endregion
                #endregion
                var program = new CB1264B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("NUMERAES_ENDOS_CANCELA", out var valor0) && valor0.Contains("000901501"));

                //R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PARCEHIS_NUM_APOLICE", out var valor1) && valor1.Contains("0006501000001"));
                Assert.True(envList1.Count > 1);

                //R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PARCEHIS_NUM_PARCELA", out var valor2) && valor2.Contains("456"));

                //R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("ENDOSSOS_NUM_ENDOSSO", out var valor3) && valor3.Contains("123"));

                //R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("CBAPOVIG_NUM_APOLICE", out var valor4) && valor4.Contains("0101100002240"));

                //R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("APOLICES_RAMO_EMISSOR", out var valor5) && valor5.Contains("68"));
                Assert.True(envList5.Count > 1);

            }
        }
        [Fact]
        public static void CB1264B_Tests_Fact_NoProcessingReturnCode_0()
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-05-03"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region CB1264B_C0CBAPOVIG

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("CB1264B_C0CBAPOVIG");
                AppSettings.TestSet.DynamicData.Add("CB1264B_C0CBAPOVIG", q1);

                #endregion
                #endregion
                var program = new CB1264B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(q1.DynamicList.Count == 0);


            }
        }
        [Fact]
        public static void CB1264B_Tests_Fact_QueryErrorReturnCode_99()
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-05-03"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region CB1264B_C0CBAPOVIG

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , "101100002240"}
                });

                AppSettings.TestSet.DynamicData.Remove("CB1264B_C0CBAPOVIG");
                AppSettings.TestSet.DynamicData.Add("CB1264B_C0CBAPOVIG", q1);

                #endregion

                #region R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1", q5);

                #endregion
                #endregion
                var program = new CB1264B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);


            }
        }
    }
}