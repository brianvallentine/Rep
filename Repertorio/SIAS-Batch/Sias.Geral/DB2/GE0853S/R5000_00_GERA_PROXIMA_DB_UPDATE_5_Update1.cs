using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET DTVENCTO =  '{this.V0PROP_DTVENCTO}',
				DTPROXVEN =  '{this.V0PROP_DTPROXVEN}',
				NRPARCE =  '{this.V0PROP_NRPARCEL}',
				QTDPARATZ =  '{this.V0PROP_QTDPARATZ}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'";

            return query;
        }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static void Execute(R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1 r5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}