using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE,
            CURRENT DATE + 1 DAY,
            CURRENT DATE + 15 DAYS,
            CURRENT DATE + 1 MONTH,
            CURRENT DATE + 2 MONTHS,
            CURRENT DATE + 1 DAY + 6 MONTHS
            INTO :SISTEMA-DTMOVABE,
            :SISTEMA-CURRDATE,
            :SISTEMA-DTACEITE,
            :SISTEMA-DTMOVA15D,
            :SISTEMA-DTMOVA01M,
            :SISTEMA-DTMOVA02M,
            :SISTEMA-DTINISAF
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VF'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
							,
											CURRENT DATE + 1 DAY
							,
											CURRENT DATE + 15 DAYS
							,
											CURRENT DATE + 1 MONTH
							,
											CURRENT DATE + 2 MONTHS
							,
											CURRENT DATE + 1 DAY + 6 MONTHS
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VF'";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string SISTEMA_CURRDATE { get; set; }
        public string SISTEMA_DTACEITE { get; set; }
        public string SISTEMA_DTMOVA15D { get; set; }
        public string SISTEMA_DTMOVA01M { get; set; }
        public string SISTEMA_DTMOVA02M { get; set; }
        public string SISTEMA_DTINISAF { get; set; }

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
            dta.SISTEMA_DTACEITE = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOVA15D = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOVA01M = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOVA02M = result[i++].Value?.ToString();
            dta.SISTEMA_DTINISAF = result[i++].Value?.ToString();
            return dta;
        }

    }
}