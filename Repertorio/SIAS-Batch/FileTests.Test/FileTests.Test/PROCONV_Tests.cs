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
using static Code.PROCONV;

namespace FileTests.Test
{
    [Collection("PROCONV_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PROCONV_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Theory]
        [InlineData(";", ",")]
        [InlineData(":", ".")]
        [InlineData("=", ".")]
        [InlineData("1á", "1a")]
        [InlineData("2ã5", "2a5")]
        [InlineData("àDD", "aDD")]
        [InlineData("â", "a")]
        [InlineData("ó", "o")]
        [InlineData("coracaõ", "coracao")]
        [InlineData("ô", "o")]
        [InlineData("í", "i")]
        [InlineData("Í", "I")]
        [InlineData("ç", "c")]
        [InlineData("-", "-")]
        [InlineData(" , ", " , ")]
        public static void PROCONV_Tests_Theory_SpecialCaracteres(string entrada, string saida)
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
                var param = new PROCONV_LK_CONVERSAO();
                param.LK_CAMPO_ENTRADA.Value = entrada.Trim();
                param.LK_TAM_CAMPO.Value = entrada.Length;
                #endregion

                var program = new PROCONV();

                program.Execute(param);

                Assert.Equal(program.LK_CONVERSAO.LK_CAMPO_SAIDA.Value.Trim(), saida.Trim());
            }
        }

        [Theory]
        [InlineData("dadccc", "DADCCC")]
        [InlineData("dbcaixaseg", "DBCAIXASEG")]
        public static void PROCONV_Tests_Theory_UpperConvert(string entrada, string saida)
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
                var param = new PROCONV_LK_CONVERSAO();
                param.LK_CAMPO_ENTRADA.Value = entrada.Trim();
                param.LK_CONVER_MAIUSCULA.Value = "S";
                param.LK_TAM_CAMPO.Value = entrada.Length;
                #endregion

                var program = new PROCONV();

                program.Execute(param);

                Assert.Equal(program.LK_CONVERSAO.LK_CAMPO_SAIDA.Value.Trim(), saida.Trim());
            }
        }
    }
}