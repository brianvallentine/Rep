using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R050_ALTERA_FONTES_DB_UPDATE_1_Update1 : QueryBasis<R050_ALTERA_FONTES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET NUM_PROTOCOLO_SINI =  '{this.FONTES_NUM_PROTOCOLO_SINI}'
				WHERE  COD_FONTE = 10";

            return query;
        }
        public string FONTES_NUM_PROTOCOLO_SINI { get; set; }

        public static void Execute(R050_ALTERA_FONTES_DB_UPDATE_1_Update1 r050_ALTERA_FONTES_DB_UPDATE_1_Update1)
        {
            var ths = r050_ALTERA_FONTES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R050_ALTERA_FONTES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}