using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            DTMOVABE ,
            DTMOVABE + 8 DAYS,
            DTMOVABE + 1 MONTH,
            DTMOVABE + 14 DAYS,
            DTMOVABE + 365 DAYS
            INTO :SISTEMA-DTMOVABE,
            :SISTEMA-CURRDATE,
            :SISTEMA-DTMOVABE2,
            :SISTEMA-DTMOVABE3,
            :SISTEMA-DTMOV015D,
            :SISTEMA-DTMOV365D
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											DTMOVABE 
							,
											DTMOVABE + 8 DAYS
							,
											DTMOVABE + 1 MONTH
							,
											DTMOVABE + 14 DAYS
							,
											DTMOVABE + 365 DAYS
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string SISTEMA_CURRDATE { get; set; }
        public string SISTEMA_DTMOVABE2 { get; set; }
        public string SISTEMA_DTMOVABE3 { get; set; }
        public string SISTEMA_DTMOV015D { get; set; }
        public string SISTEMA_DTMOV365D { get; set; }

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
            dta.SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            dta.SISTEMA_CURRDATE = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOVABE2 = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOVABE3 = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV015D = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV365D = result[i++].Value?.ToString();
            return dta;
        }

    }
}