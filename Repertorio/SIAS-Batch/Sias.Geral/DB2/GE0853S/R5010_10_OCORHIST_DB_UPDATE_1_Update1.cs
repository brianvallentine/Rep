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
    public class R5010_10_OCORHIST_DB_UPDATE_1_Update1 : QueryBasis<R5010_10_OCORHIST_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET PRMVG =  '{this.WHOST_PRMVG}',
				PRMAP =  '{this.WHOST_PRMAP}',
				OCORHIST =  '{this.V0PARC_OCORHIST}'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HISC_NRPARCEL}'";

            return query;
        }
        public string V0PARC_OCORHIST { get; set; }
        public string WHOST_PRMVG { get; set; }
        public string WHOST_PRMAP { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }

        public static void Execute(R5010_10_OCORHIST_DB_UPDATE_1_Update1 r5010_10_OCORHIST_DB_UPDATE_1_Update1)
        {
            var ths = r5010_10_OCORHIST_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5010_10_OCORHIST_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}