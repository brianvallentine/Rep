using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1 : QueryBasis<R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CONTROLE_CARTAO_CIELO
            ( NUM_PROPOSTA
            , NUM_CERTIFICADO
            , NUM_PARCELA
            , NUM_APOLICE
            , NUM_ENDOSSO
            , SEQ_CONTROL_CARTAO
            , COD_TP_PAGAMENTO
            , COD_IDLG
            , NUM_OCORR_MOVTO
            , COD_PRODUTO
            , DTA_VENCIMENTO
            , DTA_MOVIMENTO
            , VLR_TOT_PREMIO
            , COD_SISTEMA
            , COD_USUARIO
            , STA_REGISTRO
            , DTH_PROCESSAMENTO
            )
            VALUES ( :GE407-NUM-PROPOSTA
            , :GE407-NUM-CERTIFICADO
            , :GE407-NUM-PARCELA
            , :GE407-NUM-APOLICE
            , :GE407-NUM-ENDOSSO
            , :GE407-SEQ-CONTROL-CARTAO
            , :GE407-COD-TP-PAGAMENTO
            , :GE407-COD-IDLG
            , :GE407-NUM-OCORR-MOVTO
            , :GE407-COD-PRODUTO
            , :GE407-DTA-VENCIMENTO
            , :GE407-DTA-MOVIMENTO
            , :GE407-VLR-TOT-PREMIO
            , :GE407-COD-SISTEMA
            , :GE407-COD-USUARIO
            , :GE407-STA-REGISTRO
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CONTROLE_CARTAO_CIELO ( NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROL_CARTAO , COD_TP_PAGAMENTO , COD_IDLG , NUM_OCORR_MOVTO , COD_PRODUTO , DTA_VENCIMENTO , DTA_MOVIMENTO , VLR_TOT_PREMIO , COD_SISTEMA , COD_USUARIO , STA_REGISTRO , DTH_PROCESSAMENTO ) VALUES ( {FieldThreatment(this.GE407_NUM_PROPOSTA)} , {FieldThreatment(this.GE407_NUM_CERTIFICADO)} , {FieldThreatment(this.GE407_NUM_PARCELA)} , {FieldThreatment(this.GE407_NUM_APOLICE)} , {FieldThreatment(this.GE407_NUM_ENDOSSO)} , {FieldThreatment(this.GE407_SEQ_CONTROL_CARTAO)} , {FieldThreatment(this.GE407_COD_TP_PAGAMENTO)} , {FieldThreatment(this.GE407_COD_IDLG)} , {FieldThreatment(this.GE407_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE407_COD_PRODUTO)} , {FieldThreatment(this.GE407_DTA_VENCIMENTO)} , {FieldThreatment(this.GE407_DTA_MOVIMENTO)} , {FieldThreatment(this.GE407_VLR_TOT_PREMIO)} , {FieldThreatment(this.GE407_COD_SISTEMA)} , {FieldThreatment(this.GE407_COD_USUARIO)} , {FieldThreatment(this.GE407_STA_REGISTRO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE407_NUM_PROPOSTA { get; set; }
        public string GE407_NUM_CERTIFICADO { get; set; }
        public string GE407_NUM_PARCELA { get; set; }
        public string GE407_NUM_APOLICE { get; set; }
        public string GE407_NUM_ENDOSSO { get; set; }
        public string GE407_SEQ_CONTROL_CARTAO { get; set; }
        public string GE407_COD_TP_PAGAMENTO { get; set; }
        public string GE407_COD_IDLG { get; set; }
        public string GE407_NUM_OCORR_MOVTO { get; set; }
        public string GE407_COD_PRODUTO { get; set; }
        public string GE407_DTA_VENCIMENTO { get; set; }
        public string GE407_DTA_MOVIMENTO { get; set; }
        public string GE407_VLR_TOT_PREMIO { get; set; }
        public string GE407_COD_SISTEMA { get; set; }
        public string GE407_COD_USUARIO { get; set; }
        public string GE407_STA_REGISTRO { get; set; }

        public static void Execute(R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1 r0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1)
        {
            var ths = r0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}