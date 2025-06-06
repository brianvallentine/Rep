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
using static Code.SI0868B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0868B_Tests")]
    public class SI0868B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_UPDATE_1_Update1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

            #endregion

            #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0868B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_RELATORIOS", q2);

            #endregion

            #region SI0868B_C01_FONTES

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , ""},
                { "FONTES_NOME_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_C01_FONTES", q3);

            #endregion

            #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SI0868B_PRODUTOS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_PRODUTOS", q5);

            #endregion

            #region SI0868B_CAUSAS

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_COD_CAUSA" , ""},
                { "SINISCAU_RAMO_EMISSOR" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_CAUSAS", q6);

            #endregion

            #region SI0868B_RAMO

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "HOST_DATA_AVISO_SIAS" , ""},
                { "HOST_VALOR_AVISO_SIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_RAMO", q7);

            #endregion

            #region SI0868B_RAMOVG

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "HOST_DATA_AVISO_SIAS" , ""},
                { "HOST_VALOR_AVISO_SIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0868B_RAMOVG", q8);

            #endregion

            #region R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0868B_t1")]
        public static void SI0868B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0868B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , "1"},
                    { "RELATORI_DATA_SOLICITACAO" , "2025-01-01"},
                    { "RELATORI_PERI_FINAL" , "1"},
                    { "RELATORI_RAMO_EMISSOR" , "81"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RELATORIOS", q2);

                #endregion

                #region SI0868B_C01_FONTES

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_COD_FONTE" , "1"},
                    { "FONTES_NOME_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_C01_FONTES");
                AppSettings.TestSet.DynamicData.Add("SI0868B_C01_FONTES", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0868B_PRODUTOS

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_COD_PRODUTO" , "1"},
                    { "PRODUTO_DESCR_PRODUTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_PRODUTOS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_PRODUTOS", q5);

                #endregion

                #region SI0868B_CAUSAS

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISCAU_COD_CAUSA" , "1"},
                    { "SINISCAU_RAMO_EMISSOR" , "1"},
                    { "SINISCAU_DESCR_CAUSA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_CAUSAS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_CAUSAS", q6);

                #endregion

                #region SI0868B_RAMO

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOLICE" , "1"},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_RAMO" , "1"},
                    { "SINISMES_COD_PRODUTO" , "1"},
                    { "SINISMES_COD_FONTE" , "1"},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                    { "SINISMES_NUM_CERTIFICADO" , "1"},
                    { "SINISMES_COD_SUBGRUPO" , "1"},
                    { "SINISMES_COD_CAUSA" , "1"},
                    { "HOST_DATA_AVISO_SIAS" , "2024-05-05" },
                    { "HOST_VALOR_AVISO_SIAS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RAMO");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RAMO", q7);

                #endregion

                #region SI0868B_RAMOVG

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOLICE" , "1"},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_RAMO" , "1"},
                    { "SINISMES_COD_PRODUTO" , "1"},
                    { "SINISMES_COD_FONTE" , "1"},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                    { "SINISMES_NUM_CERTIFICADO" , "1"},
                    { "SINISMES_COD_SUBGRUPO" , "1"},
                    { "SINISMES_COD_CAUSA" , "1"},
                    { "HOST_DATA_AVISO_SIAS" , "2024-01-01"},
                    { "HOST_VALOR_AVISO_SIAS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RAMOVG");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RAMOVG", q8);

                #endregion

                #region R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
                var program = new SI0868B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

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
        [InlineData("SI0868B_t2")]
        public static void SI0868B_Tests_Theory_Return99(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0868B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , "1"},
                    { "RELATORI_DATA_SOLICITACAO" , "2025-01-01"},
                    { "RELATORI_PERI_FINAL" , "1"},
                    { "RELATORI_RAMO_EMISSOR" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RELATORIOS", q2);

                #endregion

                #region SI0868B_C01_FONTES

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_COD_FONTE" , "1"},
                    { "FONTES_NOME_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_C01_FONTES");
                AppSettings.TestSet.DynamicData.Add("SI0868B_C01_FONTES", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0868B_PRODUTOS

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_COD_PRODUTO" , "1"},
                    { "PRODUTO_DESCR_PRODUTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_PRODUTOS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_PRODUTOS", q5);

                #endregion

                #region SI0868B_CAUSAS

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISCAU_COD_CAUSA" , "1"},
                    { "SINISCAU_RAMO_EMISSOR" , "1"},
                    { "SINISCAU_DESCR_CAUSA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_CAUSAS");
                AppSettings.TestSet.DynamicData.Add("SI0868B_CAUSAS", q6);

                #endregion

                #region SI0868B_RAMO

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
               
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RAMO");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RAMO", q7);

                #endregion

                #region SI0868B_RAMOVG

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOLICE" , "1"},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_RAMO" , "1"},
                    { "SINISMES_COD_PRODUTO" , "1"},
                    { "SINISMES_COD_FONTE" , "1"},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                    { "SINISMES_NUM_CERTIFICADO" , "1"},
                    { "SINISMES_COD_SUBGRUPO" , "1"},
                    { "SINISMES_COD_CAUSA" , "1"},
                    { "HOST_DATA_AVISO_SIAS" , "2024-01-01"},
                    { "HOST_VALOR_AVISO_SIAS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0868B_RAMOVG");
                AppSettings.TestSet.DynamicData.Add("SI0868B_RAMOVG", q8);

                #endregion

                #region R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
                var program = new SI0868B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}