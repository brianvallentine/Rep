using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R1502_00_LEITURA_DB_SELECT_1_Query1 : QueryBasis<R1502_00_LEITURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_CARTA_REITERA, 0)
            INTO :WHOST-CARTA-REITERA
            FROM SEGUROS.GE_CARTA
            WHERE NUM_CARTA = :WHOST-NUM-CARTA-REITERA
            AND STA_ENVIO_CARTA = 'S'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_CARTA_REITERA
							, 0)
											FROM SEGUROS.GE_CARTA
											WHERE NUM_CARTA = '{this.WHOST_NUM_CARTA_REITERA}'
											AND STA_ENVIO_CARTA = 'S'
											WITH UR";

            return query;
        }
        public string WHOST_CARTA_REITERA { get; set; }
        public string WHOST_NUM_CARTA_REITERA { get; set; }

        public static R1502_00_LEITURA_DB_SELECT_1_Query1 Execute(R1502_00_LEITURA_DB_SELECT_1_Query1 r1502_00_LEITURA_DB_SELECT_1_Query1)
        {
            var ths = r1502_00_LEITURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1502_00_LEITURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1502_00_LEITURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_CARTA_REITERA = result[i++].Value?.ToString();
            return dta;
        }

    }
}