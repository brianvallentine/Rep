using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE ,
            CURRENT DATE,
            CURRENT DATE + 1 DAY
            INTO :SIST-DTMOVABE,
            :SIST-CURRDATE,
            :SIST-DTMINDEB
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE 
							,
											CURRENT DATE
							,
											CURRENT DATE + 1 DAY
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string SIST_DTMOVABE { get; set; }
        public string SIST_CURRDATE { get; set; }
        public string SIST_DTMINDEB { get; set; }

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
            dta.SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.SIST_CURRDATE = result[i++].Value?.ToString();
            dta.SIST_DTMINDEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}