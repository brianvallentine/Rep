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
using static Code.PROCNPJ2;

namespace FileTests.Test
{
    [Collection("PROCNPJ2_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PROCNPJ2_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PROCNPJ2_Tests_Fact_ValidateCNPJ_OK_0()
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
                var param = new PROCNPJ2_LPARM();
                param.LPARM_ENT.Value = 24305181000122;
                #endregion
                var program = new PROCNPJ2();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM_SAI.Value == 0);
                Assert.True(program.WS_PROCGC01.WS_PROCGC01_04 == 22);

            }
        }
        [Fact]
        public static void PROCNPJ2_Tests_Fact_ValidateCNPJ_nOK_Return_9()
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
                var param = new PROCNPJ2_LPARM();
                param.LPARM_ENT.Value = 14305181000122;
                #endregion
                var program = new PROCNPJ2();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM_SAI.Value == 9);
                Assert.True(program.WS_PROCGC01.WS_PROCGC01_04 == 79);

            }
        }
        [Fact]
        public static void PROCNPJ2_Tests_Fact_ValidateCNPJ_nOK_Return_8()
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
                var param = new PROCNPJ2_LPARM();
                param.LPARM_ENT.Value = 99999000000;
                #endregion
                var program = new PROCNPJ2();
                program.Execute(param);

                Assert.True(program.LPARM.LPARM_SAI.Value == 8);
                Assert.True(program.LPARM.LPARM_ENT == 99999000000);

            }
        }
    }
}