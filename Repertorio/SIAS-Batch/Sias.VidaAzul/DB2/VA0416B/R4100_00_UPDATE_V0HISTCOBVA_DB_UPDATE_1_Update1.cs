using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0416B
{
    public class R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 : QueryBasis<R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET OCORHIST =  '{this.V0HCOB_OCORHIST}'
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCOB_NRPARCEL}'
				AND NRTIT =  '{this.V0HCOB_NRTIT}'";

            return query;
        }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }

        public static void Execute(R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 r4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1)
        {
            var ths = r4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}