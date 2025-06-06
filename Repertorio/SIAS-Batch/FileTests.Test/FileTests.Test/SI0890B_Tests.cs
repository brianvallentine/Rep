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
using static Code.SI0890B;
using System.IO;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0890B_Tests")]
    public class SI0890B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0890B_CR_LOTER

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "HOST_DATA_AVISO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "HOST_VALOR_AVISO" , ""},
                { "SINILT01_COD_CLIENTE" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_COD_COBERTURA" , ""},
                { "SINISCAU_COD_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0890B_CR_LOTER", q0);

            #endregion

            #region SI0890B_CR_RELAT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0890B_CR_RELAT", q1);

            #endregion

            #region SI0890B_CR_ADIANT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_ADIANTAMENTO" , ""},
                { "HOST_VALOR_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0890B_CR_ADIANT", q2);

            #endregion

            #region R0130_LER_CLIENTES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_LER_CLIENTES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_FRANQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R111020_LE_LOTERICO01_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_CIDADE" , ""},
                { "LOTERI01_COD_CLASSE_ADESAO" , ""},
                { "LOTERI01_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R111020_LE_LOTERICO01_DB_SELECT_1_Query1", q6);

            #endregion

            #region R111030_LE_APOLICES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R111030_LE_APOLICES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R111040_LE_OUTROS_COB_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_IMP_SEGURADA_IX" , ""},
                { "OUTROCOB_DATA_INIVIGENCIA" , ""},
                { "OUTROCOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R111040_LE_OUTROS_COB_DB_SELECT_1_Query1", q8);

            #endregion

            #region R111050_LE_AGENCIAS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111050_LE_AGENCIAS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0890B_out_t1")]
        public static void SI0890B_Tests_Theory(string LOTER01_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1002S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();
                SI0006S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region SI0890B_CR_LOTER

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOLICE" , "123456789" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "987654321" },
                { "SINISCAU_DESCR_CAUSA" , "Acidente de trânsito" },
                { "SINISHIS_NOME_FAVORECIDO" , "João Silva" },
                { "HOST_DATA_AVISO" , "2023-12-01" },
                { "SINISMES_DATA_OCORRENCIA" , "2023-11-25" },
                { "SINISMES_COD_PRODUTO" , "PROD123" },
                { "HOST_VALOR_AVISO" , "15000" },
                { "SINILT01_COD_CLIENTE" , "CLI789" },
                { "SINILT01_COD_LOT_CEF" , "LOT456" },
                { "SINILT01_COD_COBERTURA" , "7" },
                { "SINISCAU_COD_CAUSA" , "CAU001" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_LOTER");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_LOTER", q0);

                #endregion

                #region SI0890B_CR_RELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , "2023-01-01" },
                { "RELATORI_PERI_FINAL" , "2023-12-31" },
                { "RELATORI_COD_PRODUTOR" , "PROD789" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_RELAT");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_RELAT", q1);

                #endregion

                #region SI0890B_CR_ADIANT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_ADIANTAMENTO" , "2023-12-05" },
                { "HOST_VALOR_ADIANTAMENTO" , "5000" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_ADIANT");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_ADIANT", q2);

                #endregion

                #region R0130_LER_CLIENTES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Empresa XYZ" },
                { "CLIENTES_CGCCPF" , "12.345.678/0001-99" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_LER_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_LER_CLIENTES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , "Acidente de trânsito" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_FRANQUIA" , "2000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R111020_LE_LOTERICO01_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_SIGLA_UF" , "SP" },
                { "LOTERI01_CIDADE" , "São Paulo" },
                { "LOTERI01_COD_CLASSE_ADESAO" , "CLAD789" },
                { "LOTERI01_AGENCIA" , "AG789" },
            });
                AppSettings.TestSet.DynamicData.Remove("R111020_LE_LOTERICO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111020_LE_LOTERICO01_DB_SELECT_1_Query1", q6);

                #endregion

                #region R111030_LE_APOLICES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "Seguros S.A." },
                { "APOLICES_COD_MODALIDADE" , "MOD123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R111030_LE_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111030_LE_APOLICES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R111040_LE_OUTROS_COB_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_IMP_SEGURADA_IX" , "300000" },
                { "OUTROCOB_DATA_INIVIGENCIA" , "2023-01-01" },
                { "OUTROCOB_DATA_TERVIGENCIA" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R111040_LE_OUTROS_COB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111040_LE_OUTROS_COB_DB_SELECT_1_Query1", q8);

                #endregion

                #region R111050_LE_AGENCIAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "ESC456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R111050_LE_AGENCIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111050_LE_AGENCIAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q10);

                #endregion

                #endregion

                #endregion

                var program = new SI0890B();
                program.Execute(LOTER01_FILE_NAME_P);

                Assert.True(File.Exists(program.LOTER01.FilePath));
                Assert.True(new FileInfo(program.LOTER01.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.True(inserts.Count >= allInserts.Count / 2);
                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0890B_out_t2")]
        public static void SI0890B_Tests_TheoryReturn99(string LOTER01_FILE_NAME_P)
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

                #region SI0890B_CR_LOTER

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "HOST_DATA_AVISO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "HOST_VALOR_AVISO" , ""},
                { "SINILT01_COD_CLIENTE" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_COD_COBERTURA" , ""},
                { "SINISCAU_COD_CAUSA" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_LOTER");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_LOTER", q0);

                #endregion

                #region SI0890B_CR_RELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_RELAT");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_RELAT", q1);

                #endregion

                #region SI0890B_CR_ADIANT

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_ADIANTAMENTO" , ""},
                { "HOST_VALOR_ADIANTAMENTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0890B_CR_ADIANT");
                AppSettings.TestSet.DynamicData.Add("SI0890B_CR_ADIANT", q2);

                #endregion

                #region R0130_LER_CLIENTES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0130_LER_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0130_LER_CLIENTES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_FRANQUIA" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R111020_LE_LOTERICO01_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_CIDADE" , ""},
                { "LOTERI01_COD_CLASSE_ADESAO" , ""},
                { "LOTERI01_AGENCIA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R111020_LE_LOTERICO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111020_LE_LOTERICO01_DB_SELECT_1_Query1", q6);

                #endregion

                #region R111030_LE_APOLICES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R111030_LE_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111030_LE_APOLICES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R111040_LE_OUTROS_COB_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
      
            });
                AppSettings.TestSet.DynamicData.Remove("R111040_LE_OUTROS_COB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111040_LE_OUTROS_COB_DB_SELECT_1_Query1", q8);

                #endregion

                #region R111050_LE_AGENCIAS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R111050_LE_AGENCIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R111050_LE_AGENCIAS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q10);

                #endregion

                #endregion
                var program = new SI0890B();
                program.Execute(LOTER01_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}