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
using static Code.PROCBR01;

namespace FileTests.Test
{
    [Collection("PROCBR01_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PROCBR01_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PROCBR01_Tests_Fact_ReturnCode_00()
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
                var inputParam = new PROCBR01_LINK_AREA();
                inputParam.LK_BANCO.Value = 260;
                inputParam.LK_CDCED.Value = 123456789079324;
                inputParam.LK_CODIGO.Value = "77889966";
                inputParam.LK_DIGITO.Value = 7;
                inputParam.LK_RCCODE.Value = "R";
                inputParam.LK_MOEDA.Value = 1;
                inputParam.LK_NNURO.Value = 1234567890;
                inputParam.LK_VALOR.Value = 1200;
                #endregion
                var program = new PROCBR01();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.AREA_DE_WORK.WK_RCCODE == "");

                Assert.True(program.BR_CODIG_DE_BARRA.BR_COD_BARRA_NUM.BR_NUMERO.Value == "26017000000001200001234567890123456789079324");
            }
        }

        [Fact]
        public static void PROCBR01_Tests_Fact_EmptyParam_ReturnCode_00()
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
                var inputParam = new PROCBR01_LINK_AREA()
                {
                };
                #endregion
                var program = new PROCBR01();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.AREA_DE_WORK.WK_RCCODE == "");
                Assert.True(program.BR_CODIG_DE_BARRA.BR_COD_BARRA_NUM.BR_NUMERO.Value == "00000000000000000000000000000000000000000000");
            }
        }

    }
}