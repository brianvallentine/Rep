using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE + 20 DAYS,
            CURRENT DATE + 1 DAY,
            DTMOVABE,
            DTMOVABE - 1 MONTH
            INTO :V1SIST-DTVENFIM-CN,
            :V1SIST-DTVENFIM-DB,
            :V1SIST-DTMOVABE,
            :V1SIST-DTTERCOT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE + 20 DAYS
							,
											CURRENT DATE + 1 DAY
							,
											DTMOVABE
							,
											DTMOVABE - 1 MONTH
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'";

            return query;
        }
        public string V1SIST_DTVENFIM_CN { get; set; }
        public string V1SIST_DTVENFIM_DB { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTTERCOT { get; set; }

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
            dta.V1SIST_DTVENFIM_CN = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_DB = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTTERCOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}