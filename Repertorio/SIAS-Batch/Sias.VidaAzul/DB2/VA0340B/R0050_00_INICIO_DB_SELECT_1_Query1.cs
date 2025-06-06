using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R0050_00_INICIO_DB_SELECT_1_Query1 : QueryBasis<R0050_00_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            DTMOVABE + 1 DAY,
            DTMOVABE
            INTO :SIST-CURRDATE,
            :SIST-DTMINDEB,
            :SIST-DTMOVABE
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM= 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											DTMOVABE + 1 DAY
							,
											DTMOVABE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM= 'VA'";

            return query;
        }
        public string SIST_CURRDATE { get; set; }
        public string SIST_DTMINDEB { get; set; }
        public string SIST_DTMOVABE { get; set; }

        public static R0050_00_INICIO_DB_SELECT_1_Query1 Execute(R0050_00_INICIO_DB_SELECT_1_Query1 r0050_00_INICIO_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIST_CURRDATE = result[i++].Value?.ToString();
            dta.SIST_DTMINDEB = result[i++].Value?.ToString();
            dta.SIST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}