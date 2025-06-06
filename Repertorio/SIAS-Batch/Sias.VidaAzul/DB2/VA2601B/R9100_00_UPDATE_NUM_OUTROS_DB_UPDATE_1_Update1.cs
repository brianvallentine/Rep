using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 : QueryBasis<R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_OUTROS
				SET NUM_CLIENTE =  '{this.NUM_CLIENTE}'
				WHERE  1 = 1";

            return query;
        }
        public string NUM_CLIENTE { get; set; }

        public static void Execute(R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1)
        {
            var ths = r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}