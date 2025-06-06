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
using static Code.SI0105B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0105B_Tests")]
    public class SI0105B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0105B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , ""},
                { "V1RELATORIOS_DATA2" , ""},
                { "V1RELATORIOS_APOLICE1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0105B_RELATORIOS", q2);

            #endregion

            #region SI0105B_HISTMEST

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_VAL_OPERACAO" , ""},
                { "V1HISTMEST_MODALIDA" , ""},
                { "V1HISTMEST_SIGLUNIM" , ""},
                { "V1HISTMEST_VLCRUZAD" , ""},
                { "V1HISTMEST_DATCMD" , ""},
                { "V1HISTMEST_DATORR" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_NOME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0105B_HISTMEST", q3);

            #endregion

            #region M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1", q4);

            #endregion

            #region M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0105B_1")]
        public static void SI0105B_Tests_Theory_Erro99(string SI0105M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0105M1_FILE_NAME_P = $"{SI0105M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new SI0105B();
                program.Execute(SI0105M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0105B_2")]
        public static void SI0105B_Tests_Theory(string SI0105M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0105M1_FILE_NAME_P = $"{SI0105M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0105B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_VAL_OPERACAO" , ""},
                { "V1HISTMEST_MODALIDA" , ""},
                { "V1HISTMEST_SIGLUNIM" , ""},
                { "V1HISTMEST_VLCRUZAD" , "1"},
                { "V1HISTMEST_DATCMD" , ""},
                { "V1HISTMEST_DATORR" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_NOME" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0105B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0105B_HISTMEST", q3);

                #endregion
                #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "CAIXA"}
            });
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0105B();
                program.Execute(SI0105M1_FILE_NAME_P);

                //M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_000_600_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1"].DynamicList);

                //M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1"].DynamicList);

                //M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}