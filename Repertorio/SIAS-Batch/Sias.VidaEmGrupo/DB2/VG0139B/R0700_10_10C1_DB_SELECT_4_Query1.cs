using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_10_10C1_DB_SELECT_4_Query1 : QueryBasis<R0700_10_10C1_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE (:V0ENDO-DTTERVIG),
            DATE (:V0ENDO-DTTERVIG) +
            :V0OPCP-PERIPGTO MONTHS
            INTO :V0ENDO-DTINIVIG ,
            :V0ENDO-DTTERVIG
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE ('{this.V0ENDO_DTTERVIG}')
							,
											DATE ('{this.V0ENDO_DTTERVIG}') +
											{this.V0OPCP_PERIPGTO} MONTHS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }

        public static R0700_10_10C1_DB_SELECT_4_Query1 Execute(R0700_10_10C1_DB_SELECT_4_Query1 r0700_10_10C1_DB_SELECT_4_Query1)
        {
            var ths = r0700_10_10C1_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_10_10C1_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_10_10C1_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}