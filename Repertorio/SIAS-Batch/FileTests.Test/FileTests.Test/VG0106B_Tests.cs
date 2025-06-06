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
using static Code.VG0106B;

namespace FileTests.Test
{
    [Collection("VG0106B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0106B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VG0106B_V1FATURCONT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_NUM_APOL" , ""},
                { "V1FATC_COD_SUBG" , ""},
                { "V1FATC_DATA_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0106B_V1FATURCONT", q0);

            #endregion

            #region R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_FATUR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_CODOPER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_FATUR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_CODOPER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_PERI_FATUR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTREFER" , ""},
                { "V1FATC_NUM_APOL" , ""},
                { "V1FATC_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0SOLI_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0106B_Tests_Fact()
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

                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_FATUR" , "123"}
                });
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1", q1);


                #endregion
                var program = new VG0106B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("WHOST_DTREFER", out string valor) && valor == "0001-23-00");

            }
        }
    }
}