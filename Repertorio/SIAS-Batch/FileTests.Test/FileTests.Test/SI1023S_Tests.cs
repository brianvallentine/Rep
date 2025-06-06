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
using static Code.SI1023S;

namespace FileTests.Test
{
    [Collection("SI1023S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI1023S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void SI1023S_Tests_Fact()
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
                var param = new LBSI1001_SI1001S_PARAMETROS();
                param.SI1001S_ENTRADA.SI1001S_IDE_SISTEMA.Value = "001";
                param.SI1001S_ENTRADA.SI1001S_IDE_SISTEMA_OPER.Value = "001";
                param.SI1001S_ENTRADA.SI1001S_COD_FUNCAO.Value = 001;
                param.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO.Value = 001;
                param.SI1001S_ENTRADA.SI1001S_COD_PRODUTO.Value = 001;
                param.SI1001S_ENTRADA.SI1001S_RAMO.Value = 001;
                param.SI1001S_ENTRADA.SI1001S_DATA_INICIO.Value = "2025-04-28";
                param.SI1001S_ENTRADA.SI1001S_DATA_FIM.Value = "2025-04-29";
                #endregion
                var program = new SI1023S();
                program.Execute(param);

                var saida = param.SI1001S_SAIDA;

                Assert.True(param.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE == "100");
            }
        }
    }
}