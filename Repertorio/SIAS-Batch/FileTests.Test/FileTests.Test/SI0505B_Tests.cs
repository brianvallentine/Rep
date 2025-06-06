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
using static Code.SI0505B;

namespace FileTests.Test
{
    [Collection("SI0505B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0505B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0400_SEL_HABIT01_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "1"},
                { "SINIHAB1_PONTO_VENDA" , "5001"},
                { "SINIHAB1_NUM_CONTRATO" , "50012004"},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_SEL_HABIT01_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0505B_Tests_Fact()
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
                var program = new SI0505B();
                var param = new LBSI505B_SI0505B_PARAMETROS()
                {
                    SI0505B_ENTRADA = new LBSI505B_SI0505B_ENTRADA()
                    {
                        SI0505B_NUM_APOL_SINISTRO = new IntBasis(new PIC("9", "13", "9(013)"), 123456789),
                    }
                };

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC == 0);
            }
        }
        [Fact]
        public static void SI0505B_Tests_SemDados()
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
                var program = new SI0505B();

                program.Execute(new LBSI505B_SI0505B_PARAMETROS());

                Assert.True(program.LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC == 99);
            }
        }

    }
}