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
using static Code.PRODIFC1;

namespace FileTests.Test
{
    [Collection("PRODIFC1_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PRODIFC1_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PRODIFC1_Tests_Fact_ReturnError_99999()
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
                var param = new PRODIFC1_LPARM();
                param.LPARM01.LPARM01_DD.Value = 29;
                param.LPARM01.LPARM01_MM.Value = 02;
                param.LPARM01.LPARM01_AA.Value = 2023;
                #endregion
                var program = new PRODIFC1();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM03.Value == 99999);
                Assert.True(program.LPARM.LPARM01.LPARM01_DD.Value == 29);
            }
        }
        [Fact]
        public static void PRODIFC1_Tests_Fact_ReturnError2_99999()
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
                var param = new PRODIFC1_LPARM();
                param.LPARM01.LPARM01_DD.Value = 31;
                param.LPARM01.LPARM01_MM.Value = 06;
                param.LPARM01.LPARM01_AA.Value = 2023;
                #endregion
                var program = new PRODIFC1();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM03.Value == 99999);
                Assert.True(program.LPARM.LPARM01.LPARM01_DD.Value == 31);
            }
        }
        [Fact]
        public static void PRODIFC1_Tests_Fact_MonthZero_ReturnError3_99999()
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
                var param = new PRODIFC1_LPARM();
                param.LPARM01.LPARM01_DD.Value = 31;
                param.LPARM01.LPARM01_MM.Value = 0;
                param.LPARM01.LPARM01_AA.Value = 2023;
                #endregion
                var program = new PRODIFC1();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM03.Value == 99999);
                Assert.True(program.LPARM.LPARM01.LPARM01_MM.Value == 0);
            }
        }
        [Fact]
        public static void PRODIFC1_Tests_Fact_ValidateSucess_0()
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
                var param = new PRODIFC1_LPARM();
                param.LPARM01.LPARM01_DD.Value = 29;
                param.LPARM01.LPARM01_MM.Value = 02;
                param.LPARM01.LPARM01_AA.Value = 2024;
                #endregion
                var program = new PRODIFC1();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM03.Value == 0);
                Assert.True(program.LPARM.LPARM01.LPARM01_DD.Value == 29);
                Assert.True(program.LPARM.LPARM01.LPARM01_MM.Value == 02);
            }
        }
    }
}