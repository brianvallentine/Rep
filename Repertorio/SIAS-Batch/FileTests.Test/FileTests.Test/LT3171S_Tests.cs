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
using static Code.LT3171S;

namespace FileTests.Test
{
    [Collection("LT3171S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3171S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void LT3171S_Tests_Fact()
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
                var program = new LT3171S();
                var param = new LBLT3171_LT3171_AREA_PARAMETROS();

                param.LT3171_PRODUTO.Value = 1803;
                param.LT3171_NUM_LOTERICO.Value = 123;

                program.Execute(param);

                Assert.True(program.LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO == 0);
            }
        }

        [Fact]
        public static void LT3171S_Tests_Erro120()
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
                var program = new LT3171S();
                var param = new LBLT3171_LT3171_AREA_PARAMETROS();

                param.LT3171_PRODUTO.Value = 0;
                param.LT3171_NUM_LOTERICO.Value = 0;

                program.Execute(param);

                Assert.True(program.LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO == 120);
            }
        }
    }
}