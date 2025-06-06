using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTTEXTOS
{
    public class R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1 : QueryBasis<R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CARTA_TEXTO
				SET TEXTO_CARTA =  '{this.GECARTEX_TEXTO_CARTA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CARTA =  '{this.GECARTEX_NUM_CARTA}'";

            return query;
        }
        public string GECARTEX_TEXTO_CARTA { get; set; }
        public string GECARTEX_NUM_CARTA { get; set; }

        public static void Execute(R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1 r2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1)
        {
            var ths = r2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}