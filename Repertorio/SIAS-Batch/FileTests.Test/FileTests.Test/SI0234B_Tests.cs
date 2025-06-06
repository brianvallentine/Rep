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
using static Code.SI0234B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0234B_Tests")]
    public class SI0234B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1", q2);

            #endregion

            #region R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINCREIN_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1", q3);

            #endregion

            #region R210_LE_MATCON_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R210_LE_MATCON_DB_SELECT_1_Query1", q4);

            #endregion

            #region R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0234BEntrada", "SI0234B_t1")]
        public static void SI0234B_Tests_Theory(string REG_ENT_FILE_NAME_P, string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1", q2);

                #endregion

                #region R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
                { "SINCREIN_NUM_APOL_SINISTRO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1", q3);

                #endregion

                #region R210_LE_MATCON_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R210_LE_MATCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_MATCON_DB_SELECT_1_Query1", q4);

                #endregion

                #region R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1

                var q5 = new DynamicData(); 
                q5.AddDynamic(new Dictionary<string, string>{
                 { "RELATORI_COD_USUARIO" , "VA7118B"},
                 { "RELATORI_DATA_SOLICITACAO" , "2024-10-15"},
                 { "RELATORI_IDE_SISTEMA" , "VA"},
                 { "RELATORI_COD_RELATORIO" , ""},
                 { "RELATORI_NUM_COPIAS" , "0"},
                 { "RELATORI_QUANTIDADE" , "0"},
                 { "RELATORI_PERI_INICIAL" , "2024-10-15"},
                 { "RELATORI_PERI_FINAL" , "2024-10-15"},
                 { "RELATORI_DATA_REFERENCIA" , "2024-10-15"},
                 { "RELATORI_MES_REFERENCIA" , "0"},
                 { "RELATORI_ANO_REFERENCIA" , "0"},
                 { "RELATORI_ORGAO_EMISSOR" , "0"},
                 { "RELATORI_COD_FONTE" , "0"},
                 { "RELATORI_COD_PRODUTOR" , "0"},
                 { "RELATORI_RAMO_EMISSOR" , "0"},
                 { "RELATORI_COD_MODALIDADE" , "0"},
                 { "RELATORI_COD_CONGENERE" , "0"},
                 { "RELATORI_NUM_APOLICE" , "3.009.300.007.514"},
                 { "RELATORI_NUM_ENDOSSO" , "0"},
                 { "RELATORI_NUM_PARCELA" , "0"},
                 { "RELATORI_NUM_CERTIFICADO" , "82.525.370.000.026"},
                 { "RELATORI_NUM_TITULO" , "0"},
                 { "RELATORI_COD_SUBGRUPO" , "1"},
                 { "RELATORI_COD_OPERACAO" , "0"},
                 { "RELATORI_COD_PLANO" , "0"},
                 { "RELATORI_OCORR_HISTORICO" , "0"},
                 { "RELATORI_NUM_APOL_LIDER" , ""},
                 { "RELATORI_ENDOS_LIDER" , ""},
                 { "RELATORI_NUM_PARC_LIDER" , "0"},
                 { "RELATORI_NUM_SINISTRO" , "0"},
                 { "RELATORI_NUM_SINI_LIDER" , ""},
                 { "RELATORI_NUM_ORDEM" , "0"},
                 { "RELATORI_COD_MOEDA" , "0"},
                 { "RELATORI_TIPO_CORRECAO" , ""},
                 { "RELATORI_SIT_REGISTRO" , "0"},
                 { "RELATORI_IND_PREV_DEFINIT" , ""},
                 { "RELATORI_IND_ANAL_RESUMO" , ""},
                 { "RELATORI_PERI_RENOVACAO" , "0"},
                 { "RELATORI_PCT_AUMENTO" , ""},
                 { "RELATORI_TIMESTAMP" , "2024-10-15 17:17:40.456"}
                });

                AppSettings.TestSet.DynamicData.Remove("R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q5);

                #endregion

                #endregion
                var program = new SI0234B();
                program.Execute(REG_ENT_FILE_NAME_P, REG_RET_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                var envList = AppSettings.TestSet.DynamicData["R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[0].TryGetValue("RELATORI_NUM_APOLICE", out var valor) && valor.Contains("3.009.300.007.514"));
                Assert.True(envList.Count > 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0234BEntrada", "SI0234B_t2")]
        public static void SI0234B_Tests_TheoryReturn99(string REG_ENT_FILE_NAME_P, string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
     
            });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
     
            });
                AppSettings.TestSet.DynamicData.Remove("R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
            
            });
                AppSettings.TestSet.DynamicData.Remove("R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1", q2);

                #endregion

                #region R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{

            });
                AppSettings.TestSet.DynamicData.Remove("R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1", q3);

                #endregion

                #region R210_LE_MATCON_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{

            });
                AppSettings.TestSet.DynamicData.Remove("R210_LE_MATCON_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R210_LE_MATCON_DB_SELECT_1_Query1", q4);

                #endregion

                #region R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                 { "RELATORI_COD_USUARIO" , "VA7118B"},
                 { "RELATORI_DATA_SOLICITACAO" , "2024-10-15"},
                 { "RELATORI_IDE_SISTEMA" , "VA"},
                 { "RELATORI_COD_RELATORIO" , ""},
                 { "RELATORI_NUM_COPIAS" , "0"},
                 { "RELATORI_QUANTIDADE" , "0"},
                 { "RELATORI_PERI_INICIAL" , "2024-10-15"},
                 { "RELATORI_PERI_FINAL" , "2024-10-15"},
                 { "RELATORI_DATA_REFERENCIA" , "2024-10-15"},
                 { "RELATORI_MES_REFERENCIA" , "0"},
                 { "RELATORI_ANO_REFERENCIA" , "0"},
                 { "RELATORI_ORGAO_EMISSOR" , "0"},
                 { "RELATORI_COD_FONTE" , "0"},
                 { "RELATORI_COD_PRODUTOR" , "0"},
                 { "RELATORI_RAMO_EMISSOR" , "0"},
                 { "RELATORI_COD_MODALIDADE" , "0"},
                 { "RELATORI_COD_CONGENERE" , "0"},
                 { "RELATORI_NUM_APOLICE" , "3.009.300.007.514"},
                 { "RELATORI_NUM_ENDOSSO" , "0"},
                 { "RELATORI_NUM_PARCELA" , "0"},
                 { "RELATORI_NUM_CERTIFICADO" , "82.525.370.000.026"},
                 { "RELATORI_NUM_TITULO" , "0"},
                 { "RELATORI_COD_SUBGRUPO" , "1"},
                 { "RELATORI_COD_OPERACAO" , "0"},
                 { "RELATORI_COD_PLANO" , "0"},
                 { "RELATORI_OCORR_HISTORICO" , "0"},
                 { "RELATORI_NUM_APOL_LIDER" , ""},
                 { "RELATORI_ENDOS_LIDER" , ""},
                 { "RELATORI_NUM_PARC_LIDER" , "0"},
                 { "RELATORI_NUM_SINISTRO" , "0"},
                 { "RELATORI_NUM_SINI_LIDER" , ""},
                 { "RELATORI_NUM_ORDEM" , "0"},
                 { "RELATORI_COD_MOEDA" , "0"},
                 { "RELATORI_TIPO_CORRECAO" , ""},
                 { "RELATORI_SIT_REGISTRO" , "0"},
                 { "RELATORI_IND_PREV_DEFINIT" , ""},
                 { "RELATORI_IND_ANAL_RESUMO" , ""},
                 { "RELATORI_PERI_RENOVACAO" , "0"},
                 { "RELATORI_PCT_AUMENTO" , ""},
                 { "RELATORI_TIMESTAMP" , "2024-10-15 17:17:40.456"}
                });

                AppSettings.TestSet.DynamicData.Remove("R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R300_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q5);

                #endregion

                #endregion
                var program = new SI0234B();
                program.Execute(REG_ENT_FILE_NAME_P, REG_RET_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}