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
using static Code.SI0078B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0078B_Tests")]
    public class SI0078B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
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

            #region SI0078B_V0RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0RELATORIOS_ANO_REFERENCIA" , ""},
                { "V0RELATORIOS_MES_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0078B_V0RELATORIOS", q2);

            #endregion

            #region SI0078B_V0HISTSINI

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HISTSINI_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0078B_V0HISTSINI", q3);

            #endregion

            #region SI0078B_SINISTROS

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINI_NUM_APOL_SINISTRO" , ""},
                { "SINI_NUM_APOLICE" , ""},
                { "SINI_NUMIRB" , ""},
                { "SINI_CODCAU" , ""},
                { "SINI_DATCMD" , ""},
                { "SINI_DATORR" , ""},
                { "SINI_SITUACAO" , ""},
                { "SINI_RAMO" , ""},
                { "SINI_OCORHIST" , ""},
                { "SINI_OPERACAO" , ""},
                { "SINI_DTMOVTO" , ""},
                { "SINI_VAL_OPERACAO" , ""},
                { "SINI_NOMFAV" , ""},
                { "SINI_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0078B_SINISTROS", q4);

            #endregion

            #region M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HAB01_NUM_CONTRATO" , ""},
                { "V0HAB01_COD_COBERTURA" , ""},
                { "V0HAB01_NOME_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CAUSA_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_DES_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0078B_t1")]
        public static void SI0078B_Tests_Theory(string SI0078BR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0078BR_FILE_NAME_P = $"{SI0078BR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SISTEMA_DTMOVABE" , ""},
                    { "V1SISTEMA_DTCURRENT" , ""},
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

                #region SI0078B_V0RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0RELATORIOS_ANO_REFERENCIA" , ""},
                    { "V0RELATORIOS_MES_REFERENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0078B_V0RELATORIOS", q2);

                #endregion

                #region SI0078B_V0HISTSINI

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0HISTSINI_NUM_APOL_SINISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_V0HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0078B_V0HISTSINI", q3);

                #endregion

                #region SI0078B_SINISTROS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SINI_NUM_APOL_SINISTRO" , ""},
                    { "SINI_NUM_APOLICE" , ""},
                    { "SINI_NUMIRB" , ""},
                    { "SINI_CODCAU" , ""},
                    { "SINI_DATCMD" , ""},
                    { "SINI_DATORR" , ""},
                    { "SINI_SITUACAO" , ""},
                    { "SINI_RAMO" , ""},
                    { "SINI_OCORHIST" , ""},
                    { "SINI_OPERACAO" , ""},
                    { "SINI_DTMOVTO" , ""},
                    { "SINI_VAL_OPERACAO" , ""},
                    { "SINI_NOMFAV" , ""},
                    { "SINI_CODUSU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_SINISTROS");
                AppSettings.TestSet.DynamicData.Add("SI0078B_SINISTROS", q4);

                #endregion

                #region M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0HAB01_NUM_CONTRATO" , ""},
                    { "V0HAB01_COD_COBERTURA" , ""},
                    { "V0HAB01_NOME_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0CAUSA_DESCAU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "GEOPERAC_DES_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0078B();
                program.Execute(SI0078BR_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 1,
                //"Selects": 4,
                //"Cursors": 3,
                //"Procedures": 0,
                //"All": 8

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0078B_t2")]
        public static void SI0078B_Tests_TheoryReturn99(string SI0078BR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0078BR_FILE_NAME_P = $"{SI0078BR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SISTEMA_DTMOVABE" , ""},
                    { "V1SISTEMA_DTCURRENT" , ""},
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

                #region SI0078B_V0RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0RELATORIOS_ANO_REFERENCIA" , ""},
                    { "V0RELATORIOS_MES_REFERENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0078B_V0RELATORIOS", q2);

                #endregion

                #region SI0078B_V0HISTSINI

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0HISTSINI_NUM_APOL_SINISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_V0HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0078B_V0HISTSINI", q3);

                #endregion

                #region SI0078B_SINISTROS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SINI_NUM_APOL_SINISTRO" , ""},
                    { "SINI_NUM_APOLICE" , ""},
                    { "SINI_NUMIRB" , ""},
                    { "SINI_CODCAU" , ""},
                    { "SINI_DATCMD" , ""},
                    { "SINI_DATORR" , ""},
                    { "SINI_SITUACAO" , ""},
                    { "SINI_RAMO" , ""},
                    { "SINI_OCORHIST" , ""},
                    { "SINI_OPERACAO" , ""},
                    { "SINI_DTMOVTO" , ""},
                    { "SINI_VAL_OPERACAO" , ""},
                    { "SINI_NOMFAV" , ""},
                    { "SINI_CODUSU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0078B_SINISTROS");
                AppSettings.TestSet.DynamicData.Add("SI0078B_SINISTROS", q4);

                #endregion

                #region M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0HAB01_NUM_CONTRATO" , ""},
                    { "V0HAB01_COD_COBERTURA" , ""},
                    { "V0HAB01_NOME_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
          
                });
                AppSettings.TestSet.DynamicData.Remove("M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
             
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0078B();
                program.Execute(SI0078BR_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 1,
                //"Selects": 4,
                //"Cursors": 3,
                //"Procedures": 0,
                //"All": 8

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}