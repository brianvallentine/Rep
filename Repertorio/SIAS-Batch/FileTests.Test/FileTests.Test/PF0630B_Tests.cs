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
using Dclgens;
using Code;
using static Code.PF0630B;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.IO;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("PF0630B_Tests")]
    public class PF0630B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region PF0630B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "SICFAIRC_NUM_SICOB_INI" , ""},
                { "SICFAIRC_NUM_SICOB_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0630B_CURS01", q0);

            #endregion

            #region PF0630B_CURS02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SICFAIRC_NUM_SICOB_INI" , ""},
                { "SICFAIRC_NUM_SICOB_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0630B_CURS02", q1);

            #endregion

            #region M_0105_LE_RELATORIOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0105_LE_RELATORIOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1", q3);

            #endregion

            #region M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PF0630B_IN_t1", "PF0630B_OUT_t1")]
        public static void PF0630B_Tests_Theory(string PARAMETROS_IN_FILE_NAME_P, string PARAMETROS_OUT_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region PF0630B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1234" },
                { "SICFAIRC_NUM_SICOB_INI" , "1000" },
                { "SICFAIRC_NUM_SICOB_FIM" , "2000" },
            });
                AppSettings.TestSet.DynamicData.Remove("PF0630B_CURS01");
                AppSettings.TestSet.DynamicData.Add("PF0630B_CURS01", q0);

                #endregion

                #region PF0630B_CURS02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SICFAIRC_NUM_SICOB_INI" , "1000" },
                { "SICFAIRC_NUM_SICOB_FIM" , "2000" },
            });
                AppSettings.TestSet.DynamicData.Remove("PF0630B_CURS02");
                AppSettings.TestSet.DynamicData.Add("PF0630B_CURS02", q1);

                #endregion

                #region M_0105_LE_RELATORIOS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , "5678" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0105_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0105_LE_RELATORIOS_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1", q3);

                #endregion

                #region M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1", q4);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new PF0630B();
                program.Execute(PARAMETROS_IN_FILE_NAME_P, PARAMETROS_OUT_FILE_NAME_P);

                Assert.True(File.Exists(program.PARAMETROS_IN.FilePath));
                Assert.True(new FileInfo(program.PARAMETROS_IN.FilePath).Length > 0);

                Assert.True(File.Exists(program.PARAMETROS_OUT.FilePath));
                Assert.True(new FileInfo(program.PARAMETROS_OUT.FilePath).Length > 0);

                var deletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count > 1).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();
                Assert.True(deletes.Count >= allDeletes.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("PF0630B_IN_t2", "PF0630B_OUT_t2")]
        public static void PF0630B_Tests_Theory_Erro99(string PARAMETROS_IN_FILE_NAME_P, string PARAMETROS_OUT_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region M_0105_LE_RELATORIOS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""}
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("M_0105_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0105_LE_RELATORIOS_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion

                var program = new PF0630B();
                program.Execute(PARAMETROS_IN_FILE_NAME_P, PARAMETROS_OUT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}