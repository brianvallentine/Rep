using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V0SISTEMA-DTMOVABE
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'SI'";

            return query;
        }
        public string V0SISTEMA_DTMOVABE { get; set; }

        public static M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1 Execute(M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1 m_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}