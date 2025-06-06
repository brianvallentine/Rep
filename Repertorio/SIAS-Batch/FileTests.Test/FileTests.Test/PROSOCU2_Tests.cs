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
using static Code.PROSOCU2;
using static Code.PROSOCU2.PROSOCU2_LPARM;

namespace FileTests.Test
{
    [Collection("PROSOCU2_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PROSOCU2_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void PROSOCU2_Tests_Fact()
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
                var param = new PROSOCU2_LPARM();
                param.DATA1 = new PROSOCU2_DATA1();
                param.DATA1.DATA1_AA.Value = 2025;
                param.DATA1.DATA1_MM.Value = 05;
                param.DATA1.DATA1_DD.Value = 14;
                param.NDIAS.Value = 1;
                param.DATA3 = new PROSOCU2_DATA3();
                param.DATA3.DATA3_AA.Value = 2025;
                param.DATA3.DATA3_MM.Value = 05;
                param.DATA3.DATA3_DD.Value = 15;
                #endregion
                var program = new PROSOCU2();
                program.Execute(param);

                Assert.True(program.Result != null);
            }
        }
    }
}