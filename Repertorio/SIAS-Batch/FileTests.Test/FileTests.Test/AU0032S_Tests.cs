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
using static Code.AU0032S;

namespace FileTests.Test
{
    [Collection("AU0032S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU0032S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "TXACE_TAXACARR" , ""},
                { "TXACE_TAXAOUTR" , ""},
                { "TXACE_TAXAEQUIP" , ""},
                { "TXACE_TAXAREINT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "BONUS_PCDESC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRAZO_PCPRMANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CATTF_VLPRTXCF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void AU0032S_Tests_Fact_Erro100()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TXACE_TAXACARR" , ""},
                { "TXACE_TAXAOUTR" , ""},
                { "TXACE_TAXAEQUIP" , ""},
                { "TXACE_TAXAREINT" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new AU0032S();
                program.Execute(new AU0032S_CSP_REGISTRO());

                Assert.True(program.CSP_RETORNO.CSP_CODE == 100);
            }
        }
        [Fact]
        public static void AU0032S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TXACE_TAXACARR" , "1"},
                { "TXACE_TAXAOUTR" , "2"},
                { "TXACE_TAXAEQUIP" , "3"},
                { "TXACE_TAXAREINT" , "4"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "BONUS_PCDESC" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PRAZO_PCPRMANO" , "6"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CATTF_VLPRTXCF" , "7"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion

                var program = new AU0032S();
                var parm = new AU0032S_CSP_REGISTRO();

                parm.CSP_CLABONAT.Value = 1;

                program.Execute(parm);

                //M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1"].DynamicList);

                //M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1"].DynamicList);

                //M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1"].DynamicList);

                //M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1
                //Assert.Empty(AppSettings.TestSet.DynamicData["M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1"].DynamicList);
                //M_180 não é chamado, no Cobol a chamada ao método está comentada como descontinuada.

                Assert.True(program.CSP_RETORNO.CSP_CODE == 00);
            }
        }
    }
}