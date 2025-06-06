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

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("EM8024B_Tests_DB")]
    public class EM8024B_Tests_DB
    {

        [Fact]
        public static void EM8024B_Database()
        {
            var program = new EM8024B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.Value = 1;
                program.R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.WS_TRABALHO.WSHOST_NRAVISO1.Value = 1;
                program.WS_TRABALHO.WSHOST_NRAVISO2.Value = 1;
                program.R0407_00_SELECT_AVISOCRE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.Value = "1";
                program.R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO.Value = 784066;
                program.GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO.Value = "2020-01-01";
                program.GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA.Value = "7841";
                program.R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.Value = 21384577;
                program.GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG.Value = "1";
                program.GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO.Value = "2020-01-01";
                program.GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_ARQH.Value = "2020-01-01";
                program.R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO.Value = 1;
                program.R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO.Value = 784698;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_SEQ_RETORNO_MOVIMENTO.Value = 1;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_DTA_MOVIMENTO.Value = "2020-01-01";
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ESTRUTURA_ARQH.Value = 1;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_STA_COMPENSACAO.Value = "A";
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_ARQH.Value = 123;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_IND_MOTIVO_COMPENSACAO.Value = 1;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_COD_FATURA_SAP.Value = "1";
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ITEM_FATURA.Value = 1;
                program.GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_BANCO.Value = 1;
                program.R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA.Value = 1;
                program.R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_APOLICE.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_ENDOSSO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO.Value = "1";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.Value = "1";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_PRODUTO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_VENCIMENTO.Value = "2020-01-01";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.Value = "2020-01-01";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_VLR_TOT_PREMIO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_SISTEMA.Value = "1";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_USUARIO.Value = "1";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO.Value = "1";
                program.R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 132;
                program.R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.Value = "2020-01-01";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO.Value = "1";
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.Value = 123;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO.Value = 1;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA.Value = 123;
                program.GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.Value = 0;
                program.R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PROPOSTA.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA.Value = 0;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_APOLICE.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_ENDOSSO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_RET_CONTROL_HIST.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_MOVIMENTO.Value = "2020-01-01";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_COM_CIELO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_BCO_CRED.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_AGE_CRED.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CTA_CRED.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_DIG_CTA_CRED.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_CART_BANDEIRA.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TOKEN_CARTAO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_STA_CART_PADRAO_SAP.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TID_CIELO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_LIQUIDO.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_TAX_ADM.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_VENCIMENTO.Value = "2020-01-01";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO.Value = "2020-01-01";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_DEB_TARIFA_ADM.Value = "2020-01-01";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_AJU_CAPTURA.Value = "2020-01-01";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_MOVIMENTO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_RETORNO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_USUARIO.Value = "1";
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_PROCE_ADVERTENCIA.Value = "1";
                program.VIND_PROC_ADVERT.Value = 1;
                program.GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_NIVEL_ADVERTENCIA.Value = "1";
                program.VIND_NIVE_ADVERT.Value = 1;
                program.R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO.Value = "1";
                program.GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO.Value = "2";
                program.R0570_00_VERIFICA_COD_RET_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO.Value = "1";
                program.GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO.Value = "2";
                program.R0580_00_INSERIR_COD_RET_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 123;
                program.R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 2;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 3;
                program.R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2020-01-01";
                program.VIND_DTCREDITO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.Value = "1";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.Value = "1";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 1;
                program.R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2020-01-01";
                program.VIND_DTCREDITO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.Value = "1";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.Value = "X";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 1;
                program.R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}