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
using static Code.SI2010B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI2010B_Tests")]
    public class SI2010B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI2010B_V1HISTMEST

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI2010B_V1HISTMEST", q2);

            #endregion

            #region SI2010B_V1SISINCHE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI2010B_V1SISINCHE", q3);

            #endregion

            #region R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "WS_DIA_DT_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "SIPADOFI_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI2010B_t1")]
        public static void SI2010B_Tests_Theory(string SI2010B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI2010B1_FILE_NAME_P = $"{SI2010B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI2010B_V1HISTMEST

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI2010B_V1HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI2010B_V1HISTMEST", q2);

                #endregion

                #region SI2010B_V1SISINCHE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("SI2010B_V1SISINCHE");
                AppSettings.TestSet.DynamicData.Add("SI2010B_V1SISINCHE", q3);

                #endregion

                #region R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "WS_DIA_DT_EMISSAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "SIPADOFI_OCORR_HISTORICO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI2010B();
                program.Execute(SI2010B1_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI2010B_t2")]
        public static void SI2010B_Tests_TheoryReturn99(string SI2010B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI2010B1_FILE_NAME_P = $"{SI2010B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
     
            });
                AppSettings.TestSet.DynamicData.Remove("R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI2010B_V1HISTMEST

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI2010B_V1HISTMEST");
                AppSettings.TestSet.DynamicData.Add("SI2010B_V1HISTMEST", q2);

                #endregion

                #region SI2010B_V1SISINCHE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("SI2010B_V1SISINCHE");
                AppSettings.TestSet.DynamicData.Add("SI2010B_V1SISINCHE", q3);

                #endregion

                #region R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "WS_DIA_DT_EMISSAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "SIPADOFI_OCORR_HISTORICO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI2010B();
                program.Execute(SI2010B1_FILE_NAME_P);

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