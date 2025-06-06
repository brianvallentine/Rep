using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0850B
{
    public class R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1 : QueryBasis<R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static void Execute(R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1 r1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1)
        {
            var ths = r1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}