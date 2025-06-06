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
using static Code.PROM11CF;

namespace FileTests.Test
{
    [Collection("PROM11CF_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PROM11CF_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PROM11CF_Tests_Fact_InvalidNumber_ReturnCode16()
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
                var inputParam = new PROM11CF_LPARM01X()
                {
                    LPARM01 = new StringBasis()
                    {
                        Pic = new PIC("X", "15", "X(015)."),
                        Value = "1234567890ABCDE"
                    }
                };
                #endregion
                var program = new PROM11CF();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 16);
                Assert.True(program.LPARM01X.LPARM03 == 9);
            }
        }
        [Fact]
        public static void PROM11CF_Tests_Fact_ValidateOk_Remainder2_ReturnCode00()
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
                var inputParam = new PROM11CF_LPARM01X()
                {
                    LPARM01 = new StringBasis()
                    {
                        Pic = new PIC("X", "15", "X(015)."),
                        Value = "123456789024379"
                    }
                };
                #endregion
                var program = new PROM11CF();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.LPARM01X.LPARM03 == 2);
            }
        }
        [Fact]
        public static void PROM11CF_Tests_Fact_ValidateOk_Remainder0_ReturnCode00()
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
                var inputParam = new PROM11CF_LPARM01X()
                {
                    LPARM01 = new StringBasis()
                    {
                        Pic = new PIC("X", "15", "X(015)."),
                        Value = "123456889024379"
                    }
                };
                #endregion
                var program = new PROM11CF();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.LPARM01X.LPARM03 == 0);
            }
        }

    }
}