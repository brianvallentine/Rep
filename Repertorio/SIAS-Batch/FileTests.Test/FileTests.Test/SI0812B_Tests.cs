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
using static Code.SI0812B;

namespace FileTests.Test
{
    [Collection("SI0812B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0812B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS

            #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "TEMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0812B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOLICE" , ""},
                { "RELSIN_ANO_REF" , ""},
                { "RELSIN_MES_REF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0812B_V1RELATSINI", q2);

            #endregion

            #region SI0812B_TMESTSIN

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MEST_CODSUBES" , ""},
                { "MEST_FONTE" , ""},
                { "MEST_RAMO" , ""},
                { "MEST_CODCAU" , ""},
                { "MEST_APOL_SINI" , ""},
                { "MEST_NRCERTIF" , ""},
                { "MEST_IDTPSEGU" , ""},
                { "HIST_VALPRI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0812B_TMESTSIN", q3);

            #endregion

            #region M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SUBG_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SEGU_COD_CLIENTE" , ""},
                { "SEGU_COD_AGENCIADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_575_000_LER_TFONTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TFONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_575_000_LER_TFONTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_585_000_LER_SINICAU_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINICAU_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_585_000_LER_SINICAU_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0812B_1")]
        public static void SI0812B_Tests_Theory(string SI0812M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0812M1_FILE_NAME_P = $"{SI0812M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TEMPRESA_NOM_EMP" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , "2020-01-01"},
                { "SIST_DTCURRENT" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0812B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOLICE" , "123456"},
                { "RELSIN_ANO_REF" , "2020"},
                { "RELSIN_MES_REF" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0812B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0812B_V1RELATSINI", q2);

                #endregion

                #region SI0812B_TMESTSIN

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MEST_CODSUBES" , "1"},
                { "MEST_FONTE" , "2"},
                { "MEST_RAMO" , "3"},
                { "MEST_CODCAU" , "4"},
                { "MEST_APOL_SINI" , "5"},
                { "MEST_NRCERTIF" , "6"},
                { "MEST_IDTPSEGU" , "7"},
                { "HIST_VALPRI" , "8"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0812B_TMESTSIN");
                AppSettings.TestSet.DynamicData.Add("SI0812B_TMESTSIN", q3);

                #endregion

                #region M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SUBG_COD_CLIENTE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SEGU_COD_CLIENTE" , "1"},
                { "SEGU_COD_AGENCIADOR" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , "x"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_575_000_LER_TFONTE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "TFONTE_NOMEFTE" , "x"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_575_000_LER_TFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_575_000_LER_TFONTE_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , "x"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_585_000_LER_SINICAU_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINICAU_DESCAU" , ""}
                 });
                AppSettings.TestSet.DynamicData.Remove("M_585_000_LER_SINICAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_585_000_LER_SINICAU_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q10);

                #endregion


                #endregion
                var program = new SI0812B();
                program.Execute(SI0812M1_FILE_NAME_P);                               

                var envList1 = AppSettings.TestSet.DynamicData["M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0812B_V1RELATSINI"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["SI0812B_TMESTSIN"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["M_575_000_LER_TFONTE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList8);

                var envList9 = AppSettings.TestSet.DynamicData["M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList9);

                var envList10 = AppSettings.TestSet.DynamicData["M_585_000_LER_SINICAU_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList10);

                var envList11 = AppSettings.TestSet.DynamicData["M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList11);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0812B_2")]
        public static void SI0812B_Tests99_Theory(string SI0812M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0812M1_FILE_NAME_P = $"{SI0812M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0812B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                //{ "RELSIN_APOLICE" , "123456"},
                { "RELSIN_ANO_REF" , null},
                { "RELSIN_MES_REF" , null},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0812B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0812B_V1RELATSINI", q2);

                #endregion

                #region SI0812B_TMESTSIN

                var q3 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("SI0812B_TMESTSIN");
                AppSettings.TestSet.DynamicData.Add("SI0812B_TMESTSIN", q3);

                #endregion

                #region M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1

                var q4 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1

                var q6 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_575_000_LER_TFONTE_DB_SELECT_1_Query1

                var q7 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_575_000_LER_TFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_575_000_LER_TFONTE_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q8 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_585_000_LER_SINICAU_DB_SELECT_1_Query1

                var q9 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("M_585_000_LER_SINICAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_585_000_LER_SINICAU_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

                var q10 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q10);

                #endregion

                #endregion
                var program = new SI0812B();
                program.Execute(SI0812M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 00);
            }
        }


    }
}