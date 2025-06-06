using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_025_000_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_025_000_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V1SIST-DTMOVABE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'AC'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'AC'
											WITH UR";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }

        public static M_025_000_SISTEMA_DB_SELECT_1_Query1 Execute(M_025_000_SISTEMA_DB_SELECT_1_Query1 m_025_000_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_025_000_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_025_000_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_025_000_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}