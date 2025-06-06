using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE,
            DTMOVABE - 1 MONTH,
            DTMOVABE - 12 MONTH,
            DTMOVABE + 1 MONTH
            INTO :SISTEMA-DTMOVABE,
            :SISTEMA-CURRENT,
            :SISTEMA-DTTERCOT,
            :SISTEMA-DTINICOT,
            :SISTEMA-DTMOV01M
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
							,
											DTMOVABE - 1 MONTH
							,
											DTMOVABE - 12 MONTH
							,
											DTMOVABE + 1 MONTH
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string SISTEMA_CURRENT { get; set; }
        public string SISTEMA_DTTERCOT { get; set; }
        public string SISTEMA_DTINICOT { get; set; }
        public string SISTEMA_DTMOV01M { get; set; }

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
            dta.SISTEMA_CURRENT = result[i++].Value?.ToString();
            dta.SISTEMA_DTTERCOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTINICOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV01M = result[i++].Value?.ToString();
            return dta;
        }

    }
}