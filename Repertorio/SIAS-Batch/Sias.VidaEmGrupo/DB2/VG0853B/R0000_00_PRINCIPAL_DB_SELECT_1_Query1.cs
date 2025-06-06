using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE + 15 DAYS,
            DTMOVABE + 08 DAY ,
            CURRENT DATE + 01 DAY ,
            CURRENT DATE + 23 DAYS,
            DTMOVABE ,
            DTMOVABE - 1 MONTH
            INTO :V1SIST-DT-15 ,
            :V1SIST-DT-08 ,
            :V1SIST-DTVENFIM-DB ,
            :V1SIST-DT-23-CYRELA ,
            :V1SIST-DTMOVABE ,
            :V1SIST-DTTERCOT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE + 15 DAYS
							,
											DTMOVABE + 08 DAY 
							,
											CURRENT DATE + 01 DAY 
							,
											CURRENT DATE + 23 DAYS
							,
											DTMOVABE 
							,
											DTMOVABE - 1 MONTH
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string V1SIST_DT_15 { get; set; }
        public string V1SIST_DT_08 { get; set; }
        public string V1SIST_DTVENFIM_DB { get; set; }
        public string V1SIST_DT_23_CYRELA { get; set; }
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
            dta.V1SIST_DT_15 = result[i++].Value?.ToString();
            dta.V1SIST_DT_08 = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_DB = result[i++].Value?.ToString();
            dta.V1SIST_DT_23_CYRELA = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTTERCOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}