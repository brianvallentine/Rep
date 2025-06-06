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
    public class R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1 : QueryBasis<R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CONTROLE_ARQH
            ( NUM_OCORR_MOVTO
            , SEQ_RETORNO_MOVIMENTO
            , DTA_MOVIMENTO
            , NUM_ESTRUTURA_ARQH
            , STA_COMPENSACAO
            , NUM_NSAS_ARQH
            , IND_MOTIVO_COMPENSACAO
            , COD_FATURA_SAP
            , NUM_ITEM_FATURA
            , NUM_NSAS_BANCO
            , DTH_CADASTRAMENTO
            )
            VALUES ( :GE105-NUM-OCORR-MOVTO
            , :GE105-SEQ-RETORNO-MOVIMENTO
            , :GE105-DTA-MOVIMENTO
            , :GE105-NUM-ESTRUTURA-ARQH
            , :GE105-STA-COMPENSACAO
            , :GE105-NUM-NSAS-ARQH
            , :GE105-IND-MOTIVO-COMPENSACAO
            , :GE105-COD-FATURA-SAP
            , :GE105-NUM-ITEM-FATURA
            , :GE105-NUM-NSAS-BANCO
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CONTROLE_ARQH ( NUM_OCORR_MOVTO , SEQ_RETORNO_MOVIMENTO , DTA_MOVIMENTO , NUM_ESTRUTURA_ARQH , STA_COMPENSACAO , NUM_NSAS_ARQH , IND_MOTIVO_COMPENSACAO , COD_FATURA_SAP , NUM_ITEM_FATURA , NUM_NSAS_BANCO , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.GE105_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE105_SEQ_RETORNO_MOVIMENTO)} , {FieldThreatment(this.GE105_DTA_MOVIMENTO)} , {FieldThreatment(this.GE105_NUM_ESTRUTURA_ARQH)} , {FieldThreatment(this.GE105_STA_COMPENSACAO)} , {FieldThreatment(this.GE105_NUM_NSAS_ARQH)} , {FieldThreatment(this.GE105_IND_MOTIVO_COMPENSACAO)} , {FieldThreatment(this.GE105_COD_FATURA_SAP)} , {FieldThreatment(this.GE105_NUM_ITEM_FATURA)} , {FieldThreatment(this.GE105_NUM_NSAS_BANCO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE105_NUM_OCORR_MOVTO { get; set; }
        public string GE105_SEQ_RETORNO_MOVIMENTO { get; set; }
        public string GE105_DTA_MOVIMENTO { get; set; }
        public string GE105_NUM_ESTRUTURA_ARQH { get; set; }
        public string GE105_STA_COMPENSACAO { get; set; }
        public string GE105_NUM_NSAS_ARQH { get; set; }
        public string GE105_IND_MOTIVO_COMPENSACAO { get; set; }
        public string GE105_COD_FATURA_SAP { get; set; }
        public string GE105_NUM_ITEM_FATURA { get; set; }
        public string GE105_NUM_NSAS_BANCO { get; set; }

        public static void Execute(R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1 r0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1)
        {
            var ths = r0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}