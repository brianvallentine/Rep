using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0106B
{
    public class M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE, CURRENT DATE
            INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VP'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							, CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VP'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTCURRENT { get; set; }

        public static M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1 Execute(M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1 m_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}