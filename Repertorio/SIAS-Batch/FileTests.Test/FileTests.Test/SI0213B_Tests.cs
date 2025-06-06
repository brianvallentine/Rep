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
using static Code.SI0213B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0213B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0213B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DATA_CORRENTE" , ""},
                { "HOST_DIA_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_DATA_SISTEMA_MENOS_60DIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_PROX_DIA_UTIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_PENULT_DIA_MES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0300_00_LE_EMPRESAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LE_EMPRESAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_ANTES_DE_05_E_20" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0600_00_LE_RELATORI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT_REPASSE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0700_00_LE_CALENDAR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_LE_CALENDAR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1", q8);

            #endregion

            #region SI0213B_C01_SINISHIS

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_TIPO_PESSOA" , ""},
                { "FORNECED_COD_BANCO" , ""},
                { "FORNECED_COD_AGENCIA" , ""},
                { "FORNECED_NUM_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0213B_C01_SINISHIS", q9);

            #endregion

            #region SI0213B_SINISHIS2

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_TIPO_PESSOA" , ""},
                { "FORNECED_COD_BANCO" , ""},
                { "FORNECED_COD_AGENCIA" , ""},
                { "FORNECED_NUM_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0213B_SINISHIS2", q10);

            #endregion

            #region R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOCF_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "FIPADOFI_IDTAB_FORNECEDOR" , ""},
                { "FIPADOFI_COD_CH1_FORNECEDOR" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "FIPADOFI_IDTAB_DOC_FISCAL" , ""},
                { "FIPADOFI_COD_CH1_DOC_FISCAL" , ""},
                { "FIPADOFI_COD_FONTE_LANC" , ""},
                { "FIPADOFI_TIPO_MOVIMENTO" , ""},
                { "FIPADOFI_COD_EMPRESA" , ""},
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINNUMLO_NUM_LOTE" , ""},
                { "SINNUMLO_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINNUMLO_COD_FONTE" , ""},
                { "SINNUMLO_NUM_LOTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SINNUMLO_NUM_LOTE" , ""},
                { "SINNUMLO_COD_FONTE" , ""},
                { "SINNUMLO_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SINNUMLO_COD_FONTE" , ""},
                { "SINNUMLO_NUM_LOTE" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISCAP_QTD_LANCAMENTO" , ""},
                { "SINISCAP_VAL_TOT_LANCA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISCAP_DT_LIBERA_PAGTO" , ""},
                { "SINISCAP_DT_PAGAMENTO" , ""},
                { "SINISCAP_SITUACAO_LOTE" , ""},
                { "SINISCAP_COD_USUARIO" , ""},
                { "SINISCAP_NOME_DEPTO" , ""},
                { "SINISCAP_COD_FONTE_DEST" , ""},
                { "SINISCAP_IDTAB" , ""},
                { "SINISCAP_CODIGO_CH1" , ""},
                { "FIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "SINISCAP_COD_SISTEMA_ORIGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISCAP_QTD_LANCAMENTO" , ""},
                { "SINISCAP_VAL_TOT_LANCA" , ""},
                { "SINNUMLO_COD_FONTE" , ""},
                { "SINNUMLO_NUM_LOTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R2100_00_LE_SINISHIS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_LE_SINISHIS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SINNUMLO_COD_FONTE" , ""},
                { "SINNUMLO_NUM_LOTE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R2400_00_LE_SINIITEM_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_LE_SINIITEM_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2500_00_LE_SINISHIS_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_RECEBIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_LE_SINISHIS_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2500_00_LE_SINISHIS_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_RECEBIDO_EST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_LE_SINISHIS_DB_SELECT_2_Query1", q23);

            #endregion

            #region R2600_00_LE_SINCREIN_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_LE_SINCREIN_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1", q25);

            #endregion

            #region R4500_00_LE_SINISHIS_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_RECEBIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_LE_SINISHIS_DB_SELECT_1_Query1", q26);

            #endregion

            #region R4500_00_LE_SINISHIS_DB_SELECT_2_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_RECEBIDO_EST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_LE_SINISHIS_DB_SELECT_2_Query1", q27);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_SI0213")]
        public static void SI0213B_Tests_Theory(string SI0213B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0213B1_FILE_NAME_P = $"{SI0213B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI0213B();
                program.Execute(SI0213B1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                //verifica se o arquivo existe e se o arquivo tem tamanho ( algo dentro )
                Assert.True(File.Exists(program.SI0213B1.FilePath));
                Assert.True(new FileInfo(program.SI0213B1.FilePath)?.Length > 0);

                //verifica se o insert ou update foi realizado
                var envList = AppSettings.TestSet.DynamicData["R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("FIPADOFI_IDTAB_FORNECEDOR", out var valOr) && valOr == "0007");
                Assert.True(envList[1].TryGetValue("FIPADOFI_COD_CH1_FORNECEDOR", out var valSivpf) && valSivpf == "4");

                //R1220_00_INCLUI_SINNUMLO_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("SINNUMLO_COD_FONTE", out var valO2) && valO2 == "0010");
                Assert.True(envList1[1].TryGetValue("SINNUMLO_NUM_LOTE", out var va3f) && va3f == "000000001");

                //R1240_00_INCLUI_SINISCAP_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("SINNUMLO_COD_FONTE", out var val42) && val42 == "0010");
                Assert.True(envList2[1].TryGetValue("SINISCAP_COD_USUARIO", out var val5r) && val5r == "SI0213B ");

                //R1300_00_ALTERA_SINISCAP_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("SINNUMLO_COD_FONTE", out var val62) && val62 == "0010");
                Assert.True(envList3[1].TryGetValue("SINNUMLO_NUM_LOTE", out var val7r) && val7r == "000000001");

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("Saida_SI0213")]
        public static void SI0213B_Tests_TheoryErro99(string SI0213B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0213B1_FILE_NAME_P = $"{SI0213B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_LE_SISTEMAS_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0213B();
                program.Execute(SI0213B1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}