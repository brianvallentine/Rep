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
using static Code.BI0097B;

namespace FileTests.Test
{
    [Collection("BI0097B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class BI0097B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DATA030" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI0097B_V0ENDOSSO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "WSHOST_COUNT" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0097B_V0ENDOSSO", q1);

            #endregion

            #region BI0097B_C0PARCEHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0097B_C0PARCEHIS", q2);

            #endregion

            #region R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1090_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1090_00_SELECT_APOLICES_DB_SELECT_1_Query1", q5);

            #endregion

            #region BI0097B_C0PARCELAS

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("BI0097B_C0PARCELAS", q6);

            #endregion

            #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_CANCELA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q8);

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

            #region R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "VIND_NULL01" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "APOLICES_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void BI0097B_Tests_Theory_Erro99(string SBI0097B_FILE_NAME_P)
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DATA030" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new BI0097B();
                program.Execute(SBI0097B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void BI0097B_Tests_Theory(string SBI0097B_FILE_NAME_P)
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-05-01"},
                { "WSHOST_DATA030" , "2020-06-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI0097B_V0ENDOSSO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "800000"},
                { "WSHOST_COUNT" , "3"},
                { "PARCEHIS_DATA_VENCIMENTO" , "2020-03-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0097B_V0ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("BI0097B_V0ENDOSSO", q1);

                #endregion

                #region BI0097B_C0PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "800000"},
                { "PARCEHIS_NUM_ENDOSSO" , "300"},
                { "PARCEHIS_NUM_PARCELA" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "800000"},
                { "PARCEHIS_NUM_ENDOSSO" , "301"},
                { "PARCEHIS_NUM_PARCELA" , "2"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "800000"},
                { "PARCEHIS_NUM_ENDOSSO" , "302"},
                { "PARCEHIS_NUM_PARCELA" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0097B_C0PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("BI0097B_C0PARCEHIS", q2);

                #endregion

                #region R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "800000"}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_NUM_APOLICE" , "800000"}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1", q4);

                #endregion

                #endregion
                var program = new BI0097B();
                program.Execute(SBI0097B_FILE_NAME_P);

                //R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("NUMERAES_ENDOS_CANCELA", out var valor) && valor.Contains("1"));
                Assert.True(envList.Count > 1);

                //R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PARCEHIS_COD_OPERACAO", out var valor1) && valor1.Contains("401"));
                Assert.True(envList1.Count > 1);

                //R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PARCELAS_SIT_REGISTRO", out var valor2) && valor2.Contains("2"));
                Assert.True(envList2.Count > 1);

                //R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("ENDOSSOS_SIT_REGISTRO", out var valor3) && valor3.Contains("2"));
                Assert.True(envList3.Count > 1);

                //R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("BILHETE_SITUACAO", out var valor4) && valor4.Contains("P"));
                Assert.True(envList4.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}