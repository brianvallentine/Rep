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
using static Code.SI0006S;
using Sias.Sinistro.DB2.SI0006S;

namespace FileTests.Test
{
    [Collection("SI0006S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0006S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIPARADI_COD_PRODUTO" , ""},
                { "SIPARADI_COD_COBERTURA" , ""},
                { "SIPARADI_PERC_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0006S_SINISTRO_APOL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "W_HOST_VALOR_AVISADO_OPER_101" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0006S_SINISTRO_APOL", q1);

            #endregion

            #region M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_ADIANTA2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_FRANQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_99" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0006S_Tests_Fact_Erro99()
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

                LT3159S_Tests.Load_Parameters();

                #endregion
                var program = new SI0006S();
                program.Execute(new SI0006S_LK2_LINK());

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void SI0006S_Tests_Fact()
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

                #region M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIPARADI_COD_PRODUTO" , "1803"},
                { "SIPARADI_COD_COBERTURA" , "1"},
                { "SIPARADI_PERC_ADIANTAMENTO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0006S_SINISTRO_APOL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "101800000202"},
                { "W_HOST_VALOR_AVISADO_OPER_101" , "12339.17"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "101800000203"},
                { "W_HOST_VALOR_AVISADO_OPER_101" , "14000.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0006S_SINISTRO_APOL");
                AppSettings.TestSet.DynamicData.Add("SI0006S_SINISTRO_APOL", q1);

                #endregion

                #region M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_ADIANTA2" , "5000"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_1" , "8000"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_1" , "8500"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_FRANQUIA" , "6000"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_FRANQUIA" , "6500"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_99" , "5000"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_99" , "5500"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q5);

                #endregion

                LT3159S_Tests.Load_Parameters();

                #endregion
                var program = new SI0006S();
                var param = new SI0006S_LK2_LINK();
                param.LK2_DATA_INIVIGENCIA.Value = "2000-10-10";
                param.LK2_DATA_TERVIGENCIA.Value = "2000-10-10";
                program.Execute(param);

                Assert.Empty(AppSettings.TestSet.DynamicData["M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["SI0006S_SINISTRO_APOL"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}