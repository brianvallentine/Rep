using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1 : QueryBasis<R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TEXTO_CARTA
            INTO :GECARTEX-TEXTO-CARTA
            FROM SEGUROS.GE_CARTA_TEXTO
            WHERE NUM_CARTA = :WS-CARTA-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TEXTO_CARTA
											FROM SEGUROS.GE_CARTA_TEXTO
											WHERE NUM_CARTA = '{this.WS_CARTA_ANT}'";

            return query;
        }
        public string GECARTEX_TEXTO_CARTA { get; set; }
        public string WS_CARTA_ANT { get; set; }

        public static R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1 Execute(R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1 r4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1)
        {
            var ths = r4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARTEX_TEXTO_CARTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}