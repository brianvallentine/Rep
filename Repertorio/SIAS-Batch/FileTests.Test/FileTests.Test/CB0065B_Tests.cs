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
using static Code.CB0065B;

namespace FileTests.Test
{
    [Collection("CB0065B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0065B_Tests
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
                { "WSHOST_DATA_CURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_DATA_INIVIGENCIA" , ""},
                { "WSHOST_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q2);

            #endregion

            #region CB0065B_V0CALENDARIO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0065B_V0CALENDARIO", q3);

            #endregion

            #region CB0065B_V0MOVDEBCE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0065B_V0MOVDEBCE", q4);

            #endregion

            #region CB0065B_V1MOVDEBCE

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0065B_V1MOVDEBCE", q5);

            #endregion

            #region R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DATA_UTEIS01" , ""},
                { "PARAMCON_NSAS" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DATA_UTEIS07" , ""},
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB0065B_Saida1.txt", "CB0065B_Saida2.txt", "CB0065_BSaida3.txt", "CB0065B_Saida4.txt")]
        public static void CB0065B_Tests_Theory_ProcessFinished_ReturnCode_0(string MOV605100_CC_FILE_NAME_P, string MOV600139_CC_FILE_NAME_P, string MOV600140_CC_FILE_NAME_P, string RCB0065B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV605100_CC_FILE_NAME_P = $"{MOV605100_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600139_CC_FILE_NAME_P = $"{MOV600139_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600140_CC_FILE_NAME_P = $"{MOV600140_CC_FILE_NAME_P}_{timestamp}.txt";
            RCB0065B_FILE_NAME_P = $"{RCB0065B_FILE_NAME_P}_{timestamp}.txt";
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2005-06-22"},
                { "WSHOST_DATA_CURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_DATA_INIVIGENCIA" , "2021-01-01"},
                { "WSHOST_DATA_TERVIGENCIA" , "2022-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1", q1);

                #endregion
                #region R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion
                #region CB0065B_V0CALENDARIO
                AppSettings.TestSet.DynamicData.Remove("CB0065B_V0CALENDARIO");

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-05"},
                { "CALENDAR_DIA_SEMANA" , "E"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-06"},
                { "CALENDAR_DIA_SEMANA" , "2"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-07"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-08"},
                { "CALENDAR_DIA_SEMANA" , "4"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-09"},
                { "CALENDAR_DIA_SEMANA" , "5"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-10"},
                { "CALENDAR_DIA_SEMANA" , "6"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-11"},
                { "CALENDAR_DIA_SEMANA" , "S"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-12"},
                { "CALENDAR_DIA_SEMANA" , "D"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-13"},
                { "CALENDAR_DIA_SEMANA" , "2"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-14"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                }); q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-15"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                }); q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-16"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                }); q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-17"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                });


                AppSettings.TestSet.DynamicData.Add("CB0065B_V0CALENDARIO", q3);

                #endregion
                #region R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_TIPO_MOVTO_CC" , "1"},
                { "PARAMCON_COD_PRODUTO" , "1803"},
                { "PARAMCON_COD_CONVENIO" , "600119"},
                { "PARAMCON_NSAS" , "1"},
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_TIPO_MOVTO_CC" , "1"},
                { "PARAMCON_COD_PRODUTO" , "1803"},
                { "PARAMCON_COD_CONVENIO" , "600120"},
                { "PARAMCON_NSAS" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1", q6);

                #endregion
                #region CB0065B_V0MOVDEBCE

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "10019790324"},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , "100"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0083"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "1000"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "94000"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "6"},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0065B_V0MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB0065B_V0MOVDEBCE", q4);

                #endregion
                #region CB0065B_V1MOVDEBCE

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "101402336201"},
                { "MOVDEBCE_NUM_ENDOSSO" , "511998"},
                { "MOVDEBCE_NUM_PARCELA" , "0"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2010-01-07"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "215"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "1"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "1480"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "7"},
                { "APOLICES_ORGAO_EMISSOR" , "10"},
                { "ENDOSSOS_COD_PRODUTO" , "1403"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0065B_V1MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("CB0065B_V1MOVDEBCE", q5);

                #endregion
                #region R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , "2"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new CB0065B();
                program.Execute(MOV605100_CC_FILE_NAME_P, MOV600139_CC_FILE_NAME_P, MOV600140_CC_FILE_NAME_P, RCB0065B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var valor0) && valor0.Contains("6051"));

                //R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var valor1) && valor1.Contains("10019790324"));

                //R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PARAMCON_COD_PRODUTO", out var valor2) && valor2.Contains("1803"));

                //R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var valor3) && valor3.Contains("0101400610081"));


            }
        }
        [Theory]
        [InlineData("CB0065B_Saida1.txt", "CB0065B_Saida2.txt", "CB0065_BSaida3.txt", "CB0065B_Saida4.txt")]
        public static void CB0065B_Tests_Theory_DaysValidationError_ReturnCode_99(string MOV605100_CC_FILE_NAME_P, string MOV600139_CC_FILE_NAME_P, string MOV600140_CC_FILE_NAME_P, string RCB0065B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV605100_CC_FILE_NAME_P = $"{MOV605100_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600139_CC_FILE_NAME_P = $"{MOV600139_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600140_CC_FILE_NAME_P = $"{MOV600140_CC_FILE_NAME_P}_{timestamp}.txt";
            RCB0065B_FILE_NAME_P = $"{RCB0065B_FILE_NAME_P}_{timestamp}.txt";
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2005-06-22"},
                { "WSHOST_DATA_CURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_DATA_INIVIGENCIA" , "2021-01-01"},
                { "WSHOST_DATA_TERVIGENCIA" , "2022-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1", q1);

                #endregion
                #region R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion
                #region CB0065B_V0CALENDARIO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-05"},
                { "CALENDAR_DIA_SEMANA" , "D"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-06"},
                { "CALENDAR_DIA_SEMANA" , "2"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-07"},
                { "CALENDAR_DIA_SEMANA" , "3"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-08"},
                { "CALENDAR_DIA_SEMANA" , "4"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-09"},
                { "CALENDAR_DIA_SEMANA" , "5"},
                { "CALENDAR_FERIADO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-10"},
                { "CALENDAR_DIA_SEMANA" , "6"},
                { "CALENDAR_FERIADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0065B_V0CALENDARIO");
                AppSettings.TestSet.DynamicData.Add("CB0065B_V0CALENDARIO", q3);

                #endregion

                #endregion
                var program = new CB0065B();
                program.Execute(MOV605100_CC_FILE_NAME_P, MOV600139_CC_FILE_NAME_P, MOV600140_CC_FILE_NAME_P, RCB0065B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("CB0065B_Saida1.txt", "CB0065B_Saida2.txt", "CB0065_BSaida3.txt", "CB0065B_Saida4.txt")]
        public static void CB0065B_Tests_Theory_NoCompany_ReturnCode_99(string MOV605100_CC_FILE_NAME_P, string MOV600139_CC_FILE_NAME_P, string MOV600140_CC_FILE_NAME_P, string RCB0065B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV605100_CC_FILE_NAME_P = $"{MOV605100_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600139_CC_FILE_NAME_P = $"{MOV600139_CC_FILE_NAME_P}_{timestamp}.txt";
            MOV600140_CC_FILE_NAME_P = $"{MOV600140_CC_FILE_NAME_P}_{timestamp}.txt";
            RCB0065B_FILE_NAME_P = $"{RCB0065B_FILE_NAME_P}_{timestamp}.txt";
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2005-06-22"},
                { "WSHOST_DATA_CURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_DATA_INIVIGENCIA" , "2021-01-01"},
                { "WSHOST_DATA_TERVIGENCIA" , "2022-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1", q1);

                #endregion
                #region R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new CB0065B();
                program.Execute(MOV605100_CC_FILE_NAME_P, MOV600139_CC_FILE_NAME_P, MOV600140_CC_FILE_NAME_P, RCB0065B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}
