using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE
            INTO :V1SISTEMA-DTMOVABE,
            :V1SISTEMA-CURRDATE
            FROM SEGUROS.V1SISTEMA
            WHERE
            IDSISTEM = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE
											IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string V1SISTEMA_DTMOVABE { get; set; }
        public string V1SISTEMA_CURRDATE { get; set; }

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
            dta.V1SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SISTEMA_CURRDATE = result[i++].Value?.ToString();
            return dta;
        }

    }
}