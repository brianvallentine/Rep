using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1 : QueryBasis<R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTCDG,
            DTINIVIG,
            DTTERVIG
            INTO :V0CDGC-VLCUSTCDG,
            :V0CDGC-DTINIVIG,
            :V0CDGC-DTTERVIG
            FROM SEGUROS.V0CDGCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTINIVIG <= :HOST-DTINIVIG
            AND DTTERVIG >= :HOST-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTCDG
							,
											DTINIVIG
							,
											DTTERVIG
											FROM SEGUROS.V0CDGCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTINIVIG <= '{this.HOST_DTINIVIG}'
											AND DTTERVIG >= '{this.HOST_DTINIVIG}'";

            return query;
        }
        public string V0CDGC_VLCUSTCDG { get; set; }
        public string V0CDGC_DTINIVIG { get; set; }
        public string V0CDGC_DTTERVIG { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string HOST_DTINIVIG { get; set; }

        public static R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1 Execute(R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1 r0800_00_VERIFICA_CDG_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_VERIFICA_CDG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CDGC_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0CDGC_DTINIVIG = result[i++].Value?.ToString();
            dta.V0CDGC_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}