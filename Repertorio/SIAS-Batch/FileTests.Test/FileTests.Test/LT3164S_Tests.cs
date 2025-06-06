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
using static Code.LT3164S;

namespace FileTests.Test
{
    [Collection("LT3164S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3164S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1000_00_PROCESSAR_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PRODUTO" , ""},
                { "LTSOLPAR_COD_CLIENTE" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_TIPO_SOLICITACAO" , ""},
                { "LTSOLPAR_DATA_SOLICITACAO" , ""},
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
                { "LTSOLPAR_PARAM_CHAR05" , ""},
                { "LTSOLPAR_DTH_SOLICITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSAR_DB_INSERT_1_Insert1", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3164S_Tests_Fact()
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
                var program = new LT3164S();

              
                LBLT3164_LT3164S_AREA_PARAMETROS obj = new LBLT3164_LT3164S_AREA_PARAMETROS();
                obj.LT3164S_COD_PROGRAMA.Value = "123";

                ///program.Execute(new LBLT3164_LT3164S_AREA_PARAMETROS());
                ///
                program.Execute(obj);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var envList6 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSAR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_COD_PRODUTO", out var LTSOLPAR_COD_PRODUTO) && LTSOLPAR_COD_PRODUTO == "0000");            
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_COD_CLIENTE", out var LTSOLPAR_COD_CLIENTE) && LTSOLPAR_COD_CLIENTE == "000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_COD_PROGRAMA", out var LTSOLPAR_COD_PROGRAMA) && LTSOLPAR_COD_PROGRAMA == "123         ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_TIPO_SOLICITACAO", out var LTSOLPAR_TIPO_SOLICITACAO) && LTSOLPAR_TIPO_SOLICITACAO == "0000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_COD_USUARIO", out var LTSOLPAR_COD_USUARIO) && LTSOLPAR_COD_USUARIO == "        ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_SIT_SOLICITACAO", out var LTSOLPAR_SIT_SOLICITACAO) && LTSOLPAR_SIT_SOLICITACAO == " ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DATE01", out var LTSOLPAR_PARAM_DATE01) && LTSOLPAR_PARAM_DATE01 == "          ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DATE02", out var LTSOLPAR_PARAM_DATE02) && LTSOLPAR_PARAM_DATE02 == "          ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DATE03", out var LTSOLPAR_PARAM_DATE03) && LTSOLPAR_PARAM_DATE03 == "          ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_SMINT01", out var LTSOLPAR_PARAM_SMINT01) && LTSOLPAR_PARAM_SMINT01 == "0000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_SMINT02", out var LTSOLPAR_PARAM_SMINT02) && LTSOLPAR_PARAM_SMINT02 == "0000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_SMINT03", out var LTSOLPAR_PARAM_SMINT03) && LTSOLPAR_PARAM_SMINT03 == "0000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_INTG01", out var LTSOLPAR_PARAM_INTG01) && LTSOLPAR_PARAM_INTG01 == "000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_INTG02", out var LTSOLPAR_PARAM_INTG02) && LTSOLPAR_PARAM_INTG02 == "000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_INTG03", out var LTSOLPAR_PARAM_INTG03) && LTSOLPAR_PARAM_INTG03 == "000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DEC01", out var LTSOLPAR_PARAM_DEC01) && LTSOLPAR_PARAM_DEC01 == "00000000000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DEC02", out var LTSOLPAR_PARAM_DEC02) && LTSOLPAR_PARAM_DEC02 == "00000000000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_DEC03", out var LTSOLPAR_PARAM_DEC03) && LTSOLPAR_PARAM_DEC03 == "00000000000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_FLOAT01", out var LTSOLPAR_PARAM_FLOAT01) && LTSOLPAR_PARAM_FLOAT01 == "00000000000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_FLOAT02", out var LTSOLPAR_PARAM_FLOAT02) && LTSOLPAR_PARAM_FLOAT02 == "00000000000000000");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_CHAR01", out var LTSOLPAR_PARAM_CHAR01) && LTSOLPAR_PARAM_CHAR01 == "                                                            ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_CHAR02", out var LTSOLPAR_PARAM_CHAR02) && LTSOLPAR_PARAM_CHAR02 == "                              ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_CHAR03", out var LTSOLPAR_PARAM_CHAR03) && LTSOLPAR_PARAM_CHAR03 == "               ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_CHAR04", out var LTSOLPAR_PARAM_CHAR04) && LTSOLPAR_PARAM_CHAR04 == "               ");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_PARAM_CHAR05", out var LTSOLPAR_PARAM_CHAR05) && LTSOLPAR_PARAM_CHAR05 == "Dclgens.LTSOLPAR_LTSOLPAR_PARAM_CHAR05");
                Assert.True(envList6[1].TryGetValue("LTSOLPAR_DTH_SOLICITACAO", out var LTSOLPAR_DTH_SOLICITACAO) && LTSOLPAR_DTH_SOLICITACAO == "01:01:01");
                
                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Fact]
        public static void LT3164S_Tests99_Fact()
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
                var program = new LT3164S();
                LBLT3164_LT3164S_AREA_PARAMETROS obj = new LBLT3164_LT3164S_AREA_PARAMETROS();             

                program.Execute(new LBLT3164_LT3164S_AREA_PARAMETROS());

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);
           
                Assert.True(program.RETURN_CODE == 0);
            }
        }


    }
}