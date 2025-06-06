using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1 : QueryBasis<R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET OCORHIST =  '{this.V0PARC_OCORHIST}'
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0PARC_OCORHIST { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static void Execute(R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1 r1600_00_GERA_DEBITO_DB_UPDATE_1_Update1)
        {
            var ths = r1600_00_GERA_DEBITO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_GERA_DEBITO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}