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
using static Code.CS1301B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("CS1301B_Tests")]
    public class CS1301B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
           
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_6D" , ""},
                { "SISTEMAS_DATA_MOV_1D" , ""},
                { "WHOST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_PROX_INICIAL" , ""},
                { "RELATORI_PROX_FINAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_PROX_INICIAL" , ""},
                { "RELATORI_PROX_FINAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q2);

            #endregion

            #region CS1301B_PARCELAS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "APOLIAUT_NUM_PROPOSTA_CONV" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DIFERENCA1" , ""},
                { "PARCEHIS_DIFERENCA2" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CS1301B_PARCELAS", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CS1301B_t1")]
        public static void CS1301B_Tests_Theory(string CS1301BO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CS1301BO_FILE_NAME_P = $"{CS1301BO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                CS0701S_Tests.Load_Parameters();
                #region CS0701S_CURGE190

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GE190_COD_PARAMETRO" , "0"},
                { "GE190_COD_PRODUTO" , "1"},
                { "GE190_STA_PARAMETRO" , "2"},
                { "GE190_NOM_CLASSE_PARAM" , "X"},
                { "GE190_COD_SISTEMA" , "3"},
                { "GE190_DTA_INI_VIGENCA" , "2020-01-01"},
                { "GE190_DTA_FIM_VIGENCIA" , "2020-01-01"},
                { "GE190_DES_PARAMETRO" , "X"},
                { "GE190_IND_TP_PARAMETRO" , "4"},
                { "GE190_VLR_PARAMETRO" , "100"},
                { "GE190_VLR_PARAM_INT" , "100"},
                { "GE190_PCT_PARAMETRO" , "1"},
                { "GE190_VLR_PARAM_TAXA" , "10"},
                { "GE190_DTA_PARAMETRO" , "2020-01-01"},
                { "GE190_VLR_PARAM_REDUZIDO" , "10"},
                { "GE190_VLR_PARAM_EXTENDIDO" , "10"},
            });
                AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
                AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q4);
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_6D" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_1D" , "2020-01-01"},
                { "WHOST_DTCURRENT" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2020-01-01"},
                { "RELATORI_DATA_REFERENCIA" , "2020-01-01"},
                { "RELATORI_PERI_INICIAL" , "2020-01-01"},
                { "RELATORI_PERI_FINAL" , "2020-01-01"},
                { "RELATORI_PROX_INICIAL" , "2020-01-01"},
                { "RELATORI_PROX_FINAL" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

                #endregion

                #region CS1301B_PARCELAS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "123"},
                { "ENDOSSOS_NUM_APOLICE" , "123"},
                { "ENDOSSOS_NUM_ENDOSSO" , "123"},
                { "PARCEHIS_NUM_PARCELA" , "0"},
                { "ENDOSSOS_DATA_EMISSAO" , "2020-01-01"},
                { "ENDOSSOS_NUM_RCAP" , "123"},
                { "APOLIAUT_NUM_PROPOSTA_CONV" , "123"},
                { "PARCEHIS_DATA_VENCIMENTO" , "2020-01-01"},
                { "PARCEHIS_DATA_QUITACAO" , "2020-01-01"},
                { "ENDOSSOS_VAL_RCAP" , "100"},
                { "PARCEHIS_PRM_TOTAL" , "100"},
                { "PARCEHIS_VAL_OPERACAO" , "100"},
                { "PARCEHIS_DIFERENCA1" , "10"},
                { "PARCEHIS_DIFERENCA2" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("CS1301B_PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CS1301B_PARCELAS", q3);

                #endregion
               
                #endregion
                var program = new CS1301B();
                program.Execute(CS1301BO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2020-01-01");
                Assert.True(envList[1].TryGetValue("RELATORI_PROX_INICIAL", out var RELATORI_PROX_INICIAL) && RELATORI_PROX_INICIAL == "2020-01-01");
                Assert.True(envList[1].TryGetValue("RELATORI_PROX_FINAL", out var RELATORI_PROX_FINAL) && RELATORI_PROX_FINAL == "2020-01-01");

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("CS1301B_t2")]
        public static void CS1301B_Tests99_Theory(string CS1301BO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CS1301BO_FILE_NAME_P = $"{CS1301BO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                CS0701S_Tests.Load_Parameters();
                #region CS0701S_CURGE190

                var q4 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
                AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q4);
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_6D" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_1D" , "2020-01-01"},
                { "WHOST_DTCURRENT" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2020-01-01"},
                { "RELATORI_DATA_REFERENCIA" , "2020-01-01"},
                { "RELATORI_PERI_INICIAL" , "2020-01-01"},
                { "RELATORI_PERI_FINAL" , "2020-01-01"},
                { "RELATORI_PROX_INICIAL" , "2020-01-01"},
                { "RELATORI_PROX_FINAL" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

                #endregion

                #region CS1301B_PARCELAS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "123"},
                { "ENDOSSOS_NUM_APOLICE" , "123"},
                { "ENDOSSOS_NUM_ENDOSSO" , "123"},
                { "PARCEHIS_NUM_PARCELA" , "0"},
                { "ENDOSSOS_DATA_EMISSAO" , "2020-01-01"},
                { "ENDOSSOS_NUM_RCAP" , "123"},
                { "APOLIAUT_NUM_PROPOSTA_CONV" , "123"},
                { "PARCEHIS_DATA_VENCIMENTO" , "2020-01-01"},
                { "PARCEHIS_DATA_QUITACAO" , "2020-01-01"},
                { "ENDOSSOS_VAL_RCAP" , "100"},
                { "PARCEHIS_PRM_TOTAL" , "100"},
                { "PARCEHIS_VAL_OPERACAO" , "100"},
                { "PARCEHIS_DIFERENCA1" , "10"},
                { "PARCEHIS_DIFERENCA2" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("CS1301B_PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CS1301B_PARCELAS", q3);

                #endregion

                #endregion
                var program = new CS1301B();
                program.Execute(CS1301BO_FILE_NAME_P);

              

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}