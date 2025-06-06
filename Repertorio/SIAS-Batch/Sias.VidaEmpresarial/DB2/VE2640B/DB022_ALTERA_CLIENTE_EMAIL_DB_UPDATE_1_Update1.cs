using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1 : QueryBasis<DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTE_EMAIL
				SET EMAIL =  '{this.CLIENEMA_EMAIL}'
				WHERE  COD_CLIENTE =  '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENEMA_EMAIL { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static void Execute(DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1 dB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1)
        {
            var ths = dB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}