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
using static Code.SI0843B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0843B_Tests")]
    public class SI0843B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0843B_V0RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0CODUSU" , ""},
                { "V0PERI_INICIAL" , ""},
                { "V0PERI_FINAL" , ""},
                { "V0NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0843B_V0RELATORIOS", q1);

            #endregion

            #region SI0843B_V0TRANSP1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0NUM_APOL_SINISTRO" , ""},
                { "V0COD_FRANQUE" , ""},
                { "V0IND_VAL_DECLARADO" , ""},
                { "V0QTD_ITENS_SINI" , ""},
                { "V0QTD_ITENS_TRANSP" , ""},
                { "V0NUM_SINI_FRANQUE" , ""},
                { "V0ANO_SINI_FRANQUE" , ""},
                { "V0DATA_OCORR" , ""},
                { "V0SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0843B_V0TRANSP1", q2);

            #endregion

            #region R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

            #endregion

            #region R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0VAL_OPERACAO_PEND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1", q6);

            #endregion

            #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0VAL_OPERACAO_PEND1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0843B_t1")]
        public static void SI0843B_Tests_Theory(string SI0843_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0843_FILE_NAME_P = $"{SI0843_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0843B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0CODUSU" , ""},
                    { "V0PERI_INICIAL" , ""},
                    { "V0PERI_FINAL" , ""},
                    { "V0NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0843B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0843B_V0RELATORIOS", q1);

                #endregion

                #region SI0843B_V0TRANSP1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0NUM_APOL_SINISTRO" , ""},
                    { "V0COD_FRANQUE" , ""},
                    { "V0IND_VAL_DECLARADO" , ""},
                    { "V0QTD_ITENS_SINI" , ""},
                    { "V0QTD_ITENS_TRANSP" , ""},
                    { "V0NUM_SINI_FRANQUE" , ""},
                    { "V0ANO_SINI_FRANQUE" , ""},
                    { "V0DATA_OCORR" , ""},
                    { "V0SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0843B_V0TRANSP1");
                AppSettings.TestSet.DynamicData.Add("SI0843B_V0TRANSP1", q2);

                #endregion

                #region R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

                #endregion

                #region R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0VAL_OPERACAO_PEND" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1", q6);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0VAL_OPERACAO_PEND1" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1", q7);

                #endregion

                #endregion
                var program = new SI0843B();
                program.Execute(SI0843_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 1,
                //"Selects": 5,
                //"Cursors": 2,
                //"Procedures": 0,
                //"All": 8

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0843B_t2")]
        public static void SI0843B_Tests_TheoryReturn99(string SI0843_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0843_FILE_NAME_P = $"{SI0843_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0843B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0CODUSU" , ""},
                    { "V0PERI_INICIAL" , ""},
                    { "V0PERI_FINAL" , ""},
                    { "V0NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0843B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0843B_V0RELATORIOS", q1);

                #endregion

                #region SI0843B_V0TRANSP1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0NUM_APOL_SINISTRO" , ""},
                    { "V0COD_FRANQUE" , ""},
                    { "V0IND_VAL_DECLARADO" , ""},
                    { "V0QTD_ITENS_SINI" , ""},
                    { "V0QTD_ITENS_TRANSP" , ""},
                    { "V0NUM_SINI_FRANQUE" , ""},
                    { "V0ANO_SINI_FRANQUE" , ""},
                    { "V0DATA_OCORR" , ""},
                    { "V0SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0843B_V0TRANSP1");
                AppSettings.TestSet.DynamicData.Add("SI0843B_V0TRANSP1", q2);

                #endregion

                #region R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q3);

                #endregion

                #region R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
              
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1", q6);

                #endregion

                #region R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
           
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1", q7);

                #endregion

                #endregion
                var program = new SI0843B();
                program.Execute(SI0843_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 1,
                //"Selects": 5,
                //"Cursors": 2,
                //"Procedures": 0,
                //"All": 8

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}