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
using static Code.BI0094B;

namespace FileTests.Test
{
    [Collection("BI0094B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0094B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region BI0094B_V0BILHETE

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0094B_V0BILHETE", q0);

            #endregion

            #region BI0094B_C2_EXPIRADOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0094B_C2_EXPIRADOS", q1);

            #endregion

            #region BI0094B_C3_EXP_PRD

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0094B_C3_EXP_PRD", q2);

            #endregion

            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DATA060" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_CANCELAMENTO" , "2016-04-15"},
                { "VIND_NULL01" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , "4"},
                { "BILHETE_SITUACAO" , "V"},
                { "BILHETE_NUM_BILHETE" , "167"},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "78"}
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0094B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_APOLICE" , "108210598078"}
                });
                AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1", q1);
                #endregion

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WSHOST_DATA060" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);
                #endregion

                var program = new BI0094B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("BILHETE_NUM_BILHETE", out string valor) && valor == "000000000000000");
                Assert.True(envList1[1].TryGetValue("BILHETE_NUM_BILHETE", out string valor1) && valor1 == "000000000000000");

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1 || x.Value.DynamicList.Count == 0);
                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void BI0094B_Tests_Fact_Erro99()
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
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);
                #endregion

                #endregion

                var program = new BI0094B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}