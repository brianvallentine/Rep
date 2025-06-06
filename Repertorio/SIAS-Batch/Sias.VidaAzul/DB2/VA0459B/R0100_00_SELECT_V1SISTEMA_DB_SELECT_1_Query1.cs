using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0459B
{
    public class R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE ,
            DTMOVABE - 30 DAYS ,
            DTMOVABE - 45 DAYS
            INTO :V1SIST-DTMOVABE ,
            :V1SIST-DTMOVABE-30 ,
            :V1SIST-DTMOVABE-45
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE 
							,
											DTMOVABE - 30 DAYS 
							,
											DTMOVABE - 45 DAYS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTMOVABE_30 { get; set; }
        public string V1SIST_DTMOVABE_45 { get; set; }

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
            dta.V1SIST_DTMOVABE_30 = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_45 = result[i++].Value?.ToString();
            return dta;
        }

    }
}