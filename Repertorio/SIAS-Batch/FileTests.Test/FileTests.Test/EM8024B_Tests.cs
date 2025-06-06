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
using static Code.EM8024B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("EM8024B_Tests")]
    public class EM8024B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_OCORR_MOVTO" , ""},
                { "GE407_SEQ_CONTROL_CARTAO" , ""},
                { "GE407_COD_TP_PAGAMENTO" , ""},
                { "GE407_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_OCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE099_NUM_OCORR_MOVTO" , ""},
                { "GE099_DTH_MOVIMENTO" , ""},
                { "GE099_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE100_NUM_OCORR_MOVTO" , ""},
                { "GE100_COD_IDLG" , ""},
                { "GE100_DTA_MOVIMENTO_LEGADO" , ""},
                { "GE100_DTA_MOVIMENTO_ARQH" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE105_NUM_OCORR_MOVTO" , ""},
                { "GE105_SEQ_RETORNO_MOVIMENTO" , ""},
                { "GE105_DTA_MOVIMENTO" , ""},
                { "GE105_NUM_ESTRUTURA_ARQH" , ""},
                { "GE105_STA_COMPENSACAO" , ""},
                { "GE105_NUM_NSAS_ARQH" , ""},
                { "GE105_IND_MOTIVO_COMPENSACAO" , ""},
                { "GE105_COD_FATURA_SAP" , ""},
                { "GE105_NUM_ITEM_FATURA" , ""},
                { "GE105_NUM_NSAS_BANCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_PROPOSTA" , ""},
                { "GE407_NUM_CERTIFICADO" , ""},
                { "GE407_NUM_PARCELA" , ""},
                { "GE407_NUM_APOLICE" , ""},
                { "GE407_NUM_ENDOSSO" , ""},
                { "GE407_SEQ_CONTROL_CARTAO" , ""},
                { "GE407_COD_TP_PAGAMENTO" , ""},
                { "GE407_COD_IDLG" , ""},
                { "GE407_NUM_OCORR_MOVTO" , ""},
                { "GE407_COD_PRODUTO" , ""},
                { "GE407_DTA_VENCIMENTO" , ""},
                { "GE407_DTA_MOVIMENTO" , ""},
                { "GE407_VLR_TOT_PREMIO" , ""},
                { "GE407_COD_SISTEMA" , ""},
                { "GE407_COD_USUARIO" , ""},
                { "GE407_STA_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GE407_DTA_MOVIMENTO" , ""},
                { "GE407_STA_REGISTRO" , ""},
                { "GE407_SEQ_CONTROL_CARTAO" , ""},
                { "GE407_NUM_CERTIFICADO" , ""},
                { "GE407_NUM_OCORR_MOVTO" , ""},
                { "GE407_NUM_PROPOSTA" , ""},
                { "GE407_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_PROPOSTA" , ""},
                { "GE408_NUM_CERTIFICADO" , ""},
                { "GE408_NUM_PARCELA" , ""},
                { "GE408_NUM_APOLICE" , ""},
                { "GE408_NUM_ENDOSSO" , ""},
                { "GE408_SEQ_CONTROL_CARTAO" , ""},
                { "GE408_SEQ_RET_CONTROL_HIST" , ""},
                { "GE408_DTA_MOVIMENTO" , ""},
                { "GE408_NUM_COM_CIELO" , ""},
                { "GE408_COD_BCO_CRED" , ""},
                { "GE408_NUM_AGE_CRED" , ""},
                { "GE408_NUM_CTA_CRED" , ""},
                { "GE408_NUM_DIG_CTA_CRED" , ""},
                { "GE408_COD_CART_BANDEIRA" , ""},
                { "GE408_NUM_CARTAO" , ""},
                { "GE408_COD_TOKEN_CARTAO" , ""},
                { "GE408_STA_CART_PADRAO_SAP" , ""},
                { "GE408_COD_TID_CIELO" , ""},
                { "GE408_VLR_COBRANCA" , ""},
                { "GE408_VLR_LIQUIDO" , ""},
                { "GE408_VLR_TAX_ADM" , ""},
                { "GE408_DTA_VENCIMENTO" , ""},
                { "GE408_DTA_CREDITO" , ""},
                { "GE408_DTA_DEB_TARIFA_ADM" , ""},
                { "GE408_DTA_AJU_CAPTURA" , ""},
                { "GE408_COD_MOVIMENTO" , ""},
                { "GE408_COD_RETORNO" , ""},
                { "GE408_COD_USUARIO" , ""},
                { "GE408_COD_PROCE_ADVERTENCIA" , ""},
                { "GE408_COD_NIVEL_ADVERTENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "GE409_COD_MOVIMENTO" , ""},
                { "GE409_COD_RETORNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GE409_COD_MOVIMENTO" , ""},
                { "GE409_COD_RETORNO" , ""},
                { "GE409_DES_COD_RETORNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_DTCREDITO" , ""},
                { "VIND_DTCREDITO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_DTCREDITO" , ""},
                { "VIND_DTCREDITO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.EM.D240917.EM8006B.CARCIELO", "EM8024B_1_t1", "EM8024B_2_t1")]
        public static void EM8024B_Tests_Theory(string MOVCIELO_FILE_NAME_P, string CCADESAO_FILE_NAME_P, string CCDEMAIS_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CCADESAO_FILE_NAME_P = $"{CCADESAO_FILE_NAME_P}_{timestamp}.txt";
            CCDEMAIS_FILE_NAME_P = $"{CCDEMAIS_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "123"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_OCORR_MOVTO" , "1"},
                { "GE407_SEQ_CONTROL_CARTAO" , "1"},
                { "GE407_COD_TP_PAGAMENTO" , "04"},
                { "GE407_NUM_PARCELA" , "0"},
            });

                q3.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_OCORR_MOVTO" , "1"},
                { "GE407_SEQ_CONTROL_CARTAO" , "1"},
                { "GE407_COD_TP_PAGAMENTO" , "04"},
                { "GE407_NUM_PARCELA" , "0"},
            });

                q3.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_OCORR_MOVTO" , "1"},
                { "GE407_SEQ_CONTROL_CARTAO" , "1"},
                { "GE407_COD_TP_PAGAMENTO" , "04"},
                { "GE407_NUM_PARCELA" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_OCORR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GE099_NUM_OCORR_MOVTO" , "1"},
                { "GE099_DTH_MOVIMENTO" , "2020-01-01"},
                { "GE099_NOM_PROGRAMA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "GE409_COD_MOVIMENTO" , "PA"},
                { "GE409_COD_RETORNO" , "17"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "1"},
                { "MOVDEBCE_NUM_PARCELA" , "0"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "1"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1", q17);

                #endregion


                #endregion

                var program = new EM8024B();
                program.Execute(MOVCIELO_FILE_NAME_P, CCADESAO_FILE_NAME_P, CCDEMAIS_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1

                var envList2 = AppSettings.TestSet.DynamicData["R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("GE105_NUM_OCORR_MOVTO", out var GE105_NUM_OCORR_MOVTO) && GE105_NUM_OCORR_MOVTO == "000000000000000001");
                Assert.True(envList2[1].TryGetValue("GE105_SEQ_RETORNO_MOVIMENTO", out var GE105_SEQ_RETORNO_MOVIMENTO) && GE105_SEQ_RETORNO_MOVIMENTO == "0001");
                Assert.True(envList2[1].TryGetValue("GE105_DTA_MOVIMENTO", out var GE105_DTA_MOVIMENTO) && GE105_DTA_MOVIMENTO == "2020-01-01");
                Assert.True(envList2[1].TryGetValue("GE105_NUM_ESTRUTURA_ARQH", out var GE105_NUM_ESTRUTURA_ARQH) && GE105_NUM_ESTRUTURA_ARQH == "0014");
                Assert.True(envList2[1].TryGetValue("GE105_STA_COMPENSACAO", out var GE105_STA_COMPENSACAO) && GE105_STA_COMPENSACAO == "9");
                Assert.True(envList2[1].TryGetValue("GE105_NUM_NSAS_ARQH", out var GE105_NUM_NSAS_ARQH) && GE105_NUM_NSAS_ARQH == "000621838");
                Assert.True(envList2[1].TryGetValue("GE105_IND_MOTIVO_COMPENSACAO", out var GE105_IND_MOTIVO_COMPENSACAO) && GE105_IND_MOTIVO_COMPENSACAO == "0005");
                Assert.True(envList2[1].TryGetValue("GE105_COD_FATURA_SAP", out var GE105_COD_FATURA_SAP) && GE105_COD_FATURA_SAP == "472309017935");
                Assert.True(envList2[1].TryGetValue("GE105_NUM_ITEM_FATURA", out var GE105_NUM_ITEM_FATURA) && GE105_NUM_ITEM_FATURA == "0001");
                Assert.True(envList2[1].TryGetValue("GE105_NUM_NSAS_BANCO", out var GE105_NUM_NSAS_BANCO) && GE105_NUM_NSAS_BANCO == "000000000");

                #endregion


                #region R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1

                var envList4 = AppSettings.TestSet.DynamicData["R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 0);
                Assert.True(envList4[1].TryGetValue("GE407_DTA_MOVIMENTO", out var GE407_DTA_MOVIMENTO1) && GE407_DTA_MOVIMENTO1 == "2020-01-01");
                Assert.True(envList4[1].TryGetValue("GE407_STA_REGISTRO", out var GE407_STA_REGISTRO1) && GE407_STA_REGISTRO1 == "F");
                Assert.True(envList4[1].TryGetValue("GE407_SEQ_CONTROL_CARTAO", out var GE407_SEQ_CONTROL_CARTAO1) && GE407_SEQ_CONTROL_CARTAO1 == "0001");
                Assert.True(envList4[1].TryGetValue("GE407_NUM_CERTIFICADO", out var GE407_NUM_CERTIFICADO1) && GE407_NUM_CERTIFICADO1 == "000080186110023501");
                Assert.True(envList4[1].TryGetValue("GE407_NUM_OCORR_MOVTO", out var GE407_NUM_OCORR_MOVTO1) && GE407_NUM_OCORR_MOVTO1 == "000000000000000001");
                Assert.True(envList4[1].TryGetValue("GE407_NUM_PROPOSTA", out var GE407_NUM_PROPOSTA1) && GE407_NUM_PROPOSTA1 == "000000000000000000");
                Assert.True(envList4[1].TryGetValue("GE407_NUM_PARCELA", out var GE407_NUM_PARCELA1) && GE407_NUM_PARCELA1 == "0000");


                #endregion

                #region R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1

                var envList5 = AppSettings.TestSet.DynamicData["R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 0);
                Assert.True(envList5[1].TryGetValue("GE408_NUM_PROPOSTA", out var GE408_NUM_PROPOSTA) && GE408_NUM_PROPOSTA == "000000000000000000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_CERTIFICADO", out var GE408_NUM_CERTIFICADO) && GE408_NUM_CERTIFICADO == "000080186110023501");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_PARCELA", out var GE408_NUM_PARCELA) && GE408_NUM_PARCELA == "0000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_APOLICE", out var GE408_NUM_APOLICE) && GE408_NUM_APOLICE == "000000000000000000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_ENDOSSO", out var GE408_NUM_ENDOSSO) && GE408_NUM_ENDOSSO == "000000000000000000");
                Assert.True(envList5[1].TryGetValue("GE408_SEQ_CONTROL_CARTAO", out var GE408_SEQ_CONTROL_CARTAO) && GE408_SEQ_CONTROL_CARTAO == "0001");
                Assert.True(envList5[1].TryGetValue("GE408_SEQ_RET_CONTROL_HIST", out var GE408_SEQ_RET_CONTROL_HIST) && GE408_SEQ_RET_CONTROL_HIST == "0001");
                Assert.True(envList5[1].TryGetValue("GE408_DTA_MOVIMENTO", out var GE408_DTA_MOVIMENTO) && GE408_DTA_MOVIMENTO == "2020-01-01");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_COM_CIELO", out var GE408_NUM_COM_CIELO) && GE408_NUM_COM_CIELO == "000000001100166847");
                Assert.True(envList5[1].TryGetValue("GE408_COD_BCO_CRED", out var GE408_COD_BCO_CRED) && GE408_COD_BCO_CRED == "0000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_AGE_CRED", out var GE408_NUM_AGE_CRED) && GE408_NUM_AGE_CRED == "0000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_CTA_CRED", out var GE408_NUM_CTA_CRED) && GE408_NUM_CTA_CRED == "000000000");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_DIG_CTA_CRED", out var GE408_NUM_DIG_CTA_CRED) && GE408_NUM_DIG_CTA_CRED == "0000");
                Assert.True(envList5[1].TryGetValue("GE408_COD_CART_BANDEIRA", out var GE408_COD_CART_BANDEIRA) && GE408_COD_CART_BANDEIRA == "0005");
                Assert.True(envList5[1].TryGetValue("GE408_NUM_CARTAO", out var GE408_NUM_CARTAO) && GE408_NUM_CARTAO == "  650507******2409_000001");
                Assert.True(envList5[1].TryGetValue("GE408_COD_TOKEN_CARTAO", out var GE408_COD_TOKEN_CARTAO) && GE408_COD_TOKEN_CARTAO == "    8093cc5b-3ee7-4e43-bc64-bedc35e832a3");
                Assert.True(envList5[1].TryGetValue("GE408_STA_CART_PADRAO_SAP", out var GE408_STA_CART_PADRAO_SAP) && GE408_STA_CART_PADRAO_SAP == "X");
                Assert.True(envList5[1].TryGetValue("GE408_COD_TID_CIELO", out var GE408_COD_TID_CIELO) && GE408_COD_TID_CIELO == "11001668473RS3SFEG3E");
                Assert.True(envList5[1].TryGetValue("GE408_VLR_COBRANCA", out var GE408_VLR_COBRANCA) && GE408_VLR_COBRANCA == "0000000000041.67");
                Assert.True(envList5[1].TryGetValue("GE408_VLR_LIQUIDO", out var GE408_VLR_LIQUIDO) && GE408_VLR_LIQUIDO == "0000000000000.00");
                Assert.True(envList5[1].TryGetValue("GE408_VLR_TAX_ADM", out var GE408_VLR_TAX_ADM) && GE408_VLR_TAX_ADM == "0000000000000.00");
                Assert.True(envList5[1].TryGetValue("GE408_DTA_VENCIMENTO", out var GE408_DTA_VENCIMENTO) && GE408_DTA_VENCIMENTO == "2024 09 08");
                Assert.True(envList5[1].TryGetValue("GE408_DTA_CREDITO", out var GE408_DTA_CREDITO) && GE408_DTA_CREDITO == "2024 09 18");
                Assert.True(envList5[1].TryGetValue("GE408_DTA_DEB_TARIFA_ADM", out var GE408_DTA_DEB_TARIFA_ADM) && GE408_DTA_DEB_TARIFA_ADM == "0000 00 00");
                Assert.True(envList5[1].TryGetValue("GE408_DTA_AJU_CAPTURA", out var GE408_DTA_AJU_CAPTURA) && GE408_DTA_AJU_CAPTURA == "2024 09 16");
                Assert.True(envList5[1].TryGetValue("GE408_COD_MOVIMENTO", out var GE408_COD_MOVIMENTO) && GE408_COD_MOVIMENTO == "PA");
                Assert.True(envList5[1].TryGetValue("GE408_COD_RETORNO", out var GE408_COD_RETORNO) && GE408_COD_RETORNO == " 17");
                Assert.True(envList5[1].TryGetValue("GE408_COD_USUARIO", out var GE408_COD_USUARIO) && GE408_COD_USUARIO == "EM8024B ");
                Assert.True(envList5[1].TryGetValue("GE408_COD_PROCE_ADVERTENCIA", out var GE408_COD_PROCE_ADVERTENCIA) && GE408_COD_PROCE_ADVERTENCIA == "C5");
                Assert.True(envList5[1].TryGetValue("GE408_COD_NIVEL_ADVERTENCIA", out var GE408_COD_NIVEL_ADVERTENCIA) && GE408_COD_NIVEL_ADVERTENCIA == "03");

                #endregion


                #region R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1

                /*var envList7 = AppSettings.TestSet.DynamicData["R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7?.Count > 0);
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_DTCREDITO", out var MOVDEBCE_DTCREDITO) && MOVDEBCE_DTCREDITO == "2020-01-01");
                Assert.True(envList7[1].TryGetValue("VIND_DTCREDITO", out var VIND_DTCREDITO) && VIND_DTCREDITO == "-001");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_SITUACAO_COBRANCA", out var MOVDEBCE_SITUACAO_COBRANCA) && MOVDEBCE_SITUACAO_COBRANCA == "3");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_COD_RETORNO_CEF", out var MOVDEBCE_COD_RETORNO_CEF) && MOVDEBCE_COD_RETORNO_CEF == "9999");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_DATA_MOVIMENTO", out var MOVDEBCE_DATA_MOVIMENTO) && MOVDEBCE_DATA_MOVIMENTO == "2020-01-01");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_DATA_RETORNO", out var MOVDEBCE_DATA_RETORNO) && MOVDEBCE_DATA_RETORNO == "2020-01-01");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_COD_USUARIO", out var MOVDEBCE_COD_USUARIO) && MOVDEBCE_COD_USUARIO == "EM8024B ");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_NUM_REQUISICAO", out var MOVDEBCE_NUM_REQUISICAO) && MOVDEBCE_NUM_REQUISICAO == "0000000123456");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var MOVDEBCE_COD_CONVENIO) && MOVDEBCE_COD_CONVENIO == "000009020");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var MOVDEBCE_NUM_ENDOSSO) && MOVDEBCE_NUM_ENDOSSO == "000000000");
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_NSAS", out var MOVDEBCE_NSAS) && MOVDEBCE_NSAS == "0977");
                */
                #endregion



                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("PRD.EM.D240917.EM8006B.CARCIELO", "EM8024B_1_t2", "EM8024B_2_t2")]
        public static void EM8024B_Tests99_Theory(string MOVCIELO_FILE_NAME_P, string CCADESAO_FILE_NAME_P, string CCDEMAIS_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CCADESAO_FILE_NAME_P = $"{CCADESAO_FILE_NAME_P}_{timestamp}.txt";
            CCDEMAIS_FILE_NAME_P = $"{CCDEMAIS_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "123"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1

                var q3 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_OCORR" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GE099_NUM_OCORR_MOVTO" , "1"},
                { "GE099_DTH_MOVIMENTO" , "2020-01-01"},
                { "GE099_NOM_PROGRAMA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_ARQH" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_PROX_SEQ_HIST" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "GE409_COD_MOVIMENTO" , "PA"},
                { "GE409_COD_RETORNO" , "17"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "1"},
                { "MOVDEBCE_NUM_PARCELA" , "0"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "1"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1", q16);

                #endregion

                #region R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "123456"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "123456"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_VALOR_DEBITO" , "10"},
                { "MOVDEBCE_DTCREDITO" , "2020-01-01"},
                { "MOVDEBCE_NUM_REQUISICAO" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1", q17);

                #endregion

                #endregion

                var program = new EM8024B();
                program.Execute(MOVCIELO_FILE_NAME_P, CCADESAO_FILE_NAME_P, CCDEMAIS_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}