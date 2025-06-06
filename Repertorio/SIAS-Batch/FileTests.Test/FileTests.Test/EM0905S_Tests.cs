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
using static Code.EM0905S;

namespace FileTests.Test
{
    [Collection("EM0905S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class EM0905S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region EM0905S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , ""},
                { "MOED_TIPO_MOEDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0905S_V1MOEDA", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0905S_Tests_Fact_CalculoUnico_ComDesconto()
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
                #region EM0905S_V1MOEDA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0905S_V1MOEDA");
                AppSettings.TestSet.DynamicData.Add("EM0905S_V1MOEDA", q0);

                #endregion

                #region param
                var inputParam = new EM0905S_CALCULOS();
                inputParam.COD_MOEDA.Value = 0001;
                inputParam.RAMO.Value = 0002;
                inputParam.NRPARCEL.Value = 0;
                inputParam.DTINIVIG_LK.Value = "2024-01-01";
                inputParam.VL_PREMIO_BASE.Value = 1000;
                inputParam.IND_FRAC.Value = "S";
                inputParam.QTPARCEL.Value = 1;
                inputParam.ISENTA_CUSTO.Value = "N";
                inputParam.PCDESCON.Value = 10;
                inputParam.PCDESCON_ADIC.Value = 5;
                #endregion
                #endregion
                var program = new EM0905S();
                program.Execute(inputParam);

                Assert.True(program.WABEND.WSQLCODE == 0);

                Assert.True(program.CALCULOS.VL_TOTAL == 850);
                Assert.True(program.CALCULOS.VL_DESCONTO == 150);
                Assert.True(program.CALCULOS.PCDESCON == 10);
                Assert.True(program.CALCULOS.PCDESCON_ADIC == 5);

            }
        }
        [Fact]
        public static void EM0905S_Tests_Fact_CalculoQtdeParcela1_ComDesconto()
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
                #region EM0905S_V1MOEDA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0905S_V1MOEDA");
                AppSettings.TestSet.DynamicData.Add("EM0905S_V1MOEDA", q0);

                #endregion

                #region param
                var inputParam = new EM0905S_CALCULOS();
                inputParam.COD_MOEDA.Value = 0001;
                inputParam.RAMO.Value = 0002;
                inputParam.NRPARCEL.Value = 1;
                inputParam.DTINIVIG_LK.Value = "2024-01-01";
                inputParam.VL_PREMIO_BASE.Value = 1000;
                inputParam.IND_FRAC.Value = "S";
                inputParam.QTPARCEL.Value = 1;
                inputParam.ISENTA_CUSTO.Value = "N";
                inputParam.PCDESCON.Value = 10;
                inputParam.PCDESCON_ADIC.Value = 5;
                #endregion
                #endregion
                var program = new EM0905S();
                program.Execute(inputParam);

                Assert.True(program.WABEND.WSQLCODE == 0);

                Assert.True(program.CALCULOS.VL_TOTAL == 850);
                Assert.True(program.CALCULOS.VL_DESCONTO == 150);
                Assert.True(program.CALCULOS.PCDESCON == 10);
                Assert.True(program.CALCULOS.PCDESCON_ADIC == 5);
            }
        }
        [Fact]
        public static void EM0905S_Tests_Fact_CalculoQtdeParcela2_ComDesconto()
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
                #region EM0905S_V1MOEDA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0905S_V1MOEDA");
                AppSettings.TestSet.DynamicData.Add("EM0905S_V1MOEDA", q0);

                #endregion

                #region param
                var inputParam = new EM0905S_CALCULOS();
                inputParam.COD_MOEDA.Value = 0001;
                inputParam.RAMO.Value = 0002;
                inputParam.NRPARCEL.Value = 2;
                inputParam.DTINIVIG_LK.Value = "2024-01-01";
                inputParam.VL_PREMIO_BASE.Value = 1000;
                inputParam.IND_FRAC.Value = "S";
                inputParam.QTPARCEL.Value = 2;
                inputParam.ISENTA_CUSTO.Value = "N";
                inputParam.PCDESCON.Value = 10;
                inputParam.PCDESCON_ADIC.Value = 5;
                #endregion
                #endregion
                var program = new EM0905S();
                program.Execute(inputParam);

                Assert.True(program.WABEND.WSQLCODE == 0);

                Assert.True(program.CALCULOS.VL_TOTAL == 425);
                Assert.True(program.CALCULOS.VL_DESCONTO == 75);
                Assert.True(program.CALCULOS.QTPARCEL == 2);
                Assert.True(program.CALCULOS.PCDESCON_ADIC == 5);
            }
        }
    }
}