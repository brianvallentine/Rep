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
    public class R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '2'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HISC_NRPARCEL}'
				AND OCORRHISTCTA <  '{this.V0PARC_OCORHIST}'";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }
        public string V0PARC_OCORHIST { get; set; }

        public static void Execute(R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1 r5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}