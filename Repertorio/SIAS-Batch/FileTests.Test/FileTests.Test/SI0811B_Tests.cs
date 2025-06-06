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
using Code;
using static Code.SI0811B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0811B_Tests")]
    public class SI0811B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , ""},
                { "V1MOEDA_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q5);

            #endregion

            #region SI0811B_CRELATORIOS

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "WHOST_DATA_INICIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0811B_CRELATORIOS", q6);

            #endregion

            #region SI0811B_JOIN_HIST_MEST

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0811B_JOIN_HIST_MEST", q7);

            #endregion

            #region M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q8);

            #endregion
            SI1000S_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("SI0811B_t1")]
        public static void SI0811B_Tests_Theory(string RSI0811B_FILE_NAME_P)
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


                #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"},
                { "V1SIST_DTCURRENT" , "2025-04-02"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "Teste"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , "1"},
                { "V1MOEDA_SIGLUNIM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q5);

                #endregion

                #region SI0811B_CRELATORIOS

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_RAMO_EMISSOR" , "1"},
                { "RELATORI_NUM_APOLICE" , "1"},
                { "RELATORI_COD_MOEDA" , "1"},
                { "RELATORI_PERI_INICIAL" , "1"},
                { "RELATORI_PERI_FINAL" , "1"},
                { "RELATORI_COD_USUARIO" , "1"},
                { "RELATORI_DATA_SOLICITACAO" , "2025-01-01"},
                { "WHOST_DATA_INICIO" , "2025-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0811B_CRELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0811B_CRELATORIOS", q6);

                #endregion

                #region SI0811B_JOIN_HIST_MEST

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "1"},
                { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                { "SINISMES_RAMO" , "1"},
                { "SINISMES_NUM_CERTIFICADO" , "1"},
                { "SINISMES_SIT_REGISTRO" , "1"},
                { "SINISMES_DATA_COMUNICADO" , "2025-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0811B_JOIN_HIST_MEST");
                AppSettings.TestSet.DynamicData.Add("SI0811B_JOIN_HIST_MEST", q7);

                #endregion

                #region M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q8);

                #endregion

                #endregion

                var program = new SI0811B();
                program.Execute(RSI0811B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0811B_t2")]
        public static void SI0811B_Tests_Theory_Return99(string RSI0811B_FILE_NAME_P)
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


                #region M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"},
                { "V1SIST_DTCURRENT" , "2025-04-02"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "Teste"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , "1"},
                { "V1MOEDA_SIGLUNIM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1", q5);

                #endregion

                #region SI0811B_CRELATORIOS

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "WHOST_DATA_INICIO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0811B_CRELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0811B_CRELATORIOS", q6);

                #endregion

                #region SI0811B_JOIN_HIST_MEST

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0811B_JOIN_HIST_MEST");
                AppSettings.TestSet.DynamicData.Add("SI0811B_JOIN_HIST_MEST", q7);

                #endregion

                #region M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1", q8);

                #endregion

                #endregion

                var program = new SI0811B();
                program.Execute(RSI0811B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}