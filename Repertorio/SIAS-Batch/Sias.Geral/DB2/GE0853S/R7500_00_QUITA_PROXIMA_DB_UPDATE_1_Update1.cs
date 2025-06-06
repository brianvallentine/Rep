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
    public class R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1 : QueryBasis<R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET SITUACAO = '2'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HISC_NRPARCEL}'";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }

        public static void Execute(R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1 r7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1)
        {
            var ths = r7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}