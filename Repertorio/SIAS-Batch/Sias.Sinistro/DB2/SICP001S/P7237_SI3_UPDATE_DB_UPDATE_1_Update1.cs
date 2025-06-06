using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7237_SI3_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<P7237_SI3_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SI_MOVTO_PGTO_COB
				SET
				NUM_ID_ENVIO =
				 {FieldThreatment((this.WH_ID_ENVIO_NULL?.ToInt() == -1 ? null : $"{this.SI237_NUM_ID_ENVIO}"))}
				,SEQ_ID_ENVIO_HIST =
				 {FieldThreatment((this.WH_ID_ENVIO_HIST_NULL?.ToInt() == -1 ? null : $"{this.SI237_SEQ_ID_ENVIO_HIST}"))}
				,STA_ENVIO_MOVIMENTO =
				 '{this.SI237_STA_ENVIO_MOVIMENTO}'
				,DTA_SI_RETORNO_H =
				 {FieldThreatment((this.WH_SI_RETORNO_H_NULL?.ToInt() == -1 ? null : $"{this.SI237_DTA_SI_RETORNO_H}"))}
				,DTA_SI_ENVIO =
				 {FieldThreatment((this.WH_SI_ENVIO_NULL?.ToInt() == -1 ? null : $"{this.SI237_DTA_SI_ENVIO}"))}
				,DTA_EFETIVO_PGTO =
				 {FieldThreatment((this.WH_EFETIVO_PGTO_NULL?.ToInt() == -1 ? null : $"{this.SI237_DTA_EFETIVO_PGTO}"))}
				,COD_USUARIO =  '{this.SINISHIS_COD_USUARIO}'
				,COD_PROGRAMA =  '{this.GE420_NOM_PROGRAMA}'
				,DTH_CADASTRAMENTO = CURRENT TIMESTAMP
				WHERE  NUM_SINISTRO =  '{this.SI237_NUM_SINISTRO}'
				AND COD_OPERACAO =  '{this.SI237_COD_OPERACAO}'
				AND OCORR_HISTORICO =  '{this.SI237_OCORR_HISTORICO}'";

            return query;
        }
        public string SI237_SEQ_ID_ENVIO_HIST { get; set; }
        public string WH_ID_ENVIO_HIST_NULL { get; set; }
        public string SI237_DTA_SI_RETORNO_H { get; set; }
        public string WH_SI_RETORNO_H_NULL { get; set; }
        public string SI237_DTA_EFETIVO_PGTO { get; set; }
        public string WH_EFETIVO_PGTO_NULL { get; set; }
        public string SI237_NUM_ID_ENVIO { get; set; }
        public string WH_ID_ENVIO_NULL { get; set; }
        public string SI237_DTA_SI_ENVIO { get; set; }
        public string WH_SI_ENVIO_NULL { get; set; }
        public string SI237_STA_ENVIO_MOVIMENTO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string GE420_NOM_PROGRAMA { get; set; }
        public string SI237_OCORR_HISTORICO { get; set; }
        public string SI237_NUM_SINISTRO { get; set; }
        public string SI237_COD_OPERACAO { get; set; }

        public static void Execute(P7237_SI3_UPDATE_DB_UPDATE_1_Update1 p7237_SI3_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = p7237_SI3_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7237_SI3_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}