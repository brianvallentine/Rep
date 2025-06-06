using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE ,
            DTMOVABE - 1 DAY,
            DTMOVABE + 1 DAY,
            CURRENT DATE
            INTO :V0SIST-DTMOVABE ,
            :V0SIST-DTMOVABE-1,
            :V0SIST-DTMOVABE-A1,
            :V0SIST-DTCURR
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE 
							,
											DTMOVABE - 1 DAY
							,
											DTMOVABE + 1 DAY
							,
											CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0SIST_DTMOVABE_1 { get; set; }
        public string V0SIST_DTMOVABE_A1 { get; set; }
        public string V0SIST_DTCURR { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_1_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_1_Query1 m_0000_PRINCIPAL_DB_SELECT_1_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V0SIST_DTMOVABE_1 = result[i++].Value?.ToString();
            dta.V0SIST_DTMOVABE_A1 = result[i++].Value?.ToString();
            dta.V0SIST_DTCURR = result[i++].Value?.ToString();
            return dta;
        }

    }
}