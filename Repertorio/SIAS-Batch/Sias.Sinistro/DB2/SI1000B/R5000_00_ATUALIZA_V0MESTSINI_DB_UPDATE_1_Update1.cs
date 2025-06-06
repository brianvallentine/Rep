using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000B
{
    public class R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1 : QueryBasis<R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0MESTSINI
				SET
				OCORHIST =  '{this.V0HSIN_OCORHIST}'
				WHERE 
				NUM_APOL_SINISTRO =  '{this.V0HSIN_NUM_SINI}'";

            return query;
        }
        public string V0HSIN_OCORHIST { get; set; }
        public string V0HSIN_NUM_SINI { get; set; }

        public static void Execute(R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1 r5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1)
        {
            var ths = r5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}