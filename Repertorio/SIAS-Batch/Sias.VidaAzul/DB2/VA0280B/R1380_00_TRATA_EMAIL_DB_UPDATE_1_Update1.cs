using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1 : QueryBasis<R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_EMAIL
				SET EMAIL =  '{this.EMAIL}'
				WHERE COD_PESSOA =  '{this.PROPOVA_COD_CLIENTE}'";

            return query;
        }
        public string EMAIL { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static void Execute(R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1 r1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1)
        {
            var ths = r1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}