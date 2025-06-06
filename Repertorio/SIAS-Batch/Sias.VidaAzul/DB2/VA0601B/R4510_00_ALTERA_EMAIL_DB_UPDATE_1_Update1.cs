using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 : QueryBasis<R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTE_EMAIL
				SET EMAIL =  '{this.WHOST_EMAIL}'
				WHERE  COD_CLIENTE =  '{this.WHOST_COD_CLIENTE}'";

            return query;
        }
        public string WHOST_EMAIL { get; set; }
        public string WHOST_COD_CLIENTE { get; set; }

        public static void Execute(R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 r4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1)
        {
            var ths = r4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}