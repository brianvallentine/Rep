using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0108B
{
    public class M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDSISTEM, DTMOVABE, CURRENT DATE
            INTO :TSISTEM-IDSISTEM, :TSISTEM-DTMOVABE, :TSISTEM-DTCURRENT
            FROM SEGUROS.V1SISTEMA
            WHERE
            IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDSISTEM
							, DTMOVABE
							, CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE
											IDSISTEM = 'SI'";

            return query;
        }
        public string TSISTEM_IDSISTEM { get; set; }
        public string TSISTEM_DTMOVABE { get; set; }
        public string TSISTEM_DTCURRENT { get; set; }

        public static M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 Execute(M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.TSISTEM_IDSISTEM = result[i++].Value?.ToString();
            dta.TSISTEM_DTMOVABE = result[i++].Value?.ToString();
            dta.TSISTEM_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}