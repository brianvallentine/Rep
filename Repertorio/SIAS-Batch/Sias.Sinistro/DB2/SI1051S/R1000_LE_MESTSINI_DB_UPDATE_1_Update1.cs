using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1051S
{
    public class R1000_LE_MESTSINI_DB_UPDATE_1_Update1 : QueryBasis<R1000_LE_MESTSINI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_MESTRE
				SET OCORR_HISTORICO =  '{this.HOST_MAX_OCORR_HISTORICO}'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISMES_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string HOST_MAX_OCORR_HISTORICO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R1000_LE_MESTSINI_DB_UPDATE_1_Update1 r1000_LE_MESTSINI_DB_UPDATE_1_Update1)
        {
            var ths = r1000_LE_MESTSINI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_LE_MESTSINI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}