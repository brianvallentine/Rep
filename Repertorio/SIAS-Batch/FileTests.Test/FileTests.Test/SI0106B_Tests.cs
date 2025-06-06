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
using static Code.SI0106B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0106B_Tests")]
    public class SI0106B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0106B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_DTINIVIG" , ""},
                { "RELSIN_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0106B_V1RELATSINI", q2);

            #endregion

            #region SI0106B_THISTSIN1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "THIST_CODPSVI" , ""},
                { "THIST_NUMOPG" , ""},
                { "THIST_OPERACAO" , ""},
                { "THIST_APOL_SINI" , ""},
                { "THIST_MOVPCS" , ""},
                { "THIST_NOMFAV" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0106B_THISTSIN1", q3);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""},
                { "GEUNIMO_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MEST_MOEDA_SIN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0106B_1")]
        public static void SI0106B_Tests_Theory_Erro99(string SI0106R1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0106R1_FILE_NAME_P = $"{SI0106R1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0106B();
                program.Execute(SI0106R1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0106B_2")]
        public static void SI0106B_Tests_Theory(string SI0106R1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0106R1_FILE_NAME_P = $"{SI0106R1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0106B();
                program.Execute(SI0106R1_FILE_NAME_P);

                //M_015_000_CABECALHOS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList);
                
                //M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1"].DynamicList);
                
                //M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1"].DynamicList);
                
                //M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_800_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}