using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6241B
{
    public class R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 : QueryBasis<R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CEDENTE
				SET NUM_TITULO =  '{this.CEDENTE_NUM_TITULO}'
				WHERE  COD_CEDENTE = 26";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }

        public static void Execute(R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1)
        {
            var ths = r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}