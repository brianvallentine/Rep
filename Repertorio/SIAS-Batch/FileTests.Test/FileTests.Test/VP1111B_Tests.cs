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
using static Code.VP1111B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VP1111B_Tests")]
    public class VP1111B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VP1111B_CR_CANC_SIAS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOVA_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_SIAS", q0);

            #endregion

            #region VP1111B_CR_CANC_EFP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , ""},
                { "EF150_NUM_CONTRATO_SEGUR" , ""},
                { "EF150_NOM_ARQUIVO" , ""},
                { "EF150_NUM_CONTR_TERC" , ""},
                { "EF150_NUM_APOLICE" , ""},
                { "EF150_COD_PRODUTO" , ""},
                { "EF050_DTH_FIM_VIGENCIA" , ""},
                { "EF150_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_EFP", q1);

            #endregion

            #region VP1111B_CR_CANC_ARQ

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , ""},
                { "WS_DATA_CANCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_ARQ", q2);

            #endregion

            #region R10000_INICIALIZA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R10000_INICIALIZA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_INI" , ""},
                { "WS_DT_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_2_Query1", q4);

            #endregion

            #region R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "EF158_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTRATO_SEGUR" , ""},
                { "EF150_NUM_OCORR_MOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTR_TERC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1", q8);

            #endregion

            #region R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VP1111B_t1")]
        public static void VP1111B_Tests_Theory(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VP1111B_CR_CANC_SIAS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "123456789" },
                { "PROPOVA_TIMESTAMP" , "2023-12-15T12:34:56Z" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_SIAS");
AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_SIAS", q0);

                #endregion

                #region VP1111B_CR_CANC_EFP

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
                { "EF150_NUM_CONTRATO_SEGUR" , "CONTR1234567" },
                { "EF150_NOM_ARQUIVO" , "MovimentoSAP20231215.csv" },
                { "EF150_NUM_CONTR_TERC" , "TERC9876543" },
                { "EF150_NUM_APOLICE" , "APOL123456789" },
                { "EF150_COD_PRODUTO" , "PROD321" },
                { "EF050_DTH_FIM_VIGENCIA" , "2024-12-31T23:59:59Z" },
                { "EF150_DTH_ATUALIZACAO" , "2023-12-15T12:00:00Z" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_EFP");
AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_EFP", q1);

                #endregion

                #region VP1111B_CR_CANC_ARQ

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , "CONTR0641234" },
                { "WS_DATA_CANCEL" , "2023-12-20T00:00:00Z" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_ARQ");
AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_ARQ", q2);

                #endregion

                #region R10000_INICIALIZA_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01T00:00:00Z" }
            });
            AppSettings.TestSet.DynamicData.Remove("R10000_INICIALIZA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R10000_INICIALIZA_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_INI" , "2023-12-01T00:00:00Z" },
                { "WS_DT_FIM" , "2023-12-31T23:59:59Z" },
            });
            AppSettings.TestSet.DynamicData.Remove("R10000_INICIALIZA_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_2_Query1", q4);

                #endregion

                #region R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "123456789" }
            });
            AppSettings.TestSet.DynamicData.Remove("R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "EF158_NUM_PROPOSTA" , "158123456789" }
            });
            AppSettings.TestSet.DynamicData.Remove("R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTRATO_SEGUR" , "CONTR1234567" },
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
            });
            AppSettings.TestSet.DynamicData.Remove("R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTR_TERC" , "TERC9876543" }
            });
            AppSettings.TestSet.DynamicData.Remove("R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1", q8);

                #endregion

                #region R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , "CONTR0641234" }
            });
            AppSettings.TestSet.DynamicData.Remove("R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP1111B();
                program.Execute(ARQSAIDA_FILE_NAME_P);

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
        [InlineData("VP1111B_t2")]
        public static void VP1111B_Tests_Return99(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VP1111B_CR_CANC_SIAS

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
 
            });
                AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_SIAS");
                AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_SIAS", q0);

                #endregion

                #region VP1111B_CR_CANC_EFP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
                { "EF150_NUM_CONTRATO_SEGUR" , "CONTR1234567" },
                { "EF150_NOM_ARQUIVO" , "MovimentoSAP20231215.csv" },
                { "EF150_NUM_CONTR_TERC" , "TERC9876543" },
                { "EF150_NUM_APOLICE" , "APOL123456789" },
                { "EF150_COD_PRODUTO" , "PROD321" },
                { "EF050_DTH_FIM_VIGENCIA" , "2024-12-31T23:59:59Z" },
                { "EF150_DTH_ATUALIZACAO" , "2023-12-15T12:00:00Z" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_EFP");
                AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_EFP", q1);

                #endregion

                #region VP1111B_CR_CANC_ARQ

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , "CONTR0641234" },
                { "WS_DATA_CANCEL" , "2023-12-20T00:00:00Z" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP1111B_CR_CANC_ARQ");
                AppSettings.TestSet.DynamicData.Add("VP1111B_CR_CANC_ARQ", q2);

                #endregion

                #region R10000_INICIALIZA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01T00:00:00Z" }
            });
                AppSettings.TestSet.DynamicData.Remove("R10000_INICIALIZA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R10000_INICIALIZA_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_INI" , "2023-12-01T00:00:00Z" },
                { "WS_DT_FIM" , "2023-12-31T23:59:59Z" },
            });
                AppSettings.TestSet.DynamicData.Remove("R10000_INICIALIZA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R10000_INICIALIZA_DB_SELECT_2_Query1", q4);

                #endregion

                #region R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "123456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "EF158_NUM_PROPOSTA" , "158123456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTRATO_SEGUR" , "CONTR1234567" },
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_CONTR_TERC" , "TERC9876543" }
            });
                AppSettings.TestSet.DynamicData.Remove("R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1", q8);

                #endregion

                #region R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "EF064_NUM_CONTRATO" , "CONTR0641234" }
            });
                AppSettings.TestSet.DynamicData.Remove("R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP1111B();
                program.Execute(ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}