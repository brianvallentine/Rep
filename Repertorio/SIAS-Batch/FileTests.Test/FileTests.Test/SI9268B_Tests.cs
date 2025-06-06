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
using static Code.SI9268B;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI9268B_Tests")]
    public class SI9268B_Tests
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

            #region SI9268B_C01_SIARDEVC

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
                { "SIARDEVC_NUM_SINISTRO_CONV" , ""},
                { "SIARDEVC_NUM_IDENT_CONV" , ""},
                { "SIARDEVC_NUM_IDE_COBR_CONV" , ""},
                { "SIARDEVC_COD_CFOP" , ""},
                { "SIARDEVC_COD_CEST" , ""},
                { "SIARDEVC_NUM_INSCR_ESTADUAL" , ""},
                { "SIARDEVC_NUM_NCM" , ""},
                { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , ""},
                { "SIARDEVC_IND_ISENCAO_TRIBUTO" , ""},
                { "SIARDEVC_COD_IMPOSTO_LIMINAR" , ""},
                { "SIARDEVC_COD_PROCESSO_ISENCAO" , ""},
                { "SIARDEVC_VLR_RET_N_EFETUADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9268B_C01_SIARDEVC", q5);

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
        [InlineData("SI9268B_t1")]
        public static void SI9268B_Tests_Theory(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0350S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"},
                    { "HOST_ANO_MOV_ABERTO" , "2025"},
                    { "HOST_MES_MOV_ABERTO" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_SEQ_GERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                    { "HOST_ANO_MOV_ABERTO" , "2025"},
                    { "HOST_MES_MOV_ABERTO" , "12"},
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                    { "GEARDETA_QTD_REG_PROCESSADO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                    { "SIARVRCZ_TIPO_REGISTRO" , "1"},
                    { "SIARVRCZ_SEQ_REGISTRO" , "1"},
                    { "SIARVRCZ_STA_PROCESSAMENTO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_QTD_REG_PROCESSADO" , "1"},
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9268B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIARDEVC_NOM_ARQUIVO" , "1"},
                    { "SIARDEVC_SEQ_GERACAO" , "1"},
                    { "SIARDEVC_TIPO_REGISTRO" , "1"},
                    { "SIARDEVC_SEQ_REGISTRO" , "1"},
                    { "SIARDEVC_COD_OPERACAO" , "1"},
                    { "SIARDEVC_OCORR_HISTORICO" , "1"},
                    { "SIARDEVC_NUM_SINISTRO_VC" , "1"},
                    { "SIARDEVC_NUM_EXPEDIENTE_VC" , "1"},
                    { "SIARDEVC_NUM_APOLICE" , "1"},
                    { "SIARDEVC_NUM_ENDOSSO" , "1"},
                    { "SIARDEVC_NUM_ITEM" , "1"},
                    { "SIARDEVC_COD_RAMO" , "1"},
                    { "SIARDEVC_COD_COBERTURA" , "1"},
                    { "SIARDEVC_COD_CAUSA" , "1"},
                    { "SIARDEVC_DATA_COMUNICADO" , "2024-01-01"},
                    { "SIARDEVC_DATA_OCORRENCIA" , "2024-01-01"},
                    { "SIARDEVC_HORA_OCORRENCIA" , "12:00"},
                    { "SIARDEVC_DATA_MOVIMENTO" , "2024-01-01"},
                    { "SIARDEVC_IND_FAVORECIDO" , "1"},
                    { "SIARDEVC_VAL_TOT_MOVIMENTO" , "1"},
                    { "SIARDEVC_VAL_PECAS" , "1"},
                    { "SIARDEVC_VAL_MAO_OBRA" , "1"},
                    { "SIARDEVC_VAL_PARCELA_PEND" , "1"},
                    { "SIARDEVC_QTD_PARCELA_PEND" , "1"},
                    { "SIARDEVC_VAL_DESC_PARC_PEND" , "1"},
                    { "SIARDEVC_DATA_NEGOCIADA" , "2024-01-01"},
                    { "SIARDEVC_VAL_IRF" , "1"},
                    { "SIARDEVC_VAL_ISS" , "1"},
                    { "SIARDEVC_VAL_INSS" , "1"},
                    { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "1"},
                    { "SIARDEVC_CGCCPF" , "1"},
                    { "SIARDEVC_TIPO_PESSOA" , "1"},
                    { "SIARDEVC_NOM_FAVORECIDO" , "1"},
                    { "SIARDEVC_IND_DOC_FISCAL" , "1"},
                    { "SIARDEVC_NUM_DOC_FISCAL" , "1"},
                    { "SIARDEVC_SERIE_DOC_FISCAL" , "1"},
                    { "SIARDEVC_DATA_EMISSAO" , "2024-01-01"},
                    { "SIARDEVC_DES_ENDERECO" , "1"},
                    { "SIARDEVC_NOM_BAIRRO" , "1"},
                    { "SIARDEVC_NOM_CIDADE" , "1"},
                    { "SIARDEVC_COD_UF" , "1"},
                    { "SIARDEVC_NUM_CEP" , "1"},
                    { "SIARDEVC_NUM_DDD" , "1"},
                    { "SIARDEVC_NUM_TELEFONE" , "1"},
                    { "SIARDEVC_IND_FORMA_PAGTO" , "1"},
                    { "SIARDEVC_NUM_IDENTIFICADOR" , "1"},
                    { "SIARDEVC_NUM_CHEQUE_INTERNO" , "1"},
                    { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "1"},
                    { "SIARDEVC_ORDEM_PAGAMENTO" , "1"},
                    { "SIARDEVC_COD_BANCO" , "1"},
                    { "SIARDEVC_COD_AGENCIA" , "1"},
                    { "SIARDEVC_OPERACAO_CONTA" , "1"},
                    { "SIARDEVC_COD_CONTA" , "1"},
                    { "SIARDEVC_DV_CONTA" , "1"},
                    { "SIARDEVC_COD_FAVORECIDO" , "1"},
                    { "SIARDEVC_NUM_APOL_SINISTRO" , "1"},
                    { "SIARDEVC_STA_PROCESSAMENTO" , "1"},
                    { "SIARDEVC_COD_ERRO" , "1"},
                    { "SIARDEVC_VAL_PISPASEP" , "1"},
                    { "SIARDEVC_VAL_COFINS" , "1"},
                    { "SIARDEVC_VAL_CSLL" , "1"},
                    { "SIARDEVC_COD_FONTE" , "1"},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , "1"},
                    { "SIARDEVC_NUM_RESSARC" , "1"},
                    { "SIARDEVC_IND_PESSOA_ACORDO" , "1"},
                    { "SIARDEVC_NUM_CPFCGC_ACORDO" , "1"},
                    { "SIARDEVC_NOM_RESP_ACORDO" , "1"},
                    { "SIARDEVC_STA_ACORDO" , "1"},
                    { "SIARDEVC_DTH_INDENIZACAO" , "1"},
                    { "SIARDEVC_VLR_INDENIZACAO" , "1"},
                    { "SIARDEVC_VLR_PART_TERCEIROS" , "1"},
                    { "SIARDEVC_VLR_DIVIDA" , "1"},
                    { "SIARDEVC_PCT_DESCONTO" , "1"},
                    { "SIARDEVC_VLR_TOTAL_DESCONTO" , "1"},
                    { "SIARDEVC_VLR_TOTAL_ACORDO" , "1"},
                    { "SIARDEVC_COD_MOEDA_ACORDO" , "1"},
                    { "SIARDEVC_DTH_ACORDO" , "1"},
                    { "SIARDEVC_QTD_PARCELAS_ACORDO" , "1"},
                    { "SIARDEVC_NUM_PARCELA_ACORDO" , "1"},
                    { "SIARDEVC_COD_AGENCIA_CEDENT" , "1"},
                    { "SIARDEVC_NUM_CEDENTE" , "1"},
                    { "SIARDEVC_NUM_CEDENTE_DV" , "1"},
                    { "SIARDEVC_DTH_VENCIMENTO" , "2024-01-01"},
                    { "SIARDEVC_NUM_NOSSO_TITULO" , "1"},
                    { "SIARDEVC_VLR_TITULO" , "1"},
                    { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "1"},
                    { "SIARDEVC_NOM_RECLAMANTE" , "1"},
                    { "SIARDEVC_VLR_RECLAMADO" , "1"},
                    { "SIARDEVC_VLR_PROVISIONADO" , "1"},
                    { "SIARDEVC_NUM_SINISTRO_CONV" , "1"},
                    { "SIARDEVC_NUM_IDENT_CONV" , "1"},
                    { "SIARDEVC_NUM_IDE_COBR_CONV" , "1"},
                    { "SIARDEVC_COD_CFOP" , "1"},
                    { "SIARDEVC_COD_CEST" , "1"},
                    { "SIARDEVC_NUM_INSCR_ESTADUAL" , "1"},
                    { "SIARDEVC_NUM_NCM" , "1"},
                    { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , "1"},
                    { "SIARDEVC_IND_ISENCAO_TRIBUTO" , "1"},
                    { "SIARDEVC_COD_IMPOSTO_LIMINAR" , "1"},
                    { "SIARDEVC_COD_PROCESSO_ISENCAO" , "1"},
                    { "SIARDEVC_VLR_RET_N_EFETUADO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI9268B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9268B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIERRO_DES_ERRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1210_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_COD_FONTE" , "1"},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                    { "SIARREVC_TIPO_REGISTRO_VC" , "1"},
                    { "SIARREVC_SEQ_REGISTRO_VC" , "1"},
                    { "SIARDEVC_NOM_ARQUIVO" , "1"},
                    { "SIARDEVC_SEQ_GERACAO" , "1"},
                    { "SIARDEVC_TIPO_REGISTRO" , "1"},
                    { "SIARDEVC_SEQ_REGISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_OCORR_HISTORICO" , "1"},
                    { "SIARDEVC_TIPO_REGISTRO" , "1"},
                    { "SIARDEVC_SEQ_REGISTRO" , "1"},
                    { "SIARDEVC_NOM_ARQUIVO" , "1"},
                    { "SIARDEVC_SEQ_GERACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion
                var program = new SI9268B();
                program.Execute(CSPAGSIN_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);
                
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 3,
                //"Updates": 2,
                //"Deletes": 0,
                //"Selects": 4,
                //"Cursors": 1,
                //"Procedures": 0,
                //"All": 10

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI9268B_t2")]
        public static void SI9268B_Tests_Theory_Return99(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0350S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"},
                    { "HOST_ANO_MOV_ABERTO" , "2025"},
                    { "HOST_MES_MOV_ABERTO" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_SEQ_GERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                    { "HOST_ANO_MOV_ABERTO" , "2025"},
                    { "HOST_MES_MOV_ABERTO" , "12"},
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                    { "GEARDETA_QTD_REG_PROCESSADO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9268B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIARDEVC_NOM_ARQUIVO" , "1"},
                    { "SIARDEVC_SEQ_GERACAO" , "1"},
                    { "SIARDEVC_TIPO_REGISTRO" , "1"},
                    { "SIARDEVC_SEQ_REGISTRO" , "1"},
                    { "SIARDEVC_COD_OPERACAO" , "1"},
                    { "SIARDEVC_OCORR_HISTORICO" , "1"},
                    { "SIARDEVC_NUM_SINISTRO_VC" , "1"},
                    { "SIARDEVC_NUM_EXPEDIENTE_VC" , "1"},
                    { "SIARDEVC_NUM_APOLICE" , "1"},
                    { "SIARDEVC_NUM_ENDOSSO" , "1"},
                    { "SIARDEVC_NUM_ITEM" , "1"},
                    { "SIARDEVC_COD_RAMO" , "1"},
                    { "SIARDEVC_COD_COBERTURA" , "1"},
                    { "SIARDEVC_COD_CAUSA" , "1"},
                    { "SIARDEVC_DATA_COMUNICADO" , "2024-01-01"},
                    { "SIARDEVC_DATA_OCORRENCIA" , "2024-01-01"},
                    { "SIARDEVC_HORA_OCORRENCIA" , "12:00"},
                    { "SIARDEVC_DATA_MOVIMENTO" , "2024-01-01"},
                    { "SIARDEVC_IND_FAVORECIDO" , "1"},
                    { "SIARDEVC_VAL_TOT_MOVIMENTO" , "1"},
                    { "SIARDEVC_VAL_PECAS" , "1"},
                    { "SIARDEVC_VAL_MAO_OBRA" , "1"},
                    { "SIARDEVC_VAL_PARCELA_PEND" , "1"},
                    { "SIARDEVC_QTD_PARCELA_PEND" , "1"},
                    { "SIARDEVC_VAL_DESC_PARC_PEND" , "1"},
                    { "SIARDEVC_DATA_NEGOCIADA" , "2024-01-01"},
                    { "SIARDEVC_VAL_IRF" , "1"},
                    { "SIARDEVC_VAL_ISS" , "1"},
                    { "SIARDEVC_VAL_INSS" , "1"},
                    { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "1"},
                    { "SIARDEVC_CGCCPF" , "1"},
                    { "SIARDEVC_TIPO_PESSOA" , "1"},
                    { "SIARDEVC_NOM_FAVORECIDO" , "1"},
                    { "SIARDEVC_IND_DOC_FISCAL" , "1"},
                    { "SIARDEVC_NUM_DOC_FISCAL" , "1"},
                    { "SIARDEVC_SERIE_DOC_FISCAL" , "1"},
                    { "SIARDEVC_DATA_EMISSAO" , "2024-01-01"},
                    { "SIARDEVC_DES_ENDERECO" , "1"},
                    { "SIARDEVC_NOM_BAIRRO" , "1"},
                    { "SIARDEVC_NOM_CIDADE" , "1"},
                    { "SIARDEVC_COD_UF" , "1"},
                    { "SIARDEVC_NUM_CEP" , "1"},
                    { "SIARDEVC_NUM_DDD" , "1"},
                    { "SIARDEVC_NUM_TELEFONE" , "1"},
                    { "SIARDEVC_IND_FORMA_PAGTO" , "1"},
                    { "SIARDEVC_NUM_IDENTIFICADOR" , "1"},
                    { "SIARDEVC_NUM_CHEQUE_INTERNO" , "1"},
                    { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "1"},
                    { "SIARDEVC_ORDEM_PAGAMENTO" , "1"},
                    { "SIARDEVC_COD_BANCO" , "1"},
                    { "SIARDEVC_COD_AGENCIA" , "1"},
                    { "SIARDEVC_OPERACAO_CONTA" , "1"},
                    { "SIARDEVC_COD_CONTA" , "1"},
                    { "SIARDEVC_DV_CONTA" , "1"},
                    { "SIARDEVC_COD_FAVORECIDO" , "1"},
                    { "SIARDEVC_NUM_APOL_SINISTRO" , "1"},
                    { "SIARDEVC_STA_PROCESSAMENTO" , "1"},
                    { "SIARDEVC_COD_ERRO" , "1"},
                    { "SIARDEVC_VAL_PISPASEP" , "1"},
                    { "SIARDEVC_VAL_COFINS" , "1"},
                    { "SIARDEVC_VAL_CSLL" , "1"},
                    { "SIARDEVC_COD_FONTE" , "1"},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , "1"},
                    { "SIARDEVC_NUM_RESSARC" , "1"},
                    { "SIARDEVC_IND_PESSOA_ACORDO" , "1"},
                    { "SIARDEVC_NUM_CPFCGC_ACORDO" , "1"},
                    { "SIARDEVC_NOM_RESP_ACORDO" , "1"},
                    { "SIARDEVC_STA_ACORDO" , "1"},
                    { "SIARDEVC_DTH_INDENIZACAO" , "1"},
                    { "SIARDEVC_VLR_INDENIZACAO" , "1"},
                    { "SIARDEVC_VLR_PART_TERCEIROS" , "1"},
                    { "SIARDEVC_VLR_DIVIDA" , "1"},
                    { "SIARDEVC_PCT_DESCONTO" , "1"},
                    { "SIARDEVC_VLR_TOTAL_DESCONTO" , "1"},
                    { "SIARDEVC_VLR_TOTAL_ACORDO" , "1"},
                    { "SIARDEVC_COD_MOEDA_ACORDO" , "1"},
                    { "SIARDEVC_DTH_ACORDO" , "1"},
                    { "SIARDEVC_QTD_PARCELAS_ACORDO" , "1"},
                    { "SIARDEVC_NUM_PARCELA_ACORDO" , "1"},
                    { "SIARDEVC_COD_AGENCIA_CEDENT" , "1"},
                    { "SIARDEVC_NUM_CEDENTE" , "1"},
                    { "SIARDEVC_NUM_CEDENTE_DV" , "1"},
                    { "SIARDEVC_DTH_VENCIMENTO" , "2024-01-01"},
                    { "SIARDEVC_NUM_NOSSO_TITULO" , "1"},
                    { "SIARDEVC_VLR_TITULO" , "1"},
                    { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "1"},
                    { "SIARDEVC_NOM_RECLAMANTE" , "1"},
                    { "SIARDEVC_VLR_RECLAMADO" , "1"},
                    { "SIARDEVC_VLR_PROVISIONADO" , "1"},
                    { "SIARDEVC_NUM_SINISTRO_CONV" , "1"},
                    { "SIARDEVC_NUM_IDENT_CONV" , "1"},
                    { "SIARDEVC_NUM_IDE_COBR_CONV" , "1"},
                    { "SIARDEVC_COD_CFOP" , "1"},
                    { "SIARDEVC_COD_CEST" , "1"},
                    { "SIARDEVC_NUM_INSCR_ESTADUAL" , "1"},
                    { "SIARDEVC_NUM_NCM" , "1"},
                    { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , "1"},
                    { "SIARDEVC_IND_ISENCAO_TRIBUTO" , "1"},
                    { "SIARDEVC_COD_IMPOSTO_LIMINAR" , "1"},
                    { "SIARDEVC_COD_PROCESSO_ISENCAO" , "1"},
                    { "SIARDEVC_VLR_RET_N_EFETUADO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI9268B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9268B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIERRO_DES_ERRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1210_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "GEARDETA_NOM_ARQUIVO" , "1"},
                    { "GEARDETA_SEQ_GERACAO" , "1"},
                    { "SIARREVC_TIPO_REGISTRO_VC" , "1"},
                    { "SIARREVC_SEQ_REGISTRO_VC" , "1"},
                    { "SIARDEVC_NOM_ARQUIVO" , "1"},
                    { "SIARDEVC_SEQ_GERACAO" , "1"},
                    { "SIARDEVC_TIPO_REGISTRO" , "1"},
                    { "SIARDEVC_SEQ_REGISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion
                var program = new SI9268B();
                program.Execute(CSPAGSIN_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}