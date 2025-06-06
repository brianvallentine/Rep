using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI0882B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0882B_Tests")]
    public class SI0882B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0882B_C1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0882B_C1", q0);

            #endregion

            #region SI0882B_CTRAB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINIPLAN_DT_PRI_PREST_PAGA" , ""},
                { "SINIPLAN_DT_ULT_PREST_PAGA" , ""},
                { "SINIHAB1_COD_COBERTURA" , ""},
                { "SINIPLAN_NUM_APOL_SINISTRO" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIPLAN_PERC_PARTICIPACAO" , ""},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_INDENIZACAO" , ""},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , ""},
                { "SINIPLAN_NUM_ULT_PREST_PAGA" , ""},
                { "HOST_NUM_CONTRATO" , ""},
                { "SINIPLAN_DATA_INDENIZACAO" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "RALCHEDO_NUMERO_SIVAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0882B_CTRAB", q1);

            #endregion

            #region M_000_900_FIM_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_000_900_FIM_DB_UPDATE_1_Update1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0882B_t1")]
        public static void SI0882B_Tests_Theory(string ARQCALC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQCALC_FILE_NAME_P = $"{ARQCALC_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0882B_C1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0882B_C1");
                AppSettings.TestSet.DynamicData.Add("SI0882B_C1", q0);

                #endregion

                #region SI0882B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINIPLAN_DT_PRI_PREST_PAGA" , ""},
                { "SINIPLAN_DT_ULT_PREST_PAGA" , ""},
                { "SINIHAB1_COD_COBERTURA" , ""},
                { "SINIPLAN_NUM_APOL_SINISTRO" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIPLAN_PERC_PARTICIPACAO" , ""},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_INDENIZACAO" , ""},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , ""},
                { "SINIPLAN_NUM_ULT_PREST_PAGA" , ""},
                { "HOST_NUM_CONTRATO" , ""},
                { "SINIPLAN_DATA_INDENIZACAO" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "RALCHEDO_NUMERO_SIVAT" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0882B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0882B_CTRAB", q1);

                #endregion

                #region M_000_900_FIM_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_900_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_000_900_FIM_DB_UPDATE_1_Update1", q2);

                #endregion

                #endregion
                var program = new SI0882B();
                program.Execute(ARQCALC_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0882B_t2")]
        public static void SI0882B_Tests_TheoryReturn99(string ARQCALC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQCALC_FILE_NAME_P = $"{ARQCALC_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0882B_C1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0882B_C1");
                AppSettings.TestSet.DynamicData.Add("SI0882B_C1", q0);

                #endregion

                #region SI0882B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                
            });
                AppSettings.TestSet.DynamicData.Remove("SI0882B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0882B_CTRAB", q1);

                #endregion

                #region M_000_900_FIM_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_000_900_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_000_900_FIM_DB_UPDATE_1_Update1", q2);

                #endregion

                #endregion
                var program = new SI0882B();
                program.Execute(ARQCALC_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}