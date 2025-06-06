using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0111B
{
    public class R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1 : QueryBasis<R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO =  '{this.HISLANCT_SIT_REGISTRO}'
				, NSAS =  {FieldThreatment((this.VIND_NSAS?.ToInt() == -1 ? null : $"{this.HISLANCT_NSAS}"))}
				, NSL =  {FieldThreatment((this.VIND_NSL?.ToInt() == -1 ? null : $"{this.HISLANCT_NSL}"))}
				WHERE  NUM_CERTIFICADO =  '{this.HISLANCT_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.HISLANCT_NUM_PARCELA}'
				AND SIT_REGISTRO = '0'
				AND TIPLANC = '2'";

            return query;
        }
        public string HISLANCT_NSAS { get; set; }
        public string VIND_NSAS { get; set; }
        public string HISLANCT_NSL { get; set; }
        public string VIND_NSL { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }

        public static void Execute(R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1 r0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1)
        {
            var ths = r0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}