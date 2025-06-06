using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0803B
{
    public class M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE, CURRENT DATE
            INTO :SIST-DTMOVABE, :SIST-DTCURRENT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							, CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'SI'";

            return query;
        }
        public string SIST_DTMOVABE { get; set; }
        public string SIST_DTCURRENT { get; set; }

        public static M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1 Execute(M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1 m_520_000_LER_TSISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_520_000_LER_TSISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_520_000_LER_TSISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.SIST_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}