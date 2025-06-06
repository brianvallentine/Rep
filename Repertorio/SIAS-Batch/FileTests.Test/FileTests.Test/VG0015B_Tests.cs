//using System;
//using IA_ConverterCommons;
//using System.Collections.Generic;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Linq;
//using _ = IA_ConverterCommons.Statements;
//using DB = IA_ConverterCommons.DatabaseBasis;
//using Xunit;
//using Copies;
//using Code;
//using static Code.VG0015B;

//namespace FileTests.Test
//{
//    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
//    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
//    public class VG0015B_Tests
//    {
//        //é de extrema importancia que este método seja modificado com cautela, 
//        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
//        public static void Load_Parameters()
//        {
//            #region PARAMETERS
//            #region VG0015B_ACOPLADO

//            var q0 = new DynamicData();
//            q0.AddDynamic(new Dictionary<string, string>{
//                { "WS_COD_DOC_PARCEIRO_P" , "123456"},
//                { "WS_COD_PRODUTO" , ""},
//                { "WS_COD_PLANO" , ""},
//                { "VG135_VLR_TITULO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("VG0015B_ACOPLADO", q0);

//            #endregion

//            #region R0600_PROCESSA_ACOPLADO_Query1

//            var q1 = new DynamicData();
//            q1.AddDynamic(new Dictionary<string, string>{
//                { "WS_CURRENT_TIMESTAMP" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0600_PROCESSA_ACOPLADO_Query1", q1);

//            #endregion

//            #region R0700_00_INSERT_COMFEDCA_Insert1

//            var q2 = new DynamicData();
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "WS_NUM_CERTIFICADO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0700_00_INSERT_COMFEDCA_Insert1", q2);

//            #endregion

//            #endregion
//        }

//        [Fact]
//        public static void VG0015B_Tests_Fact()
//        {
//            lock (AppSettings.TestSet._lock)
//            {
//                AppSettings.TestSet.IsTest = true;
//                AppSettings.TestSet.Clear();
//                Load_Parameters();

//                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                #region VARIAVEIS_TESTE
//                #endregion
//                var program = new VG0015B();
//                program.Execute();

//                var envList = AppSettings.TestSet.DynamicData["R0700_00_INSERT_COMFEDCA_Insert1"].DynamicList;
//                Assert.True(envList?.Count > 1);

//                Assert.True(envList[1].TryGetValue("WS_NUM_CERTIFICADO", out string valor) && valor == "000000000123456");

//            }
//        }
//    }
//}