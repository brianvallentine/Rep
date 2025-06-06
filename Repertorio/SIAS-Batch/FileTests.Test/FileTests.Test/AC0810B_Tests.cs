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
using static Code.AC0810B;

namespace FileTests.Test
{
    [Collection("AC0810B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class AC0810B_Tests
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

            #region AC0810B_C01_COSHISPR

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISPR_COD_EMPRESA" , ""},
                { "COSHISPR_COD_CONGENERE" , ""},
                { "COSHISPR_NUM_APOLICE" , ""},
                { "COSHISPR_NUM_ENDOSSO" , ""},
                { "COSHISPR_NUM_PARCELA" , ""},
                { "COSHISPR_OCORR_HISTORICO" , ""},
                { "COSHISPR_COD_OPERACAO" , ""},
                { "COSHISPR_DATA_MOVIMENTO" , ""},
                { "COSHISPR_TIPO_SEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0810B_C01_COSHISPR", q1);

            #endregion

            #region R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PRODUTO_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "COSHISPR_COD_CONGENERE" , ""},
                { "COSHISPR_NUM_APOLICE" , ""},
                { "COSHISPR_NUM_ENDOSSO" , ""},
                { "COSHISPR_NUM_PARCELA" , ""},
                { "COSHISPR_TIPO_SEGURO" , ""},
                { "COSHISPR_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "COSHISPR_OCORR_HISTORICO" , ""},
                { "COSHISPR_DATA_MOVIMENTO" , ""},
                { "COSHISPR_COD_CONGENERE" , ""},
                { "COSHISPR_COD_OPERACAO" , ""},
                { "COSHISPR_NUM_APOLICE" , ""},
                { "COSHISPR_NUM_ENDOSSO" , ""},
                { "COSHISPR_NUM_PARCELA" , ""},
                { "COSHISPR_TIPO_SEGURO" , ""},
                { "COSHISPR_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0810B_Tests_Fact()
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
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_COD_EMPRESA" , "0001"},
                    { "PRODUTO_COD_PRODUTO" , "0001"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);
                #endregion
                var program = new AC0810B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.Empty(AppSettings.TestSet.DynamicData["AC0810B_C01_COSHISPR"].DynamicList.ToList());

                var update1 = AppSettings.TestSet.DynamicData["R0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1?.Count > 1);
                Assert.True(update1[1].Values.Contains("000000001"));

                var update2 = AppSettings.TestSet.DynamicData["R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update2?.Count > 1);
                Assert.True(update2[1].Values.Contains("000000001"));

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}