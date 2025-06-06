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
using static Code.SI0108B;

namespace FileTests.Test
{
    [Collection("SI0108B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0108B_Tests
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
                { "TSISTEM_IDSISTEM" , ""},
                { "TSISTEM_DTMOVABE" , ""},
                { "TSISTEM_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0108B_RELSIN

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_DTINIVIG" , ""},
                { "RELSIN_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0108B_RELSIN", q2);

            #endregion

            #region SI0108B_DESCR

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "THIST_APOL_SINI" , ""},
                { "THIST_OPERACAO" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_VAL_OPERACAO" , ""},
                { "THIST_SITUACAO" , ""},
                { "THIST_LIMCRR" , ""},
                { "TMEST_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0108B_DESCR", q3);

            #endregion

            #region M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TGEFON_NOMEFTE" , ""},
                { "TGEFON_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "TSISTEM_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q5);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""},
                { "GEUNIMO_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MEST_COD_MD_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0108B_1")]
        public static void SI0108B_Tests_Theory(string RELATORIO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELATORIO_FILE_NAME_P = $"{RELATORIO_FILE_NAME_P}_{timestamp}.txt";
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

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "x"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);


                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "TSISTEM_IDSISTEM" , "1"},
                { "TSISTEM_DTMOVABE" , "2020-01-01"},
                { "TSISTEM_DTCURRENT" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0108B_RELSIN

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_DTINIVIG" , "2020-01-01"},
                { "RELSIN_DTTERVIG" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0108B_RELSIN");
                AppSettings.TestSet.DynamicData.Add("SI0108B_RELSIN", q2);

                #endregion

                #region SI0108B_DESCR

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "THIST_APOL_SINI" , "123456"},
                { "THIST_OPERACAO" , "x"},
                { "THIST_DTMOVTO" , "2020-01-01"},
                { "THIST_VAL_OPERACAO" , "100"},
                { "THIST_SITUACAO" , "1"},
                { "THIST_LIMCRR" , "x"},
                { "TMEST_FONTE" , "x"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0108B_DESCR");
                AppSettings.TestSet.DynamicData.Add("SI0108B_DESCR", q3);

                #endregion

                #region M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "TGEFON_NOMEFTE" , "X"},
                { "TGEFON_FONTE" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1", q4);

                #endregion
          

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , "100"},
                { "GEUNIMO_SIGLUNIM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "MEST_COD_MD_SINI" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new SI0108B();
                program.Execute(RELATORIO_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0108B_RELSIN"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

           
                Assert.True(program.W.WABEND.WSQLCODE == 00);
            }
        }


        [Theory]
        [InlineData("SI0108B_2")]
        public static void SI0108B_Tests99_Theory(string RELATORIO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELATORIO_FILE_NAME_P = $"{RELATORIO_FILE_NAME_P}_{timestamp}.txt";
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

                var q0 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);


                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0108B_RELSIN

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI0108B_RELSIN");
                AppSettings.TestSet.DynamicData.Add("SI0108B_RELSIN", q2);

                #endregion

                #region SI0108B_DESCR

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI0108B_DESCR");
                AppSettings.TestSet.DynamicData.Add("SI0108B_DESCR", q3);

                #endregion

                #region M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1", q4);

                #endregion


                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                 AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1

                var q7 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1", q7);

                #endregion
             
                #endregion
                var program = new SI0108B();
                program.Execute(RELATORIO_FILE_NAME_P);

                Assert.True(program.W.WABEND.WSQLCODE != 00);
            }
        }


    }
}