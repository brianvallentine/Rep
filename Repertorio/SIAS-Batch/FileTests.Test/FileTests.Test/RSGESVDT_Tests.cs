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
using static Code.RSGESVDT;

namespace FileTests.Test
{
    [Collection("RSGESVDT_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class RSGESVDT_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void RSGESVDT_Tests_Fact_AnoBissexto_OK()
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
                var param = new RSGEWVDT();
                param.LK_RSGEWVDT_ANO.Value = "2024";
                param.LK_RSGEWVDT_MES.Value = "02";
                param.LK_RSGEWVDT_DIA.Value = "29";
                #endregion
                var program = new RSGESVDT();
                program.Execute(param);

                Assert.True(program.RSGEWVDT.LK_RSGEWVDT_IND_RETORNO.Value == 0);
                Assert.True(program.RSGEWVDT.LK_RSGEWVDT_ANO.Value == "2024");

            }
        }
        [Fact]
        public static void RSGESVDT_Tests_Fact_DataInvalida()
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
                var param = new RSGEWVDT();
                param.LK_RSGEWVDT_ANO.Value = "2023";
                param.LK_RSGEWVDT_MES.Value = "02";
                param.LK_RSGEWVDT_DIA.Value = "29";
                #endregion
                var program = new RSGESVDT();
                program.Execute(param);

                Assert.True(program.RSGEWVDT.LK_RSGEWVDT_IND_RETORNO.Value == 1);
                Assert.True(program.RSGEWVDT.LK_RSGEWVDT_ANO.Value == "2023");

            }
        }
    }
}