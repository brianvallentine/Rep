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
using static Code.SI0805B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0805B_Tests")]
    public class SI0805B_Tests
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

            #region SI0805B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOLICE" , ""},
                { "RELSIN_ANO_REF" , ""},
                { "RELSIN_MES_REF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0805B_V1RELATSINI", q2);

            #endregion

            #region SI0805B_TMESTSIN

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
            AppSettings.TestSet.DynamicData.Add("SI0805B_TMESTSIN", q3);

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
        [InlineData("SI0805B_t1")]
        public static void SI0805B_Tests_Theory_Erro99(string SI0805M1_FILE_NAME_P)
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
                #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TEMPRESA_NOM_EMP" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0805B();
                program.Execute(SI0805M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0805B_t2")]
        public static void SI0805B_Tests_Theory(string SI0805M1_FILE_NAME_P)
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
                #region M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TEMPRESA_NOM_EMP" , "CAIXA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0805B();
                program.Execute(SI0805M1_FILE_NAME_P);

                //M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);
                //M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1"].DynamicList);
                //M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1"].DynamicList);
                //M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_572_000_LER_TCLIENTE_DB_SELECT_1_Query1"].DynamicList);
                //M_575_000_LER_TFONTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_575_000_LER_TFONTE_DB_SELECT_1_Query1"].DynamicList);
                //M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_580_000_LER_TAPOLICE_DB_SELECT_1_Query1"].DynamicList);
                //M_585_000_LER_SINICAU_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_585_000_LER_SINICAU_DB_SELECT_1_Query1"].DynamicList);
                //M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}