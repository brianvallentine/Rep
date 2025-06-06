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
using static Code.PR0011B;

namespace FileTests.Test
{
    [Collection("PR0011B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PR0011B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0015_00_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEM_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region PR0011B_V1ACOMPROP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ACOMPR_FONTE" , ""},
                { "V1ACOMPR_NRPROPOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PR0011B_V1ACOMPROP", q2);

            #endregion

            #region R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1CONTPR_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1FONTES_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PR0011B_1_t1")]
        public static void PR0011B_Tests_Theory(string RPR0011B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPR0011B_FILE_NAME_P = $"{RPR0011B_FILE_NAME_P}_{timestamp}.txt";
          
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "teste"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_CABECALHOS_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new PR0011B();
                program.Execute(RPR0011B_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.Empty(AppSettings.TestSet.DynamicData["PR0011B_V1ACOMPROP"].DynamicList.ToList());
                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}