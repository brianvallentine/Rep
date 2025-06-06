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
using static Code.PRODIFD2;

namespace FileTests.Test
{
    [Collection("PRODIFD2_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class PRODIFD2_Tests
    { 
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PRODIFD2_Tests_Fact()
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
                var program = new PRODIFD2();

                var param = new PRODIFD2_LPARM();
                param.LPARM01.LPARM01_AAAA.Value = 2024;
                param.LPARM01.LPARM01_MM.Value = 01;
                param.LPARM01.LPARM01_DD.Value = 15;

                program.Execute(param);

                Assert.True(param.MENSAGEM.Value == "");
            }
        }        

        [Fact]
        public static void PRODIFD2_Tests_MouthIncorret()
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
                var program = new PRODIFD2();

                var param = new PRODIFD2_LPARM();
                param.LPARM01.LPARM01_AAAA.Value = 2024;
                param.LPARM01.LPARM01_MM.Value = 99;
                param.LPARM01.LPARM01_DD.Value = 01;

                program.Execute(param);

                Assert.True(param.MENSAGEM.Value == "MES INVALIDO                                                          ");
            }
        }

        [Fact]
        public static void PRODIFD2_Tests_DayIncorret()
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
                var program = new PRODIFD2();

                var param = new PRODIFD2_LPARM();
                param.LPARM01.LPARM01_AAAA.Value = 2024;
                param.LPARM01.LPARM01_MM.Value = 01;
                param.LPARM01.LPARM01_DD.Value = 99;

                program.Execute(param);

                Assert.True(param.MENSAGEM.Value == "DIA INVALIDO                                                          ");
            }
        }        
    }
}