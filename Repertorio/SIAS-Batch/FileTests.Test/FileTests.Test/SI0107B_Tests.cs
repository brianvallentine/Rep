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
using static Code.SI0107B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0107B_Tests")]
    public class SI0107B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "TSISTEMA_DTMOVABE" , ""},
                { "TSISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0107B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TRELSIN_DTINIVIG" , ""},
                { "TRELSIN_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0107B_V1RELATSINI", q2);

            #endregion

            #region SI0107B_RENDIMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RENDIMEN_CODPDT" , ""},
                { "RENDIMEN_VALRDT" , ""},
                { "IMPOST_VLIMPOST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0107B_RENDIMP", q3);

            #endregion

            #region M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TCLIFOR_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "TSISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0107B_1")]
        public static void SI0107B_Tests_Theory_Erro99(string IMPRESSAO_FILE_NAME_P)
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
                #region M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "TSISTEMA_DTMOVABE" , ""},
                { "TSISTEMA_DTCURRENT" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0107B();
                program.Execute(IMPRESSAO_FILE_NAME_P);

                Assert.True(program.WABEND.WSQLCODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0107B_2")]
        public static void SI0107B_Tests_Theory(string IMPRESSAO_FILE_NAME_P)
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
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0107B();
                program.Execute(IMPRESSAO_FILE_NAME_P);

                //M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_015_000_CABECALHOS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_100_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}