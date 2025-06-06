using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R3000_10_CONTINUA_DB_UPDATE_2_Update1 : QueryBasis<R3000_10_CONTINUA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_OUTROS
				SET CODANGAR = CODANGAR
				+ 1
				WHERE  CODANGAR =  '{this.V1NOUT_CODANGAR}'";

            return query;
        }
        public string V1NOUT_CODANGAR { get; set; }

        public static void Execute(R3000_10_CONTINUA_DB_UPDATE_2_Update1 r3000_10_CONTINUA_DB_UPDATE_2_Update1)
        {
            var ths = r3000_10_CONTINUA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_10_CONTINUA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}