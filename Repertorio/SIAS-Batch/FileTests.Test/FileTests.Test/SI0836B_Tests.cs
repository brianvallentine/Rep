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
using static Code.SI0836B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0836B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0836B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0RELATORIOS_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region Execute_DB_DELETE_1_Delete1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_DELETE_1_Delete1", q1);

            #endregion

            #region M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region SI0836B_HISTMEST

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HISTMEST_FONTE" , ""},
                { "V0HISTMEST_PROTSINI" , ""},
                { "V0HISTMEST_DAC" , ""},
                { "V0HISTMEST_NUM_APOL_SINISTRO" , ""},
                { "V0HISTMEST_NUM_APOLICE" , ""},
                { "V0HISTMEST_OPERACAO" , ""},
                { "V0HISTMEST_VAL_OPERACAO" , ""},
                { "V0HISTMEST_NOMFAV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0836B_HISTMEST", q3);

            #endregion

            #region M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0SINIAUTO1_NUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0APOLICE_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0836B_OUTPUT_202504030000")]
        public static void SI0836B_Tests_Theory(string SI0836M1_FILE_NAME_P)
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
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0RELATORIOS_DATA_REFERENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_DELETE_1_Delete1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_DELETE_1_Delete1", q1);

                #endregion

                #region M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1SISTEMA_DTMOVABE" , ""},
                    { "V1SISTEMA_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region SI0836B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0HISTMEST_FONTE" , ""},
                    { "V0HISTMEST_PROTSINI" , ""},
                    { "V0HISTMEST_DAC" , ""},
                    { "V0HISTMEST_NUM_APOL_SINISTRO" , ""},
                    { "V0HISTMEST_NUM_APOLICE" , ""},
                    { "V0HISTMEST_OPERACAO" , ""},
                    { "V0HISTMEST_VAL_OPERACAO" , ""},
                    { "V0HISTMEST_NOMFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0836B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0836B_HISTMEST", q3);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0SINIAUTO1_NUM_ITEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0APOLICE_CODCLIEN" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIENTE_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1", q6);

                #endregion

                #endregion
                #endregion
                var program = new SI0836B();
                program.Execute(SI0836M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0836M1.FilePath));
                Assert.True(new FileInfo(program.SI0836M1.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                
                var deletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count == 0).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));
                Assert.True(deletes.Count > (allDeletes.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0836B_OUTPUT_202504030001")]
        public static void SI0836B_Tests_Theory_ReturnCode99(string SI0836M1_FILE_NAME_P)
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
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_DELETE_1_Delete1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_DELETE_1_Delete1", q1);

                #endregion

                #region M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region SI0836B_HISTMEST

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0HISTMEST_FONTE" , ""},
                    { "V0HISTMEST_PROTSINI" , ""},
                    { "V0HISTMEST_DAC" , ""},
                    { "V0HISTMEST_NUM_APOL_SINISTRO" , ""},
                    { "V0HISTMEST_NUM_APOLICE" , ""},
                    { "V0HISTMEST_OPERACAO" , ""},
                    { "V0HISTMEST_VAL_OPERACAO" , ""},
                    { "V0HISTMEST_NOMFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0836B_HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI0836B_HISTMEST", q3);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0SINIAUTO1_NUM_ITEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0APOLICE_CODCLIEN" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIENTE_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1", q6);

                #endregion

                #endregion
                #endregion
                var program = new SI0836B();
                program.Execute(SI0836M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}