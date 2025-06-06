using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            DTMOVABE + 1 DAYS ,
            DTMOVABE + 2 DAYS ,
            DTMOVABE + 3 DAYS ,
            DTMOVABE + 4 DAYS ,
            DTMOVABE - 10 DAYS ,
            DTMOVABE - 11 DAYS ,
            DTMOVABE - 12 DAYS ,
            DTMOVABE - 13 DAYS ,
            DTMOVABE - 14 DAYS ,
            DTMOVABE - 30 DAYS
            INTO :V1SIST-DTMOVABE ,
            :V1SIST-DTMOVABE-1,
            :V1SIST-DTMOVABE-2,
            :V1SIST-DTMOVABE-3,
            :V1SIST-DTMOVABE-4,
            :V1SIST-DTMOVABE-10,
            :V1SIST-DTMOVABE-11,
            :V1SIST-DTMOVABE-12,
            :V1SIST-DTMOVABE-13,
            :V1SIST-DTMOVABE-14,
            :V1SIST-DTMOVABE-30
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											DTMOVABE + 1 DAYS 
							,
											DTMOVABE + 2 DAYS 
							,
											DTMOVABE + 3 DAYS 
							,
											DTMOVABE + 4 DAYS 
							,
											DTMOVABE - 10 DAYS 
							,
											DTMOVABE - 11 DAYS 
							,
											DTMOVABE - 12 DAYS 
							,
											DTMOVABE - 13 DAYS 
							,
											DTMOVABE - 14 DAYS 
							,
											DTMOVABE - 30 DAYS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTMOVABE_1 { get; set; }
        public string V1SIST_DTMOVABE_2 { get; set; }
        public string V1SIST_DTMOVABE_3 { get; set; }
        public string V1SIST_DTMOVABE_4 { get; set; }
        public string V1SIST_DTMOVABE_10 { get; set; }
        public string V1SIST_DTMOVABE_11 { get; set; }
        public string V1SIST_DTMOVABE_12 { get; set; }
        public string V1SIST_DTMOVABE_13 { get; set; }
        public string V1SIST_DTMOVABE_14 { get; set; }
        public string V1SIST_DTMOVABE_30 { get; set; }

        public static R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_1 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_2 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_3 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_4 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_10 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_11 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_12 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_13 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_14 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_30 = result[i++].Value?.ToString();
            return dta;
        }

    }
}