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
    public class R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1 : QueryBasis<R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
				SET NUM_OCORR_MOVTO =
				 {FieldThreatment((this.WS_IND_NUM_OCORR_MOVTO?.ToInt() == -1 ? null : $"{this.GE403_NUM_OCORR_MOVTO}"))},
				NUM_IDLG =
				 {FieldThreatment((this.WS_IND_NUM_IDLG?.ToInt() == -1 ? null : $"{this.GE403_NUM_IDLG}"))} ,
				COD_CEDENTE_SAP =
				 {FieldThreatment((this.WS_IND_COD_CEDENTE?.ToInt() == -1 ? null : $"{this.GE403_COD_CEDENTE_SAP}"))} ,
				NUM_BOLETO_INTERNO =
				 {FieldThreatment((this.WS_IND_BOL_INT?.ToInt() == -1 ? null : $"{this.GE403_NUM_BOLETO_INTERNO}"))} ,
				NUM_NOSSO_NUMERO_SAP =
				 {FieldThreatment((this.WS_IND_NN_SAP?.ToInt() == -1 ? null : $"{this.GE403_NUM_NOSSO_NUMERO_SAP}"))} ,
				COD_LINHA_DIGITAVEL =
				 {FieldThreatment((this.WS_IND_COD_LIN_DIG?.ToInt() == -1 ? null : $"{this.GE403_COD_LINHA_DIGITAVEL}"))} ,
				NUM_TITULO =
				 {FieldThreatment((this.WS_IND_NUM_TITULO?.ToInt() == -1 ? null : $"{this.GE403_NUM_TITULO}"))} ,
				COD_SITUACAO =  '{this.GE403_COD_SITUACAO}',
				COD_USUARIO =  '{this.GE403_COD_USUARIO}' ,
				DTH_PROCESSAMENTO = CURRENT_TIMESTAMP
				WHERE  NUM_PROPOSTA =  '{this.GE403_NUM_PROPOSTA}'
				AND NUM_CERTIFICADO =  '{this.GE403_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.GE403_NUM_PARCELA}'
				AND NUM_APOLICE =  '{this.GE403_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.GE403_NUM_ENDOSSO}'
				AND SEQ_CONTROLE_SIGCB =  '{this.GE403_SEQ_CONTROLE_SIGCB}'";

            return query;
        }
        public string GE403_NUM_OCORR_MOVTO { get; set; }
        public string WS_IND_NUM_OCORR_MOVTO { get; set; }
        public string GE403_COD_LINHA_DIGITAVEL { get; set; }
        public string WS_IND_COD_LIN_DIG { get; set; }
        public string GE403_COD_CEDENTE_SAP { get; set; }
        public string WS_IND_COD_CEDENTE { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }
        public string WS_IND_NN_SAP { get; set; }
        public string GE403_NUM_BOLETO_INTERNO { get; set; }
        public string WS_IND_BOL_INT { get; set; }
        public string GE403_NUM_TITULO { get; set; }
        public string WS_IND_NUM_TITULO { get; set; }
        public string GE403_NUM_IDLG { get; set; }
        public string WS_IND_NUM_IDLG { get; set; }
        public string GE403_COD_SITUACAO { get; set; }
        public string GE403_COD_USUARIO { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static void Execute(R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1 r4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1)
        {
            var ths = r4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}