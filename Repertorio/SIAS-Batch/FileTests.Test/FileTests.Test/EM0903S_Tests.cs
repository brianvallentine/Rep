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
using static Code.EM0903S;

namespace FileTests.Test
{
    [Collection("EM0903S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class EM0903S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region EM0903S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0903S_V1MOEDA", q0);

            #endregion

            #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

            #endregion

            #region A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AU080_PCT_TOTAL_ENCARGO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        public static void Load_Parameters_To_EM0030B()
        {
            #region PARAMETERS
            #region EM0903S_V1MOEDA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "1"},
                { "MOED_TIPO_MOEDA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0903S_V1MOEDA", q0);

            #endregion

            #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

            #endregion

            #region A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , ""},
                { "FRAC_INDADIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AU080_PCT_TOTAL_ENCARGO" , ""}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "AU080_PCT_TOTAL_ENCARGO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0903S_Tests_Fact_NrParcel2_ComValorAdicional()
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
                #region param
                var inputParam = new EM0903S_CALCULOS();
                inputParam.COD_MOEDA.Value = 0001;
                inputParam.RAMO.Value = 0002;
                inputParam.NRPARCEL.Value = 2; 
                inputParam.DTINIVIG_LK.Value = "2024-01-01";
                inputParam.VL_PREMIO_BASE.Value = 1200;
                inputParam.IND_FRAC.Value = "S";
                inputParam.QTPARCEL.Value = 1;
                #endregion
                #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , "2"},
                { "FRAC_INDADIC" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new EM0903S();
                program.Execute(inputParam);

                Assert.True(program.CALCULOS.VL_TOTAL == 2400);
                Assert.True(program.CALCULOS.VL_ADICIONAL == 1200);

            }
        }
        
        [Fact]
        public static void EM0903S_Tests_Fact_NrParcel_2_SemValorAdicional()
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
                #region param
                var inputParam = new EM0903S_CALCULOS();
                inputParam.COD_MOEDA.Value = 0001;
                inputParam.RAMO.Value = 0002;
                inputParam.NRPARCEL.Value = 2;
                inputParam.DTINIVIG_LK.Value = "2024-01-01";
                inputParam.VL_PREMIO_BASE.Value = 1200;
                inputParam.IND_FRAC.Value = "S";
                inputParam.QTPARCEL.Value = 1;
                #endregion
                #region A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FRAC_INDPRLIQ" , "1"},
                { "FRAC_INDADIC" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new EM0903S();
                program.Execute(inputParam);

                Assert.True(program.CALCULOS.VL_TOTAL == 1200);
                Assert.True(program.CALCULOS.VL_ADICIONAL == 0);

            }
        }
    }
}