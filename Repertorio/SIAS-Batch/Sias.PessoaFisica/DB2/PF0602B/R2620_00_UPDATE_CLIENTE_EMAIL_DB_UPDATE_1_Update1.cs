using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1 : QueryBasis<R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTE_EMAIL
				SET EMAIL =  '{this.CLIENEMA_EMAIL}'
				WHERE  COD_CLIENTE =  '{this.CLIENEMA_COD_CLIENTE}'
				AND SEQ_EMAIL =  '{this.CLIENEMA_SEQ_EMAIL}'";

            return query;
        }
        public string CLIENEMA_EMAIL { get; set; }
        public string CLIENEMA_COD_CLIENTE { get; set; }
        public string CLIENEMA_SEQ_EMAIL { get; set; }

        public static void Execute(R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1 r2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1)
        {
            var ths = r2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}