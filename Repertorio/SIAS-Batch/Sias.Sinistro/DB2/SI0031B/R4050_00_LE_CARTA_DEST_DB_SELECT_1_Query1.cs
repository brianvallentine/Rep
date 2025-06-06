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
    public class R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1 : QueryBasis<R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_DESTINATARIO
            INTO :GERECADE-COD-DESTINATARIO
            FROM SEGUROS.GE_REL_CARTA_DEST
            WHERE NUM_CARTA = :WS-CARTA-ANT
            AND IND_DEST_PRINC = 'S'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_DESTINATARIO
											FROM SEGUROS.GE_REL_CARTA_DEST
											WHERE NUM_CARTA = '{this.WS_CARTA_ANT}'
											AND IND_DEST_PRINC = 'S'";

            return query;
        }
        public string GERECADE_COD_DESTINATARIO { get; set; }
        public string WS_CARTA_ANT { get; set; }

        public static R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1 Execute(R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1 r4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1)
        {
            var ths = r4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1();
            var i = 0;
            dta.GERECADE_COD_DESTINATARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}