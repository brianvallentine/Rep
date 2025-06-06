using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R2850_00_UPDATE_V0HISTCOBVA_Update1 : QueryBasis<R2850_00_UPDATE_V0HISTCOBVA_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET SITUACAO = '0'
				WHERE NRCERTIF =  '{this.WHOST_NRCERTIF}'
				AND NRPARCEL =  '{this.WHOST_NRPARCEL}'
				AND NRTIT =  '{this.WHOST_NRTIT}'";

            return query;
        }
        public string WHOST_NRCERTIF { get; set; }
        public string WHOST_NRPARCEL { get; set; }
        public string WHOST_NRTIT { get; set; }

        public static void Execute(R2850_00_UPDATE_V0HISTCOBVA_Update1 r2850_00_UPDATE_V0HISTCOBVA_Update1)
        {
            var ths = r2850_00_UPDATE_V0HISTCOBVA_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2850_00_UPDATE_V0HISTCOBVA_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}