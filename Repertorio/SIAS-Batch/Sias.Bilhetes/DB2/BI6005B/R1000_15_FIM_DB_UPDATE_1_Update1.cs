using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1000_15_FIM_DB_UPDATE_1_Update1 : QueryBasis<R1000_15_FIM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_OUTROS
				SET NUMOPG =  '{this.V1NOUT_NUMOPG}'
				WHERE  NUMOPG > 0";

            return query;
        }
        public string V1NOUT_NUMOPG { get; set; }

        public static void Execute(R1000_15_FIM_DB_UPDATE_1_Update1 r1000_15_FIM_DB_UPDATE_1_Update1)
        {
            var ths = r1000_15_FIM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_15_FIM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}