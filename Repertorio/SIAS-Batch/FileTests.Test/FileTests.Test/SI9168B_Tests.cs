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
using static Code.SI9168B;

namespace FileTests.Test
{
    [Collection("SI9168B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI9168B_Tests
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
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARVRCZ_TIPO_REGISTRO" , ""},
                { "SIARVRCZ_SEQ_REGISTRO" , ""},
                { "SIARVRCZ_STA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

            #endregion
            
            #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region SI9168B_C01_SIARDEVC

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_DATA_COMUNICADO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_HORA_OCORRENCIA" , ""},
                { "SIARDEVC_DATA_MOVIMENTO" , ""},
                { "SIARDEVC_IND_FAVORECIDO" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_VAL_PECAS" , ""},
                { "SIARDEVC_VAL_MAO_OBRA" , ""},
                { "SIARDEVC_VAL_PARCELA_PEND" , ""},
                { "SIARDEVC_QTD_PARCELA_PEND" , ""},
                { "SIARDEVC_VAL_DESC_PARC_PEND" , ""},
                { "SIARDEVC_DATA_NEGOCIADA" , ""},
                { "SIARDEVC_VAL_IRF" , ""},
                { "SIARDEVC_VAL_ISS" , ""},
                { "SIARDEVC_VAL_INSS" , ""},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , ""},
                { "SIARDEVC_CGCCPF" , ""},
                { "SIARDEVC_TIPO_PESSOA" , ""},
                { "SIARDEVC_NOM_FAVORECIDO" , ""},
                { "SIARDEVC_IND_DOC_FISCAL" , ""},
                { "SIARDEVC_NUM_DOC_FISCAL" , ""},
                { "SIARDEVC_SERIE_DOC_FISCAL" , ""},
                { "SIARDEVC_DATA_EMISSAO" , ""},
                { "SIARDEVC_DES_ENDERECO" , ""},
                { "SIARDEVC_NOM_BAIRRO" , ""},
                { "SIARDEVC_NOM_CIDADE" , ""},
                { "SIARDEVC_COD_UF" , ""},
                { "SIARDEVC_NUM_CEP" , ""},
                { "SIARDEVC_NUM_DDD" , ""},
                { "SIARDEVC_NUM_TELEFONE" , ""},
                { "SIARDEVC_IND_FORMA_PAGTO" , ""},
                { "SIARDEVC_NUM_IDENTIFICADOR" , ""},
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO" , ""},
                { "SIARDEVC_COD_BANCO" , ""},
                { "SIARDEVC_COD_AGENCIA" , ""},
                { "SIARDEVC_OPERACAO_CONTA" , ""},
                { "SIARDEVC_COD_CONTA" , ""},
                { "SIARDEVC_DV_CONTA" , ""},
                { "SIARDEVC_COD_FAVORECIDO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_COD_ERRO" , ""},
                { "SIARDEVC_VAL_PISPASEP" , ""},
                { "SIARDEVC_VAL_COFINS" , ""},
                { "SIARDEVC_VAL_CSLL" , ""},
                { "SIARDEVC_COD_FONTE" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SIARDEVC_NUM_RESSARC" , ""},
                { "SIARDEVC_IND_PESSOA_ACORDO" , ""},
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , ""},
                { "SIARDEVC_NOM_RESP_ACORDO" , ""},
                { "SIARDEVC_STA_ACORDO" , ""},
                { "SIARDEVC_DTH_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_PART_TERCEIROS" , ""},
                { "SIARDEVC_VLR_DIVIDA" , ""},
                { "SIARDEVC_PCT_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_ACORDO" , ""},
                { "SIARDEVC_COD_MOEDA_ACORDO" , ""},
                { "SIARDEVC_DTH_ACORDO" , ""},
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , ""},
                { "SIARDEVC_NUM_PARCELA_ACORDO" , ""},
                { "SIARDEVC_COD_AGENCIA_CEDENT" , ""},
                { "SIARDEVC_NUM_CEDENTE" , ""},
                { "SIARDEVC_NUM_CEDENTE_DV" , ""},
                { "SIARDEVC_DTH_VENCIMENTO" , ""},
                { "SIARDEVC_NUM_NOSSO_TITULO" , ""},
                { "SIARDEVC_VLR_TITULO" , ""},
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , ""},
                { "SIARDEVC_NOM_RECLAMANTE" , ""},
                { "SIARDEVC_VLR_RECLAMADO" , ""},
                { "SIARDEVC_VLR_PROVISIONADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9168B_C01_SIARDEVC", q5);

            #endregion

            #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1210_00_LE_SINISMES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARREVC_TIPO_REGISTRO_VC" , ""},
                { "SIARREVC_SEQ_REGISTRO_VC" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI9168B_t1")]
        public static void SI9168B_Tests_Theory(string CVPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CVPAGSIN_FILE_NAME_P = $"{CVPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "HOST_ANO_MOV_ABERTO" , "2000"},
                { "HOST_MES_MOV_ABERTO" , "01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9168B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "SI9168B"},
                { "SIARDEVC_SEQ_GERACAO" , "001"},
                { "SIARDEVC_TIPO_REGISTRO" , "1"},
                { "SIARDEVC_SEQ_REGISTRO" , "000001"},
                { "SIARDEVC_COD_OPERACAO" , "OP123"},
                { "SIARDEVC_OCORR_HISTORICO" , "0"},
                { "SIARDEVC_NUM_SINISTRO_VC" , "123"},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "876"},
                { "SIARDEVC_NUM_APOLICE" , "2"},
                { "SIARDEVC_NUM_ENDOSSO" , "001"},
                { "SIARDEVC_NUM_ITEM" , "01"},
                { "SIARDEVC_COD_RAMO" , "01"},
                { "SIARDEVC_COD_COBERTURA" , "101"},
                { "SIARDEVC_COD_CAUSA" , "001"},
                { "SIARDEVC_DATA_COMUNICADO" , "2025-04-01"},
                { "SIARDEVC_DATA_OCORRENCIA" , "2025-03-28"},
                { "SIARDEVC_HORA_OCORRENCIA" , "140"},
                { "SIARDEVC_DATA_MOVIMENTO" , "2025-04-02"},
                { "SIARDEVC_IND_FAVORECIDO" , "1"},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "1500.50"},
                { "SIARDEVC_VAL_PECAS" , "500.00"},
                { "SIARDEVC_VAL_MAO_OBRA" , "700.00"},
                { "SIARDEVC_VAL_PARCELA_PEND" , "300.50"},
                { "SIARDEVC_QTD_PARCELA_PEND" , "2"},
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "50.00"},
                { "SIARDEVC_DATA_NEGOCIADA" , "2025-04-03"},
                { "SIARDEVC_VAL_IRF" , "15.00"},
                { "SIARDEVC_VAL_ISS" , "30.00"},
                { "SIARDEVC_VAL_INSS" , "25.00"},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "1430.50"},
                { "SIARDEVC_CGCCPF" , "12345678901"},
                { "SIARDEVC_TIPO_PESSOA" , "F"},
                { "SIARDEVC_NOM_FAVORECIDO" , "JOAO DA SILVA"},
                { "SIARDEVC_IND_DOC_FISCAL" , "S-0"},
                { "SIARDEVC_NUM_DOC_FISCAL" , "56"},
                { "SIARDEVC_SERIE_DOC_FISCAL" , "A1"},
                { "SIARDEVC_DATA_EMISSAO" , "20250401"},
                { "SIARDEVC_DES_ENDERECO" , "Rua Exemplo, 123"},
                { "SIARDEVC_NOM_BAIRRO" , "Centro"},
                { "SIARDEVC_NOM_CIDADE" , "São Paulo"},
                { "SIARDEVC_COD_UF" , "SP"},
                { "SIARDEVC_NUM_CEP" , "01000000"},
                { "SIARDEVC_NUM_DDD" , "11"},
                { "SIARDEVC_NUM_TELEFONE" , "999999999"},
                { "SIARDEVC_IND_FORMA_PAGTO" , "T"},
                { "SIARDEVC_NUM_IDENTIFICADOR" , "1"},
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "2"},
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "1"},
                { "SIARDEVC_ORDEM_PAGAMENTO" , "1"},
                { "SIARDEVC_COD_BANCO" , "001"},
                { "SIARDEVC_COD_AGENCIA" , "1234"},
                { "SIARDEVC_OPERACAO_CONTA" , "001"},
                { "SIARDEVC_COD_CONTA" , "1234"},
                { "SIARDEVC_DV_CONTA" , "9"},
                { "SIARDEVC_COD_FAVORECIDO" , "01"},
                { "SIARDEVC_NUM_APOL_SINISTRO" , "67"},
                { "SIARDEVC_STA_PROCESSAMENTO" , "P"},
                { "SIARDEVC_COD_ERRO" , "000"},
                { "SIARDEVC_VAL_PISPASEP" , "5.00"},
                { "SIARDEVC_VAL_COFINS" , "7.00"},
                { "SIARDEVC_VAL_CSLL" , "3.50"},
                { "SIARDEVC_COD_FONTE" , "C1"},
                { "SINISHIS_COD_OPERACAO" , "OP789"},
                { "SINISHIS_OCORR_HISTORICO" , "Laudo emitido"},
                { "SIARDEVC_NUM_RESSARC" , "RS1234"},
                { "SIARDEVC_IND_PESSOA_ACORDO" , "S"},
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "980"},
                { "SIARDEVC_NOM_RESP_ACORDO" , "MARIA OLIVEIRA"},
                { "SIARDEVC_STA_ACORDO" , "F"},
                { "SIARDEVC_DTH_INDENIZACAO" , "2025-04-04"},
                { "SIARDEVC_VLR_INDENIZACAO" , "1200.00"},
                { "SIARDEVC_VLR_PART_TERCEIROS" , "300.00"},
                { "SIARDEVC_VLR_DIVIDA" , "100.00"},
                { "SIARDEVC_PCT_DESCONTO" , "10.00"},
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "120.00"},
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "1080.00"},
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL"},
                { "SIARDEVC_DTH_ACORDO" , "2025-04-05"},
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "3"},
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1"},
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "43"},
                { "SIARDEVC_NUM_CEDENTE" , "99"},
                { "SIARDEVC_NUM_CEDENTE_DV" , "2"},
                { "SIARDEVC_DTH_VENCIMENTO" , "2025-04-30"},
                { "SIARDEVC_NUM_NOSSO_TITULO" , "54"},
                { "SIARDEVC_VLR_TITULO" , "1500.00"},
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "156"},
                { "SIARDEVC_NOM_RECLAMANTE" , "CARLOS PEREIRA"},
                { "SIARDEVC_VLR_RECLAMADO" , "200.00"},
                { "SIARDEVC_VLR_PROVISIONADO" , "180.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI9168B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9168B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "x"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1210_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "0"},
                { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

               #endregion

                var program = new SI9168B();
                program.Execute(CVPAGSIN_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1              

                var envList1 = AppSettings.TestSet.DynamicData["R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var GEARDETA_NOM_ARQUIVO) && GEARDETA_NOM_ARQUIVO == "CVPAGSIN");
                Assert.True(envList1[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var GEARDETA_SEQ_GERACAO) && GEARDETA_SEQ_GERACAO == "000000001");
                Assert.True(envList1[1].TryGetValue("HOST_ANO_MOV_ABERTO", out var HOST_ANO_MOV_ABERTO) && HOST_ANO_MOV_ABERTO == "2000");
                Assert.True(envList1[1].TryGetValue("HOST_MES_MOV_ABERTO", out var HOST_MES_MOV_ABERTO) && HOST_MES_MOV_ABERTO == "0001");
                Assert.True(envList1[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2020-01-01");
                Assert.True(envList1[1].TryGetValue("GEARDETA_QTD_REG_PROCESSADO", out var GEARDETA_QTD_REG_PROCESSADO) && GEARDETA_QTD_REG_PROCESSADO == "000000000");

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                 var envList2 = AppSettings.TestSet.DynamicData["R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1"].DynamicList;
                 Assert.True(envList2?.Count > 1);
                 Assert.True(envList2[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var GEARDETA_NOM_ARQUIVO1) && GEARDETA_NOM_ARQUIVO1 == "CVPAGSIN");
                 Assert.True(envList2[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var GEARDETA_SEQ_GERACAO1) && GEARDETA_SEQ_GERACAO1 == "000000001");
                 Assert.True(envList2[1].TryGetValue("SIARVRCZ_TIPO_REGISTRO", out var SIARVRCZ_TIPO_REGISTRO) && SIARVRCZ_TIPO_REGISTRO == "1");
                 Assert.True(envList2[1].TryGetValue("SIARVRCZ_SEQ_REGISTRO", out var SIARVRCZ_SEQ_REGISTRO) && SIARVRCZ_SEQ_REGISTRO == "000000001");

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1
             
                var envList3 = AppSettings.TestSet.DynamicData["R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("GEARDETA_QTD_REG_PROCESSADO", out var GEARDETA_QTD_REG_PROCESSADO1) && GEARDETA_QTD_REG_PROCESSADO1 == "000000003");
                Assert.True(envList3[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var GEARDETA_NOM_ARQUIVO2) && GEARDETA_NOM_ARQUIVO1 == "CVPAGSIN");
                Assert.True(envList3[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var GEARDETA_SEQ_GERACAO2) && GEARDETA_SEQ_GERACAO1 == "000000001");

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1             

                var envList4 = AppSettings.TestSet.DynamicData["R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var GEARDETA_NOM_ARQUIVO3) && GEARDETA_NOM_ARQUIVO3 == "CVPAGSIN");
                Assert.True(envList4[1].TryGetValue("GEARDETA_SEQ_GERACAO", out var GEARDETA_SEQ_GERACAO3) && GEARDETA_SEQ_GERACAO3 == "000000001");
                Assert.True(envList4[1].TryGetValue("SIARREVC_TIPO_REGISTRO_VC", out var SIARREVC_TIPO_REGISTRO_VC) && SIARREVC_TIPO_REGISTRO_VC == "2");
                Assert.True(envList4[1].TryGetValue("SIARREVC_SEQ_REGISTRO_VC", out var SIARREVC_SEQ_REGISTRO_VC) && SIARREVC_SEQ_REGISTRO_VC == "000000002");
                Assert.True(envList4[1].TryGetValue("SIARDEVC_NOM_ARQUIVO", out var SIARDEVC_NOM_ARQUIVO) && SIARDEVC_NOM_ARQUIVO == "SI9168B ");
                Assert.True(envList4[1].TryGetValue("SIARDEVC_SEQ_GERACAO", out var SIARDEVC_SEQ_GERACAO) && SIARDEVC_SEQ_GERACAO == "000000001");
                Assert.True(envList4[1].TryGetValue("SIARDEVC_TIPO_REGISTRO", out var SIARDEVC_TIPO_REGISTRO) && SIARDEVC_TIPO_REGISTRO == "1");
                Assert.True(envList4[1].TryGetValue("SIARDEVC_SEQ_REGISTRO", out var SIARDEVC_SEQ_REGISTRO) && SIARDEVC_SEQ_REGISTRO == "000000001");

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1
               
                var envList5 = AppSettings.TestSet.DynamicData["R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("SINISHIS_OCORR_HISTORICO", out var SINISHIS_OCORR_HISTORICO) && SINISHIS_OCORR_HISTORICO == "0000");
                Assert.True(envList5[1].TryGetValue("SIARDEVC_TIPO_REGISTRO", out var SIARDEVC_TIPO_REGISTRO5) && SIARDEVC_TIPO_REGISTRO5 == "1");
                Assert.True(envList5[1].TryGetValue("SIARDEVC_SEQ_REGISTRO", out var SIARDEVC_SEQ_REGISTRO5) && SIARDEVC_SEQ_REGISTRO5 == "000000001");
                Assert.True(envList5[1].TryGetValue("SIARDEVC_NOM_ARQUIVO", out var SIARDEVC_NOM_ARQUIVO5) && SIARDEVC_NOM_ARQUIVO5 == "SI9168B ");
                Assert.True(envList5[1].TryGetValue("SIARDEVC_SEQ_GERACAO", out var SIARDEVC_SEQ_GERACAO5) && SIARDEVC_SEQ_GERACAO5 == "000000001");

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("SI9168B_t2")]
        public static void SI9168B_Tests99_Theory(string CVPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CVPAGSIN_FILE_NAME_P = $"{CVPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9168B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "SI9168B"},
                { "SIARDEVC_SEQ_GERACAO" , "001"},
                { "SIARDEVC_TIPO_REGISTRO" , "1"},
                { "SIARDEVC_SEQ_REGISTRO" , "000001"},
                { "SIARDEVC_COD_OPERACAO" , "OP123"},
                { "SIARDEVC_OCORR_HISTORICO" , "0"},
                { "SIARDEVC_NUM_SINISTRO_VC" , "123"},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "876"},
                { "SIARDEVC_NUM_APOLICE" , "2"},
                { "SIARDEVC_NUM_ENDOSSO" , "001"},
                { "SIARDEVC_NUM_ITEM" , "01"},
                { "SIARDEVC_COD_RAMO" , "01"},
                { "SIARDEVC_COD_COBERTURA" , "101"},
                { "SIARDEVC_COD_CAUSA" , "001"},
                { "SIARDEVC_DATA_COMUNICADO" , "2025-04-01"},
                { "SIARDEVC_DATA_OCORRENCIA" , "2025-03-28"},
                { "SIARDEVC_HORA_OCORRENCIA" , "140"},
                { "SIARDEVC_DATA_MOVIMENTO" , "2025-04-02"},
                { "SIARDEVC_IND_FAVORECIDO" , "1"},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "1500.50"},
                { "SIARDEVC_VAL_PECAS" , "500.00"},
                { "SIARDEVC_VAL_MAO_OBRA" , "700.00"},
                { "SIARDEVC_VAL_PARCELA_PEND" , "300.50"},
                { "SIARDEVC_QTD_PARCELA_PEND" , "2"},
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "50.00"},
                { "SIARDEVC_DATA_NEGOCIADA" , "2025-04-03"},
                { "SIARDEVC_VAL_IRF" , "15.00"},
                { "SIARDEVC_VAL_ISS" , "30.00"},
                { "SIARDEVC_VAL_INSS" , "25.00"},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "1430.50"},
                { "SIARDEVC_CGCCPF" , "12345678901"},
                { "SIARDEVC_TIPO_PESSOA" , "F"},
                { "SIARDEVC_NOM_FAVORECIDO" , "JOAO DA SILVA"},
                { "SIARDEVC_IND_DOC_FISCAL" , "S-0"},
                { "SIARDEVC_NUM_DOC_FISCAL" , "56"},
                { "SIARDEVC_SERIE_DOC_FISCAL" , "A1"},
                { "SIARDEVC_DATA_EMISSAO" , "20250401"},
                { "SIARDEVC_DES_ENDERECO" , "Rua Exemplo, 123"},
                { "SIARDEVC_NOM_BAIRRO" , "Centro"},
                { "SIARDEVC_NOM_CIDADE" , "São Paulo"},
                { "SIARDEVC_COD_UF" , "SP"},
                { "SIARDEVC_NUM_CEP" , "01000000"},
                { "SIARDEVC_NUM_DDD" , "11"},
                { "SIARDEVC_NUM_TELEFONE" , "999999999"},
                { "SIARDEVC_IND_FORMA_PAGTO" , "T"},
                { "SIARDEVC_NUM_IDENTIFICADOR" , "1"},
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "2"},
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "1"},
                { "SIARDEVC_ORDEM_PAGAMENTO" , "1"},
                { "SIARDEVC_COD_BANCO" , "001"},
                { "SIARDEVC_COD_AGENCIA" , "1234"},
                { "SIARDEVC_OPERACAO_CONTA" , "001"},
                { "SIARDEVC_COD_CONTA" , "1234"},
                { "SIARDEVC_DV_CONTA" , "9"},
                { "SIARDEVC_COD_FAVORECIDO" , "01"},
                { "SIARDEVC_NUM_APOL_SINISTRO" , "67"},
                { "SIARDEVC_STA_PROCESSAMENTO" , "P"},
                { "SIARDEVC_COD_ERRO" , "000"},
                { "SIARDEVC_VAL_PISPASEP" , "5.00"},
                { "SIARDEVC_VAL_COFINS" , "7.00"},
                { "SIARDEVC_VAL_CSLL" , "3.50"},
                { "SIARDEVC_COD_FONTE" , "C1"},
                { "SINISHIS_COD_OPERACAO" , "OP789"},
                { "SINISHIS_OCORR_HISTORICO" , "Laudo emitido"},
                { "SIARDEVC_NUM_RESSARC" , "RS1234"},
                { "SIARDEVC_IND_PESSOA_ACORDO" , "S"},
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "980"},
                { "SIARDEVC_NOM_RESP_ACORDO" , "MARIA OLIVEIRA"},
                { "SIARDEVC_STA_ACORDO" , "F"},
                { "SIARDEVC_DTH_INDENIZACAO" , "2025-04-04"},
                { "SIARDEVC_VLR_INDENIZACAO" , "1200.00"},
                { "SIARDEVC_VLR_PART_TERCEIROS" , "300.00"},
                { "SIARDEVC_VLR_DIVIDA" , "100.00"},
                { "SIARDEVC_PCT_DESCONTO" , "10.00"},
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "120.00"},
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "1080.00"},
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL"},
                { "SIARDEVC_DTH_ACORDO" , "2025-04-05"},
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "3"},
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1"},
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "43"},
                { "SIARDEVC_NUM_CEDENTE" , "99"},
                { "SIARDEVC_NUM_CEDENTE_DV" , "2"},
                { "SIARDEVC_DTH_VENCIMENTO" , "2025-04-30"},
                { "SIARDEVC_NUM_NOSSO_TITULO" , "54"},
                { "SIARDEVC_VLR_TITULO" , "1500.00"},
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "156"},
                { "SIARDEVC_NOM_RECLAMANTE" , "CARLOS PEREIRA"},
                { "SIARDEVC_VLR_RECLAMADO" , "200.00"},
                { "SIARDEVC_VLR_PROVISIONADO" , "180.00"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI9168B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9168B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "x"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1210_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

                var program = new SI9168B();
                program.Execute(CVPAGSIN_FILE_NAME_P);
             

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}