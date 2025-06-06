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
using static Code.SI0896B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0896B_Tests")]
    public class SI0896B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0896B_C1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0896B_C1", q0);

            #endregion

            #region SI0896B_CTRAB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINIPLAN_DT_PRI_PREST_PAGA" , ""},
                { "SINIPLAN_DT_ULT_PREST_PAGA" , ""},
                { "SINIHAB1_COD_COBERTURA" , ""},
                { "SINIPLAN_NUM_APOL_SINISTRO" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIPLAN_PERC_PARTICIPACAO" , ""},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_INDENIZACAO" , ""},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , ""},
                { "SINIPLAN_NUM_ULT_PREST_PAGA" , ""},
                { "SINIPLAN_OCORHIST" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "HOST_NUM_CONTRATO" , ""},
                { "SINIPLAN_DATA_INDENIZACAO" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0896B_CTRAB", q1);

            #endregion

            #region M_000_900_FIM_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_000_900_FIM_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUMERO_SIVAT" , ""},
                { "RALCHEDO_DATA_SIVAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1", q4);

            #endregion

            #region R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_ACORRIGIR" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "SINIPLAN_PERC_PARTICIPACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1", q5);

            #endregion

            #region R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_FRANQUIA_CEF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1", q6);

            #endregion

            #region R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_PRM_REMANESC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0896B_t1")]
        public static void SI0896B_Tests_Theory(string ARQCALC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQCALC_FILE_NAME_P = $"{ARQCALC_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0896B_C1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , "2020-01-01"},
                { "RELATORI_PERI_FINAL" , "2020-01-01"},
                { "RELATORI_COD_PRODUTOR" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0896B_C1");
                AppSettings.TestSet.DynamicData.Add("SI0896B_C1", q0);

                #endregion

                #region SI0896B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "1"},
                { "PRODUTO_DESCR_PRODUTO" , "X"},
                { "SINIPLAN_DT_PRI_PREST_PAGA" , "2020-01-01"},
                { "SINIPLAN_DT_ULT_PREST_PAGA" ,"2020-01-01"},
                { "SINIHAB1_COD_COBERTURA" , "2"},
                { "SINIPLAN_NUM_APOL_SINISTRO" , "3"},
                { "SINIHAB1_NOME_SEGURADO" , "X"},
                { "SINIPLAN_PERC_PARTICIPACAO" , "0"},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , "100"},
                { "SINIPLAN_VAL_INDENIZACAO" , "100"},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , "0"},
                { "SINIPLAN_NUM_ULT_PREST_PAGA" , "6"},
                { "SINIPLAN_OCORHIST" , "7"},
                { "SINIHAB1_PONTO_VENDA" , "8"},
                { "HOST_NUM_CONTRATO" , "9"},
                { "SINIPLAN_DATA_INDENIZACAO" , "2020-01-01"},
                { "SINIPLAN_VAL_PREMIO" , "100"},
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "12"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0896B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0896B_CTRAB", q1);

                #endregion

                #region R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISHIS_VAL_OPERACAO" , "100"},
            });
                AppSettings.TestSet.DynamicData.Remove("R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUMERO_SIVAT" , "1"},
                { "RALCHEDO_DATA_SIVAT" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , "100"},
                { "SINIPLAN_VAL_ACORRIGIR" , "100"},
                { "SINIPLAN_VAL_PREMIO" , "100"},
                { "SINIPLAN_PERC_PARTICIPACAO" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1", q5);

                #endregion

                #region R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_FRANQUIA_CEF" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1", q6);

                #endregion

                #region R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_PRM_REMANESC" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1", q7);

                #endregion
              
                #endregion
                var program = new SI0896B();
                program.Execute(ARQCALC_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region M_000_900_FIM_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["M_000_900_FIM_DB_UPDATE_1_Update1"].DynamicList;
                
                Assert.True(envList?.Count > 1);

                #endregion

                Assert.True(program.WABEND2.WSQLCODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0896B_t2")]
        public static void SI0896B_Tests99_Theory(string ARQCALC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQCALC_FILE_NAME_P = $"{ARQCALC_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region SI0896B_C1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , "2020-01-01"},
                { "RELATORI_PERI_FINAL" , "2020-01-01"},
                { "RELATORI_COD_PRODUTOR" , "1"},
            });
               

                #endregion

                #region SI0896B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "1"},
                { "PRODUTO_DESCR_PRODUTO" , "X"},
                { "SINIPLAN_DT_PRI_PREST_PAGA" , "2020-01-01"},
                { "SINIPLAN_DT_ULT_PREST_PAGA" ,"2020-01-01"},
                { "SINIHAB1_COD_COBERTURA" , "2"},
                { "SINIPLAN_NUM_APOL_SINISTRO" , "3"},
                { "SINIHAB1_NOME_SEGURADO" , "X"},
                { "SINIPLAN_PERC_PARTICIPACAO" , "0"},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , "100"},
                { "SINIPLAN_VAL_INDENIZACAO" , "100"},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , "0"},
                { "SINIPLAN_NUM_ULT_PREST_PAGA" , "6"},
                { "SINIPLAN_OCORHIST" , "7"},
                { "SINIHAB1_PONTO_VENDA" , "8"},
                { "HOST_NUM_CONTRATO" , "9"},
                { "SINIPLAN_DATA_INDENIZACAO" , "2020-01-01"},
                { "SINIPLAN_VAL_PREMIO" , "100"},
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "12"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0896B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0896B_CTRAB", q1);

                #endregion

                #region R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1

                var q3 = new DynamicData();            
                AppSettings.TestSet.DynamicData.Remove("R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1", q3);

                #endregion

                #region R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_NUMERO_SIVAT" , "1"},
                { "RALCHEDO_DATA_SIVAT" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1", q4);

                #endregion

                #region R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_ACORRIGIR" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "SINIPLAN_PERC_PARTICIPACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1", q5);

                #endregion

                #region R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_FRANQUIA_CEF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1", q6);

                #endregion

                #region R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_PRM_REMANESC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0896B();
                program.Execute(ARQCALC_FILE_NAME_P);

                Assert.True(program.WABEND2.WSQLCODE == 100);
            
                
            }
        }

    }
}