using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_10_10C1_DB_UPDATE_1_Update1 : QueryBasis<R0700_10_10C1_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0OPCAOPAGVA
				SET DTINIVIG =  '{this.V0PARC_DTVENCTO}'
				WHERE  NRCERTIF =  '{this.V0HCTB_NRCERTIF}'
				AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }

        public static void Execute(R0700_10_10C1_DB_UPDATE_1_Update1 r0700_10_10C1_DB_UPDATE_1_Update1)
        {
            var ths = r0700_10_10C1_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0700_10_10C1_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}