using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET SITUACAO =
				 '{this.BILHETE_SITUACAO}'
				WHERE  NUM_BILHETE =
				 '{this.BILHETE_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}