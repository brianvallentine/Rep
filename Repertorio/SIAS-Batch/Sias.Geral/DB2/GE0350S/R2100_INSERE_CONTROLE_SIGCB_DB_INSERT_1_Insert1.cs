using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1 : QueryBasis<R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
            VALUES (
            :GE403-NUM-PROPOSTA ,
            :GE403-NUM-CERTIFICADO ,
            :GE403-NUM-PARCELA ,
            :GE403-NUM-APOLICE ,
            :GE403-NUM-ENDOSSO ,
            :GE403-SEQ-CONTROLE-SIGCB ,
            :GE403-NUM-OCORR-MOVTO :WS-IND-NUM-OCORR-MOVTO,
            :GE403-NUM-IDLG :WS-IND-NUM-IDLG,
            :GE403-COD-PRODUTO ,
            :GE403-DTA-MOVIMENTO ,
            :GE403-DTA-VENCIMENTO ,
            :GE403-VLR-PREMIO-TOTAL ,
            :GE403-VLR-IOF ,
            :GE403-QTD-PARCELA ,
            :GE403-QTD-DIAS-CUSTODIA ,
            :GE403-COD-CLIENTE ,
            :GE403-COD-CEDENTE-SAP :WS-IND-COD-CEDENTE,
            :GE403-NUM-BOLETO-INTERNO :WS-IND-BOL-INT,
            :GE403-NUM-NOSSO-NUMERO-SAP :WS-IND-NN-SAP,
            :GE403-COD-LINHA-DIGITAVEL :WS-IND-COD-LIN-DIG,
            :GE403-NUM-TITULO :WS-IND-NUM-TITULO,
            :GE403-IDE-SISTEMA ,
            :GE403-COD-USUARIO ,
            :GE403-COD-SITUACAO ,
            CURRENT_TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CONTROLE_EMISSAO_SIGCB VALUES ( {FieldThreatment(this.GE403_NUM_PROPOSTA)} , {FieldThreatment(this.GE403_NUM_CERTIFICADO)} , {FieldThreatment(this.GE403_NUM_PARCELA)} , {FieldThreatment(this.GE403_NUM_APOLICE)} , {FieldThreatment(this.GE403_NUM_ENDOSSO)} , {FieldThreatment(this.GE403_SEQ_CONTROLE_SIGCB)} ,  {FieldThreatment((this.WS_IND_NUM_OCORR_MOVTO?.ToInt() == -1 ? null : this.GE403_NUM_OCORR_MOVTO))},  {FieldThreatment((this.WS_IND_NUM_IDLG?.ToInt() == -1 ? null : this.GE403_NUM_IDLG))}, {FieldThreatment(this.GE403_COD_PRODUTO)} , {FieldThreatment(this.GE403_DTA_MOVIMENTO)} , {FieldThreatment(this.GE403_DTA_VENCIMENTO)} , {FieldThreatment(this.GE403_VLR_PREMIO_TOTAL)} , {FieldThreatment(this.GE403_VLR_IOF)} , {FieldThreatment(this.GE403_QTD_PARCELA)} , {FieldThreatment(this.GE403_QTD_DIAS_CUSTODIA)} , {FieldThreatment(this.GE403_COD_CLIENTE)} ,  {FieldThreatment((this.WS_IND_COD_CEDENTE?.ToInt() == -1 ? null : this.GE403_COD_CEDENTE_SAP))},  {FieldThreatment((this.WS_IND_BOL_INT?.ToInt() == -1 ? null : this.GE403_NUM_BOLETO_INTERNO))},  {FieldThreatment((this.WS_IND_NN_SAP?.ToInt() == -1 ? null : this.GE403_NUM_NOSSO_NUMERO_SAP))},  {FieldThreatment((this.WS_IND_COD_LIN_DIG?.ToInt() == -1 ? null : this.GE403_COD_LINHA_DIGITAVEL))},  {FieldThreatment((this.WS_IND_NUM_TITULO?.ToInt() == -1 ? null : this.GE403_NUM_TITULO))}, {FieldThreatment(this.GE403_IDE_SISTEMA)} , {FieldThreatment(this.GE403_COD_USUARIO)} , {FieldThreatment(this.GE403_COD_SITUACAO)} , CURRENT_TIMESTAMP)";

            return query;
        }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_NUM_OCORR_MOVTO { get; set; }
        public string WS_IND_NUM_OCORR_MOVTO { get; set; }
        public string GE403_NUM_IDLG { get; set; }
        public string WS_IND_NUM_IDLG { get; set; }
        public string GE403_COD_PRODUTO { get; set; }
        public string GE403_DTA_MOVIMENTO { get; set; }
        public string GE403_DTA_VENCIMENTO { get; set; }
        public string GE403_VLR_PREMIO_TOTAL { get; set; }
        public string GE403_VLR_IOF { get; set; }
        public string GE403_QTD_PARCELA { get; set; }
        public string GE403_QTD_DIAS_CUSTODIA { get; set; }
        public string GE403_COD_CLIENTE { get; set; }
        public string GE403_COD_CEDENTE_SAP { get; set; }
        public string WS_IND_COD_CEDENTE { get; set; }
        public string GE403_NUM_BOLETO_INTERNO { get; set; }
        public string WS_IND_BOL_INT { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }
        public string WS_IND_NN_SAP { get; set; }
        public string GE403_COD_LINHA_DIGITAVEL { get; set; }
        public string WS_IND_COD_LIN_DIG { get; set; }
        public string GE403_NUM_TITULO { get; set; }
        public string WS_IND_NUM_TITULO { get; set; }
        public string GE403_IDE_SISTEMA { get; set; }
        public string GE403_COD_USUARIO { get; set; }
        public string GE403_COD_SITUACAO { get; set; }

        public static void Execute(R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1 r2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1)
        {
            var ths = r2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}