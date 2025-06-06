using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE + 15 DAYS,
            CURRENT DATE + 1 DAY,
            CURRENT DATE + 15 DAYS,
            CURRENT DATE + 15 DAYS + 2 MONTHS,
            DTMOVABE
            INTO :V1SIST-DTCORMAISQD,
            :V1SIST-DTCORMAIS1D,
            :V1SIST-DTCORMAIS1M,
            :V1SIST-DTCORMAIS3M,
            :V1SIST-DTMOVABE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VF'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE + 15 DAYS
							,
											CURRENT DATE + 1 DAY
							,
											CURRENT DATE + 15 DAYS
							,
											CURRENT DATE + 15 DAYS + 2 MONTHS
							,
											DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VF'";

            return query;
        }
        public string V1SIST_DTCORMAISQD { get; set; }
        public string V1SIST_DTCORMAIS1D { get; set; }
        public string V1SIST_DTCORMAIS1M { get; set; }
        public string V1SIST_DTCORMAIS3M { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_1_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_1_Query1 r0000_00_PRINCIPAL_DB_SELECT_1_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTCORMAISQD = result[i++].Value?.ToString();
            dta.V1SIST_DTCORMAIS1D = result[i++].Value?.ToString();
            dta.V1SIST_DTCORMAIS1M = result[i++].Value?.ToString();
            dta.V1SIST_DTCORMAIS3M = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}