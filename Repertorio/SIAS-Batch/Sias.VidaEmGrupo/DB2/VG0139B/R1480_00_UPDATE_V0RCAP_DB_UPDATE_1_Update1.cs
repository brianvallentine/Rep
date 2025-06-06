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
    public class R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 : QueryBasis<R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET NRENDOS =  '{this.V0ENDO_NRENDOS}'
				WHERE  NRTIT =  '{this.V0HCTB_NRTIT}'";

            return query;
        }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0HCTB_NRTIT { get; set; }

        public static void Execute(R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}