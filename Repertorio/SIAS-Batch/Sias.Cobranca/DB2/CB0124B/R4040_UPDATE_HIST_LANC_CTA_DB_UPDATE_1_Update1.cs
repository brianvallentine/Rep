using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 : QueryBasis<R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO =  '{this.HISLANCT_SIT_REGISTRO}'
				, NSAC =  {FieldThreatment((this.VIND_NSAC?.ToInt() == -1 ? null : $"{this.HISLANCT_NSAC}"))}
				, OCORR_HISTORICO = OCORR_HISTORICO + 1
				, CODRET =  {FieldThreatment((this.VIND_COD_RET?.ToInt() == -1 ? null : $"{this.HISLANCT_CODRET}"))}
				, TIMESTAMP = CURRENT TIMESTAMP
				, COD_USUARIO = 'CB0124B'
				WHERE  NUM_CERTIFICADO =  '{this.HISLANCT_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISLANCT_NUM_PARCELA}'
				AND OCORR_HISTORICOCTA =  '{this.HISLANCT_OCORR_HISTORICOCTA}'
				AND SIT_REGISTRO IN ( '3' , 'A' )";

            return query;
        }
        public string HISLANCT_CODRET { get; set; }
        public string VIND_COD_RET { get; set; }
        public string HISLANCT_NSAC { get; set; }
        public string VIND_NSAC { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }

        public static void Execute(R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 r4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1)
        {
            var ths = r4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}