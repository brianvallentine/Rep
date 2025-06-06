using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R1300_50_LOOP_DB_UPDATE_1_Update1 : QueryBasis<R1300_50_LOOP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PRODUTORVF
				SET OCORHIST =  '{this.V0PDTV_OCORHIST}'
				WHERE  CODPDT =  '{this.V0PLCO_CODPDT}'";

            return query;
        }
        public string V0PDTV_OCORHIST { get; set; }
        public string V0PLCO_CODPDT { get; set; }

        public static void Execute(R1300_50_LOOP_DB_UPDATE_1_Update1 r1300_50_LOOP_DB_UPDATE_1_Update1)
        {
            var ths = r1300_50_LOOP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_50_LOOP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}