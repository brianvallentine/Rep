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
using static Code.SI1019S;

namespace FileTests.Test
{
    [Collection("SI1019S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI1019S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void SI1019S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var param = new LBSI1001_SI1001S_PARAMETROS();
                param.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO.Value = 1;

                //LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_COD_PRODUTO == 00 && LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_RAMO == 00)
                var program = new SI1019S();
                program.Execute(param);

                Assert.Empty(param.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.Value);
                Assert.True(param.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE.Value == 0);
            }
        }

        [Fact]
        public static void SI1019S_Tests_Fact_ReturnCode99()
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
                var param = new LBSI1001_SI1001S_PARAMETROS();

                var program = new SI1019S();
                program.Execute(param);

                Assert.NotEmpty(param.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.Value);
            }
        }
    }
}