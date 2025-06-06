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
using static Code.SI0814B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0814B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0814B_Tests
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

            #region SI0814B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_PERI_INICIAL" , ""},
                { "RELSIN_PERI_FINAL" , ""},
                { "RELSIN_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0814B_V1RELATSINI", q2);

            #endregion

            #region SI0814B_MESTSINI

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MEST_RAMO" , ""},
                { "MEST_APOLICE" , ""},
                { "MEST_APOL_SINI" , ""},
                { "MEST_DATORR" , ""},
                { "MEST_CODCAU" , ""},
                { "HIST_DTMOVTO" , ""},
                { "HIST_FONPAG" , ""},
                { "HIST_OPERACAO" , ""},
                { "HIST_VALPRI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0814B_MESTSINI", q3);

            #endregion

            #region M_575_000_LER_TRAMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_575_000_LER_TRAMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q6);

            #endregion

            #region M_600_000_LER_TCAUSA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CAUS_NOMECAUSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_LER_TCAUSA_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDO_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0814B_OUTPUT_202504020000")]
        public static void SI0814B_Tests_Theory(string SI0814M1_FILE_NAME_P)
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
                #region PARAMETERS
                #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "TEMPRESA_NOM_EMP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMOVABE" , ""},
                    { "SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0814B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELSIN_PERI_INICIAL" , ""},
                    { "RELSIN_PERI_FINAL" , ""},
                    { "RELSIN_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0814B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0814B_V1RELATSINI", q2);

                #endregion

                #region SI0814B_MESTSINI

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "MEST_RAMO" , "1"},
                    { "MEST_APOLICE" , ""},
                    { "MEST_APOL_SINI" , "1"},
                    { "MEST_DATORR" , ""},
                    { "MEST_CODCAU" , ""},
                    { "HIST_DTMOVTO" , ""},
                    { "HIST_FONPAG" , ""},
                    { "HIST_OPERACAO" , ""},
                    { "HIST_VALPRI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0814B_MESTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0814B_MESTSINI", q3);

                #endregion

                #region M_575_000_LER_TRAMO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "RAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_575_000_LER_TRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_575_000_LER_TRAMO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q6);

                #endregion

                #region M_600_000_LER_TCAUSA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CAUS_NOMECAUSA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_600_000_LER_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_600_000_LER_TCAUSA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "ENDO_DTINIVIG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TENDOSSO_DB_SELECT_1_Query1", q8);

                #endregion

                #endregion
                #endregion
                var program = new SI0814B();
                program.Execute(SI0814M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0814M1.FilePath));
                Assert.True(new FileInfo(program.SI0814M1.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0814B_OUTPUT_202504020001")]
        public static void SI0814B_Tests_Theory_ReturnCode99(string SI0814M1_FILE_NAME_P)
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
                #region PARAMETERS
                #region M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                #endregion
                var program = new SI0814B();
                program.Execute(SI0814M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}