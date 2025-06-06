using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 : QueryBasis<R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO = '2'
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'
				AND OCORR_HISTORICOCTA <  '{this.PARCEVID_OCORR_HISTORICO}'
				AND TIPLANC = '2'
				AND CODCONV = 6090
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_OCORR_HISTORICO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static void Execute(R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 r3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1)
        {
            var ths = r3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}