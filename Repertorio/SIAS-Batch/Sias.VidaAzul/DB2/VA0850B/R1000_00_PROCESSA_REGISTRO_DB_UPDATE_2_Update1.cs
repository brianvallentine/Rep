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
    public class R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET PRMVG =  '{this.V0PARC_PRMVGTOT}',
				PRMAP =  '{this.V0PARC_PRMAPTOT}'
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCOB_NRPARCELMAX}'";

            return query;
        }
        public string V0PARC_PRMVGTOT { get; set; }
        public string V0PARC_PRMAPTOT { get; set; }
        public string V0HCOB_NRPARCELMAX { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}