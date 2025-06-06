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
using static Code.FC0001S;

namespace FileTests.Test
{
    [Collection("FC0001S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class FC0001S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Theory]
        [InlineData(123456789, 123456789, 123456789, "LK_OUT_MENSAGEM_P")]
        public static void FC0001S_Tests_Theory_Cpf_Valido(int LK_IN_COD_CPF_P, int LK_OUT_COD_CPF_P, int LK_OUT_COD_RETORNO_P, string LK_OUT_MENSAGEM_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var pCPF_Valido = new IntBasis();
                pCPF_Valido.Value = 03574845928;
                #endregion
                var program = new FC0001S();
                program.Execute(pCPF_Valido, new IntBasis(null, LK_OUT_COD_CPF_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new StringBasis(null, LK_OUT_MENSAGEM_P));

                Assert.True(true);
                Assert.True(program.LK_OUT_COD_CPF.Value == pCPF_Valido);
                Assert.True(program.LK_OUT_COD_RETORNO.Value == 0);
            }
        }
        [Theory]
        [InlineData(123456789, 123456789, 123456789, "LK_OUT_MENSAGEM_P")]
        public static void FC0001S_Tests_Theory_Cpf_Invalido(int LK_IN_COD_CPF_P, int LK_OUT_COD_CPF_P, int LK_OUT_COD_RETORNO_P, string LK_OUT_MENSAGEM_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            LK_OUT_MENSAGEM_P = $"{LK_OUT_MENSAGEM_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var pCPF_Invalido = new IntBasis();
                pCPF_Invalido.Value = 03574845925;
                #endregion
                var program = new FC0001S();
                program.Execute(pCPF_Invalido, new IntBasis(null, LK_OUT_COD_CPF_P), new IntBasis(null, LK_OUT_COD_RETORNO_P), new StringBasis(null, LK_OUT_MENSAGEM_P));

                Assert.True(true);
                Assert.True(program.LK_OUT_COD_CPF.Value != pCPF_Invalido);
                Assert.True(program.LK_OUT_COD_RETORNO.Value == 0);
            }
        }

    }
}