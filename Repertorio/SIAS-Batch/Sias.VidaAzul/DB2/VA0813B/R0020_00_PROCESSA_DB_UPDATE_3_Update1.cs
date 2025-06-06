using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0020_00_PROCESSA_DB_UPDATE_3_Update1 : QueryBasis<R0020_00_PROCESSA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET SITUACAO =  '{this.V0HCTA_SITUACAO}',
				PRMVG =  '{this.V0PARC_PRMVG}',
				PRMAP =  '{this.V0PARC_PRMAP}',
				OPCAOOPAG =  '{this.V0PARC_OPCAOPAG}'
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCTA_NRPARCEL}'";

            return query;
        }
        public string V0HCTA_SITUACAO { get; set; }
        public string V0PARC_OPCAOPAG { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static void Execute(R0020_00_PROCESSA_DB_UPDATE_3_Update1 r0020_00_PROCESSA_DB_UPDATE_3_Update1)
        {
            var ths = r0020_00_PROCESSA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0020_00_PROCESSA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}