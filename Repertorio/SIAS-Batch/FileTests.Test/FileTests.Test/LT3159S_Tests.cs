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
using static Code.LT3159S;

namespace FileTests.Test
{
    [Collection("LT3159S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3159S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region LT3159S_LTSOLPAR1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_SMINT03" , ""},
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT3159S_LTSOLPAR1", q0);

            #endregion

            #region R1200_00_CONSULTA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CONSULTA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1305_00_INSERT_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PRODUTO" , ""},
                { "LTSOLPAR_COD_CLIENTE" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_TIPO_SOLICITACAO" , ""},
                { "LTSOLPAR_COD_USUARIO" , ""},
                { "LTSOLPAR_DATA_PREV_PROC" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_SMINT02" , ""},
                { "LTSOLPAR_PARAM_SMINT03" , ""},
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_INTG02" , ""},
                { "LTSOLPAR_PARAM_INTG03" , ""},
                { "LTSOLPAR_PARAM_DEC01" , ""},
                { "LTSOLPAR_PARAM_DEC02" , ""},
                { "LTSOLPAR_PARAM_DEC03" , ""},
                { "LTSOLPAR_PARAM_FLOAT01" , ""},
                { "LTSOLPAR_PARAM_FLOAT02" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR02" , ""},
                { "LTSOLPAR_PARAM_CHAR03" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1305_00_INSERT_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "WS_DTINIVIG_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1", q13);

            #endregion

            #region R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1", q14);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1", q15);

            #endregion

            #endregion
        }
        public static void Load_Parameters_To_EM0030B()
        {
            #region PARAMETERS
            #region LT3159S_LTSOLPAR1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_SMINT03" , ""},
                { "LTSOLPAR_PARAM_INTG01" , "60.00"},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("LT3159S_LTSOLPAR1", q0);

            #endregion

            #region R1200_00_CONSULTA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_INTG01" , "60.00"},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_CONSULTA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1305_00_INSERT_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PRODUTO" , ""},
                { "LTSOLPAR_COD_CLIENTE" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_TIPO_SOLICITACAO" , ""},
                { "LTSOLPAR_COD_USUARIO" , ""},
                { "LTSOLPAR_DATA_PREV_PROC" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_SMINT02" , ""},
                { "LTSOLPAR_PARAM_SMINT03" , ""},
                { "LTSOLPAR_PARAM_INTG01" , "60.00"},
                { "LTSOLPAR_PARAM_INTG02" , ""},
                { "LTSOLPAR_PARAM_INTG03" , ""},
                { "LTSOLPAR_PARAM_DEC01" , ""},
                { "LTSOLPAR_PARAM_DEC02" , ""},
                { "LTSOLPAR_PARAM_DEC03" , ""},
                { "LTSOLPAR_PARAM_FLOAT01" , ""},
                { "LTSOLPAR_PARAM_FLOAT02" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR02" , ""},
                { "LTSOLPAR_PARAM_CHAR03" , ""},
                { "LTSOLPAR_PARAM_CHAR04" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1305_00_INSERT_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_PARAM_INTG01" , "60.00"},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "WS_DTINIVIG_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_INTG01" , "60.00"},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_CHAR04" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1", q13);

            #endregion

            #region R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1", q14);

            #endregion

            #region R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3159S_Tests_Fact_Erro100()
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
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();
                program.Execute(parm);

                Assert.True(parm.LT3159S_COD_RETORNO.Value == 100);
            }
        }

        [Fact]
        public static void LT3159S_Tests_Fact_InclParm()
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

                #region R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1", q6);

                #endregion

                #endregion
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();

                parm.LT3159S_COD_PRODUTO.Value = 200;
                parm.LT3159S_DATA_INIVIGENCIA.Value = "2020-02-02";
                parm.LT3159S_OPERACAO.Value = "01";
                parm.LT3159S_TIPO_PARAM.Value = 1;
                parm.LT3159S_PARAM.Value = 3;

                program.Execute(parm);

                //R1305_00_INSERT_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R1305_00_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("LTSOLPAR_COD_PRODUTO", out var valor) && valor.Contains("0200"));
                Assert.True(envList.Count > 1);

                //R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("LTSOLPAR_COD_PRODUTO", out var valor2) && valor2.Contains("0200"));
                Assert.True(envList2.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void LT3159S_Tests_AlterParm1()
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
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();

                parm.LT3159S_COD_PRODUTO.Value = 200;
                parm.LT3159S_DATA_INIVIGENCIA.Value = "2020-02-02";
                parm.LT3159S_OPERACAO.Value = "02";
                parm.LT3159S_TIPO_PARAM.Value = 1;
                parm.LT3159S_PARAM.Value = 1;

                program.Execute(parm);

                var envList = AppSettings.TestSet.DynamicData["R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("LTSOLPAR_PARAM_DATE01", out var valor) && valor.Contains("2020-02-02"));
                Assert.True(envList.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void LT3159S_Tests_AlterParm2()
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
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();

                parm.LT3159S_COD_PRODUTO.Value = 200;
                parm.LT3159S_DATA_INIVIGENCIA.Value = "2020-02-02";
                parm.LT3159S_OPERACAO.Value = "02";
                parm.LT3159S_TIPO_PARAM.Value = 2;
                parm.LT3159S_PARAM.Value = 1;

                program.Execute(parm);

                var envList = AppSettings.TestSet.DynamicData["R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("LTSOLPAR_PARAM_DATE01", out var valor) && valor.Contains("2020-02-02"));
                Assert.True(envList.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void LT3159S_Tests_AlterParm3()
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
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();

                parm.LT3159S_COD_PRODUTO.Value = 200;
                parm.LT3159S_DATA_INIVIGENCIA.Value = "2020-02-02";
                parm.LT3159S_OPERACAO.Value = "02";
                parm.LT3159S_TIPO_PARAM.Value = 3;
                parm.LT3159S_PARAM.Value = 1;

                program.Execute(parm);

                var envList = AppSettings.TestSet.DynamicData["R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("LTSOLPAR_PARAM_DATE01", out var valor) && valor.Contains("2020-02-02"));
                Assert.True(envList.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void LT3159S_Tests_ExcluirParm()
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
                var program = new LT3159S();
                var parm = new LBLT3159_LT3159S_AREA_PARAMETROS();

                parm.LT3159S_COD_PRODUTO.Value = 200;
                parm.LT3159S_DATA_INIVIGENCIA.Value = "2020-02-02";
                parm.LT3159S_OPERACAO.Value = "05";
                parm.LT3159S_TIPO_PARAM.Value = 1;
                parm.LT3159S_PARAM.Value = 1;

                program.Execute(parm);

                var envList = AppSettings.TestSet.DynamicData["R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList);
                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}