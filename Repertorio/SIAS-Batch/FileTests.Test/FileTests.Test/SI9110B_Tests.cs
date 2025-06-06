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
using static Code.SI9110B;

namespace FileTests.Test
{
    [Collection("SI9110B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9110B_Tests
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

            #region SI9110B_C01_SIARDEVC

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
                { "SIARDEVC_NOM_NAT_DOC" , ""},
                { "SIARDEVC_COD_IDENTIDADE" , ""},
                { "SIARDEVC_NOM_ORGAO_EXP" , ""},
                { "SIARDEVC_DTH_EXP_DOC_IDENT" , ""},
                { "SIARDEVC_COD_UF_EXPEDIDORA" , ""},
                { "SIARDEVC_COD_ATIV_PRINCIPAL" , ""},
                { "SIARDEVC_DTH_ULT_DOCTO" , ""},
                { "SIARDEVC_DES_MARCA_MODELO" , ""},
                { "SIARDEVC_NUM_PLACA" , ""},
                { "SIARDEVC_NUM_CHASSIS" , ""},
                { "SIARDEVC_DTH_ANO_VEICULO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("SI9110B_C01_SIARDEVC", q5);

            #endregion

            #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

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
        [InlineData("CVMOVSIN_1")]
        public static void SI9110B_Tests1_Theory(string CVMOVSIN_FILE_NAME_P)
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "1001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARVRCZ_TIPO_REGISTRO" , "A" },
                { "SIARVRCZ_SEQ_REGISTRO" , "2001" },
                { "SIARVRCZ_STA_PROCESSAMENTO" , "P" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9110B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
                { "SIARDEVC_COD_OPERACAO" , "150" },
                { "SIARDEVC_OCORR_HISTORICO" , "Incident occurred" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "S12345" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "E12345" },
                { "SIARDEVC_NUM_APOLICE" , "A12345" },
                { "SIARDEVC_NUM_ENDOSSO" , "EN12345" },
                { "SIARDEVC_NUM_ITEM" , "1" },
                { "SIARDEVC_COD_RAMO" , "101" },
                { "SIARDEVC_COD_COBERTURA" , "201" },
                { "SIARDEVC_COD_CAUSA" , "301" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-30" },
                { "SIARDEVC_HORA_OCORRENCIA" , "14:00" },
                { "SIARDEVC_DATA_MOVIMENTO" , "2023-12-02" },
                { "SIARDEVC_IND_FAVORECIDO" , "Y" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "10000.0" },
                { "SIARDEVC_VAL_PECAS" , "3000.0" },
                { "SIARDEVC_VAL_MAO_OBRA" , "2000.0" },
                { "SIARDEVC_VAL_PARCELA_PEND" , "500.0" },
                { "SIARDEVC_QTD_PARCELA_PEND" , "2" },
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "50.0" },
                { "SIARDEVC_DATA_NEGOCIADA" , "2023-12-10" },
                { "SIARDEVC_VAL_IRF" , "100.0" },
                { "SIARDEVC_VAL_ISS" , "50.0" },
                { "SIARDEVC_VAL_INSS" , "150.0" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "9700.0" },
                { "SIARDEVC_CGCCPF" , "12345678901" },
                { "SIARDEVC_TIPO_PESSOA" , "F" },
                { "SIARDEVC_NOM_FAVORECIDO" , "John Doe" },
                { "SIARDEVC_IND_DOC_FISCAL" , "N" },
                { "SIARDEVC_NUM_DOC_FISCAL" , "100000123" },
                { "SIARDEVC_SERIE_DOC_FISCAL" , "A1" },
                { "SIARDEVC_DATA_EMISSAO" , "2023-12-01" },
                { "SIARDEVC_DES_ENDERECO" , "123 Main St" },
                { "SIARDEVC_NOM_BAIRRO" , "Central" },
                { "SIARDEVC_NOM_CIDADE" , "Metropolis" },
                { "SIARDEVC_COD_UF" , "SP" },
                { "SIARDEVC_NUM_CEP" , "12345678" },
                { "SIARDEVC_NUM_DDD" , "11" },
                { "SIARDEVC_NUM_TELEFONE" , "40028922" },
                { "SIARDEVC_IND_FORMA_PAGTO" , "Transfer" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456" },
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CQ123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "OP123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO" , "OP654321" },
                { "SIARDEVC_COD_BANCO" , "001" },
                { "SIARDEVC_COD_AGENCIA" , "0001" },
                { "SIARDEVC_OPERACAO_CONTA" , "013" },
                { "SIARDEVC_COD_CONTA" , "1234567" },
                { "SIARDEVC_DV_CONTA" , "0" },
                { "SIARDEVC_COD_FAVORECIDO" , "F123456" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "AS123456" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processed" },
                { "SIARDEVC_COD_ERRO" , "None" },
                { "SIARDEVC_VAL_PISPASEP" , "0.0" },
                { "SIARDEVC_VAL_COFINS" , "0.0" },
                { "SIARDEVC_VAL_CSLL" , "0.0" },
                { "SIARDEVC_COD_FONTE" , "100" },
                { "SIARDEVC_NOM_NAT_DOC" , "Invoice" },
                { "SIARDEVC_COD_IDENTIDADE" , "RG123456" },
                { "SIARDEVC_NOM_ORGAO_EXP" , "SSP" },
                { "SIARDEVC_DTH_EXP_DOC_IDENT" , "2020-01-01" },
                { "SIARDEVC_COD_UF_EXPEDIDORA" , "SP" },
                { "SIARDEVC_COD_ATIV_PRINCIPAL" , "1234" },
                { "SIARDEVC_DTH_ULT_DOCTO" , "2023-11-30" },
                { "SIARDEVC_DES_MARCA_MODELO" , "Ford Focus" },
                { "SIARDEVC_NUM_PLACA" , "XYZ1234" },
                { "SIARDEVC_NUM_CHASSIS" , "9BWZZZ377VT004251" },
                { "SIARDEVC_DTH_ANO_VEICULO" , "2018-01-01" },
                { "SIARDEVC_NUM_RESSARC" , "R123456" },
                { "SIARDEVC_IND_PESSOA_ACORDO" , "N" },
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "98765432109" },
                { "SIARDEVC_NOM_RESP_ACORDO" , "Jane Doe" },
                { "SIARDEVC_STA_ACORDO" , "Pending" },
                { "SIARDEVC_DTH_INDENIZACAO" , "2023-12-05" },
                { "SIARDEVC_VLR_INDENIZACAO" , "15000.0" },
                { "SIARDEVC_VLR_PART_TERCEIROS" , "5000.0" },
                { "SIARDEVC_VLR_DIVIDA" , "2000.0" },
                { "SIARDEVC_PCT_DESCONTO" , "10.0" },
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "200.0" },
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "18000.0" },
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL" },
                { "SIARDEVC_DTH_ACORDO" , "2023-12-10" },
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "3" },
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1" },
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "0001" },
                { "SIARDEVC_NUM_CEDENTE" , "C123456" },
                { "SIARDEVC_NUM_CEDENTE_DV" , "1" },
                { "SIARDEVC_DTH_VENCIMENTO" , "2024-01-01" },
                { "SIARDEVC_NUM_NOSSO_TITULO" , "NT123456" },
                { "SIARDEVC_VLR_TITULO" , "10000.0" },
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "12345678909" },
                { "SIARDEVC_NOM_RECLAMANTE" , "Client X" },
                { "SIARDEVC_VLR_RECLAMADO" , "12000.0" },
                { "SIARDEVC_VLR_PROVISIONADO" , "11000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9110B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9110B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "No error" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "200" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "P123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARREVC_TIPO_REGISTRO_VC" , "C" },
                { "SIARREVC_SEQ_REGISTRO_VC" , "3001" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion
              
                #endregion
              
                var program = new SI9110B();
                program.Execute(CVMOVSIN_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

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
        [InlineData("CVMOVSIN_2")]
        public static void SI9110B_Tests2_Theory(string CVMOVSIN_FILE_NAME_P)
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "1001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARVRCZ_TIPO_REGISTRO" , "A" },
                { "SIARVRCZ_SEQ_REGISTRO" , "2001" },
                { "SIARVRCZ_STA_PROCESSAMENTO" , "OK" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9110B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
                { "SIARDEVC_COD_OPERACAO" , "150" },
                { "SIARDEVC_OCORR_HISTORICO" , "Incident reported" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "S12345" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "E12345" },
                { "SIARDEVC_NUM_APOLICE" , "A12345" },
                { "SIARDEVC_NUM_ENDOSSO" , "EN12345" },
                { "SIARDEVC_NUM_ITEM" , "1" },
                { "SIARDEVC_COD_RAMO" , "R123" },
                { "SIARDEVC_COD_COBERTURA" , "C123" },
                { "SIARDEVC_COD_CAUSA" , "CA123" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-30" },
                { "SIARDEVC_HORA_OCORRENCIA" , "14:00" },
                { "SIARDEVC_DATA_MOVIMENTO" , "2023-12-01" },
                { "SIARDEVC_IND_FAVORECIDO" , "Y" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "10000.0" },
                { "SIARDEVC_VAL_PECAS" , "3000.0" },
                { "SIARDEVC_VAL_MAO_OBRA" , "2000.0" },
                { "SIARDEVC_VAL_PARCELA_PEND" , "500.0" },
                { "SIARDEVC_QTD_PARCELA_PEND" , "2" },
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "50.0" },
                { "SIARDEVC_DATA_NEGOCIADA" , "2023-12-10" },
                { "SIARDEVC_VAL_IRF" , "100.0" },
                { "SIARDEVC_VAL_ISS" , "50.0" },
                { "SIARDEVC_VAL_INSS" , "150.0" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "9700.0" },
                { "SIARDEVC_CGCCPF" , "12345678901" },
                { "SIARDEVC_TIPO_PESSOA" , "F" },
                { "SIARDEVC_NOM_FAVORECIDO" , "John Doe" },
                { "SIARDEVC_IND_DOC_FISCAL" , "N" },
                { "SIARDEVC_NUM_DOC_FISCAL" , "DF123456" },
                { "SIARDEVC_SERIE_DOC_FISCAL" , "S1" },
                { "SIARDEVC_DATA_EMISSAO" , "2023-12-01" },
                { "SIARDEVC_DES_ENDERECO" , "123 Main St" },
                { "SIARDEVC_NOM_BAIRRO" , "Central" },
                { "SIARDEVC_NOM_CIDADE" , "Metropolis" },
                { "SIARDEVC_COD_UF" , "SP" },
                { "SIARDEVC_NUM_CEP" , "12345678" },
                { "SIARDEVC_NUM_DDD" , "11" },
                { "SIARDEVC_NUM_TELEFONE" , "123456789" },
                { "SIARDEVC_IND_FORMA_PAGTO" , "Transfer" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456" },
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CH123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "OP123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO" , "OP654321" },
                { "SIARDEVC_COD_BANCO" , "001" },
                { "SIARDEVC_COD_AGENCIA" , "0001" },
                { "SIARDEVC_OPERACAO_CONTA" , "013" },
                { "SIARDEVC_COD_CONTA" , "000123456" },
                { "SIARDEVC_DV_CONTA" , "0" },
                { "SIARDEVC_COD_FAVORECIDO" , "F123456" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "AS123456" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processed" },
                { "SIARDEVC_COD_ERRO" , "1" },
                { "SIARDEVC_VAL_PISPASEP" , "10.0" },
                { "SIARDEVC_VAL_COFINS" , "20.0" },
                { "SIARDEVC_VAL_CSLL" , "30.0" },
                { "SIARDEVC_COD_FONTE" , "CF123" },
                { "SIARDEVC_NOM_NAT_DOC" , "Invoice" },
                { "SIARDEVC_COD_IDENTIDADE" , "ID123" },
                { "SIARDEVC_NOM_ORGAO_EXP" , "SSP" },
                { "SIARDEVC_DTH_EXP_DOC_IDENT" , "2023-12-01" },
                { "SIARDEVC_COD_UF_EXPEDIDORA" , "SP" },
                { "SIARDEVC_COD_ATIV_PRINCIPAL" , "AP123" },
                { "SIARDEVC_DTH_ULT_DOCTO" , "2023-12-01" },
                { "SIARDEVC_DES_MARCA_MODELO" , "Ford Focus" },
                { "SIARDEVC_NUM_PLACA" , "XYZ1234" },
                { "SIARDEVC_NUM_CHASSIS" , "9BWZZZ377VT004251" },
                { "SIARDEVC_DTH_ANO_VEICULO" , "2023-01-01" },
                { "SIARDEVC_NUM_RESSARC" , "R123456" },
                { "SIARDEVC_IND_PESSOA_ACORDO" , "Y" },
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "98765432109" },
                { "SIARDEVC_NOM_RESP_ACORDO" , "Jane Doe" },
                { "SIARDEVC_STA_ACORDO" , "Agreed" },
                { "SIARDEVC_DTH_INDENIZACAO" , "2023-12-05" },
                { "SIARDEVC_VLR_INDENIZACAO" , "15000.0" },
                { "SIARDEVC_VLR_PART_TERCEIROS" , "5000.0" },
                { "SIARDEVC_VLR_DIVIDA" , "2000.0" },
                { "SIARDEVC_PCT_DESCONTO" , "5.0" },
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "1000.0" },
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "25000.0" },
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL" },
                { "SIARDEVC_DTH_ACORDO" , "2023-12-10" },
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "3" },
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1" },
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "0002" },
                { "SIARDEVC_NUM_CEDENTE" , "C123456" },
                { "SIARDEVC_NUM_CEDENTE_DV" , "1" },
                { "SIARDEVC_DTH_VENCIMENTO" , "2024-01-01" },
                { "SIARDEVC_NUM_NOSSO_TITULO" , "NT123456" },
                { "SIARDEVC_VLR_TITULO" , "30000.0" },
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "23456789012" },
                { "SIARDEVC_NOM_RECLAMANTE" , "Alice Smith" },
                { "SIARDEVC_VLR_RECLAMADO" , "5000.0" },
                { "SIARDEVC_VLR_PROVISIONADO" , "4500.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9110B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9110B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "Error description" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "SF123" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "PS123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARREVC_TIPO_REGISTRO_VC" , "C" },
                { "SIARREVC_SEQ_REGISTRO_VC" , "3001" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2002" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion

                           
                #endregion
                var program = new SI9110B();
                program.Execute(CVMOVSIN_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

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
        [InlineData("CVMOVSIN_3")]
        public static void SI9110B_Tests3_Theory(string CVMOVSIN_FILE_NAME_P)
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "1001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARVRCZ_TIPO_REGISTRO" , "A" },
                { "SIARVRCZ_SEQ_REGISTRO" , "1" },
                { "SIARVRCZ_STA_PROCESSAMENTO" , "P" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , "500" },
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9110B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2" },
                { "SIARDEVC_COD_OPERACAO" , "150" },
                { "SIARDEVC_OCORR_HISTORICO" , "Incident" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "S12345" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "E12345" },
                { "SIARDEVC_NUM_APOLICE" , "A12345" },
                { "SIARDEVC_NUM_ENDOSSO" , "EN12345" },
                { "SIARDEVC_NUM_ITEM" , "1" },
                { "SIARDEVC_COD_RAMO" , "101" },
                { "SIARDEVC_COD_COBERTURA" , "201" },
                { "SIARDEVC_COD_CAUSA" , "301" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-30" },
                { "SIARDEVC_HORA_OCORRENCIA" , "14:00" },
                { "SIARDEVC_DATA_MOVIMENTO" , "2023-12-01" },
                { "SIARDEVC_IND_FAVORECIDO" , "Y" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "10000.0" },
                { "SIARDEVC_VAL_PECAS" , "3000.0" },
                { "SIARDEVC_VAL_MAO_OBRA" , "2000.0" },
                { "SIARDEVC_VAL_PARCELA_PEND" , "500.0" },
                { "SIARDEVC_QTD_PARCELA_PEND" , "2" },
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "50.0" },
                { "SIARDEVC_DATA_NEGOCIADA" , "2023-12-15" },
                { "SIARDEVC_VAL_IRF" , "100.0" },
                { "SIARDEVC_VAL_ISS" , "50.0" },
                { "SIARDEVC_VAL_INSS" , "150.0" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "9700.0" },
                { "SIARDEVC_CGCCPF" , "12345678901" },
                { "SIARDEVC_TIPO_PESSOA" , "F" },
                { "SIARDEVC_NOM_FAVORECIDO" , "John Doe" },
                { "SIARDEVC_IND_DOC_FISCAL" , "N" },
                { "SIARDEVC_NUM_DOC_FISCAL" , "1000" },
                { "SIARDEVC_SERIE_DOC_FISCAL" , "A1" },
                { "SIARDEVC_DATA_EMISSAO" , "2023-12-01" },
                { "SIARDEVC_DES_ENDERECO" , "123 Main St" },
                { "SIARDEVC_NOM_BAIRRO" , "Central" },
                { "SIARDEVC_NOM_CIDADE" , "Metropolis" },
                { "SIARDEVC_COD_UF" , "SP" },
                { "SIARDEVC_NUM_CEP" , "12345678" },
                { "SIARDEVC_NUM_DDD" , "11" },
                { "SIARDEVC_NUM_TELEFONE" , "123456789" },
                { "SIARDEVC_IND_FORMA_PAGTO" , "Transfer" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID12345" },
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CQ12345" },
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "OP12345" },
                { "SIARDEVC_ORDEM_PAGAMENTO" , "OP54321" },
                { "SIARDEVC_COD_BANCO" , "001" },
                { "SIARDEVC_COD_AGENCIA" , "0001" },
                { "SIARDEVC_OPERACAO_CONTA" , "013" },
                { "SIARDEVC_COD_CONTA" , "1234567" },
                { "SIARDEVC_DV_CONTA" , "0" },
                { "SIARDEVC_COD_FAVORECIDO" , "F12345" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "00" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "OK" },
                { "SIARDEVC_COD_ERRO" , "" },
                { "SIARDEVC_VAL_PISPASEP" , "0.0" },
                { "SIARDEVC_VAL_COFINS" , "0.0" },
                { "SIARDEVC_VAL_CSLL" , "0.0" },
                { "SIARDEVC_COD_FONTE" , "100" },
                { "SIARDEVC_NOM_NAT_DOC" , "Invoice" },
                { "SIARDEVC_COD_IDENTIDADE" , "RG12345" },
                { "SIARDEVC_NOM_ORGAO_EXP" , "SSP" },
                { "SIARDEVC_DTH_EXP_DOC_IDENT" , "2023-12-01" },
                { "SIARDEVC_COD_UF_EXPEDIDORA" , "SP" },
                { "SIARDEVC_COD_ATIV_PRINCIPAL" , "1234" },
                { "SIARDEVC_DTH_ULT_DOCTO" , "2023-12-01" },
                { "SIARDEVC_DES_MARCA_MODELO" , "Car Model X" },
                { "SIARDEVC_NUM_PLACA" , "XYZ-1234" },
                { "SIARDEVC_NUM_CHASSIS" , "CH12345678901234" },
                { "SIARDEVC_DTH_ANO_VEICULO" , "2023" },
                { "SIARDEVC_NUM_RESSARC" , "R12345" },
                { "SIARDEVC_IND_PESSOA_ACORDO" , "N" },
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "98765432109" },
                { "SIARDEVC_NOM_RESP_ACORDO" , "Jane Doe" },
                { "SIARDEVC_STA_ACORDO" , "Pending" },
                { "SIARDEVC_DTH_INDENIZACAO" , "2023-12-20" },
                { "SIARDEVC_VLR_INDENIZACAO" , "15000.0" },
                { "SIARDEVC_VLR_PART_TERCEIROS" , "5000.0" },
                { "SIARDEVC_VLR_DIVIDA" , "2000.0" },
                { "SIARDEVC_PCT_DESCONTO" , "10.0" },
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "200.0" },
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "18000.0" },
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL" },
                { "SIARDEVC_DTH_ACORDO" , "2023-12-25" },
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "3" },
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1" },
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "0002" },
                { "SIARDEVC_NUM_CEDENTE" , "C123456" },
                { "SIARDEVC_NUM_CEDENTE_DV" , "1" },
                { "SIARDEVC_DTH_VENCIMENTO" , "2024-01-01" },
                { "SIARDEVC_NUM_NOSSO_TITULO" , "NT123456" },
                { "SIARDEVC_VLR_TITULO" , "20000.0" },
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "23456789012" },
                { "SIARDEVC_NOM_RECLAMANTE" , "Alice Smith" },
                { "SIARDEVC_VLR_RECLAMADO" , "25000.0" },
                { "SIARDEVC_VLR_PROVISIONADO" , "23000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9110B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9110B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "No error" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "200" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "P123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "file1.txt" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARREVC_TIPO_REGISTRO_VC" , "C" },
                { "SIARREVC_SEQ_REGISTRO_VC" , "3" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_TIPO_REGISTRO" , "B" },
                { "SIARDEVC_SEQ_REGISTRO" , "2" },
                { "SIARDEVC_NOM_ARQUIVO" , "file2.txt" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion
                var program = new SI9110B();
                program.Execute(CVMOVSIN_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

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
        [InlineData("CVMOVSIN_4")]
        public static void SI9110B_Tests99_Theory(string CVMOVSIN_FILE_NAME_P)
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();                
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9110B_C01_SIARDEVC

                var q5 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("SI9110B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9110B_C01_SIARDEVC", q5);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "No error" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "200" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "P123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q8 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q9 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion
                var program = new SI9110B();
                program.Execute(CVMOVSIN_FILE_NAME_P);
              
                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}