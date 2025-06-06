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
    public class R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 : QueryBasis<R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO =  '{this.HISLANCT_SIT_REGISTRO}'
				, NSAC =  '{this.HISLANCT_NSAC}'
				, OCORR_HISTORICO = OCORR_HISTORICO + 1
				, CODRET =  '{this.HISLANCT_CODRET}'
				, TIMESTAMP = CURRENT TIMESTAMP
				, COD_USUARIO = 'CB0124B'
				WHERE  CODCONV =  '{this.HISLANCT_CODCONV}'
				AND NSAS =  '{this.HISLANCT_NSAS}'
				AND NSL =  '{this.HISLANCT_NSL}'
				AND SIT_REGISTRO = '3'";

            return query;
        }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_CODRET { get; set; }
        public string HISLANCT_NSAC { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string HISLANCT_NSAS { get; set; }
        public string HISLANCT_NSL { get; set; }

        public static void Execute(R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 r6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1)
        {
            var ths = r6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}