using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTCDG
            INTO :V0CDGC-VLCUSTCDG
            FROM SEGUROS.V0CDGCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTCDG
											FROM SEGUROS.V0CDGCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0CDGC_VLCUSTCDG { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 Execute(R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CDGC_VLCUSTCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}