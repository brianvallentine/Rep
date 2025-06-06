using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1 : QueryBasis<R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0CDGCOBER
				SET
				IMPSEGCDG =  '{this.HOST_IMPSEGCDC_NEW}',
				VLCUSTCDG =  '{this.HOST_VLCUSTCDG}'
				WHERE 
				CODCLIEN =  '{this.V0PROP_CODCLIEN}'
				AND DTINIVIG <=  '{this.HOST_DTINIVIG}'
				AND DTTERVIG >=  '{this.HOST_DTINIVIG}'";

            return query;
        }
        public string HOST_IMPSEGCDC_NEW { get; set; }
        public string HOST_VLCUSTCDG { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string HOST_DTINIVIG { get; set; }

        public static void Execute(R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1 r0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1)
        {
            var ths = r0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}