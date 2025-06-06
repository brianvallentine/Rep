using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class M_072_000_LER_SINIITEM_DB_SELECT_1_Query1 : QueryBasis<M_072_000_LER_SINIITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SEGV-CLIENTE
            FROM SEGUROS.V1SINI_ITEM
            WHERE NUM_APOL_SINISTRO= :TMESTSIN-APOL-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V1SINI_ITEM
											WHERE NUM_APOL_SINISTRO= '{this.TMESTSIN_APOL_SINI}'";

            return query;
        }
        public string SEGV_CLIENTE { get; set; }
        public string TMESTSIN_APOL_SINI { get; set; }

        public static M_072_000_LER_SINIITEM_DB_SELECT_1_Query1 Execute(M_072_000_LER_SINIITEM_DB_SELECT_1_Query1 m_072_000_LER_SINIITEM_DB_SELECT_1_Query1)
        {
            var ths = m_072_000_LER_SINIITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_072_000_LER_SINIITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_072_000_LER_SINIITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGV_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}