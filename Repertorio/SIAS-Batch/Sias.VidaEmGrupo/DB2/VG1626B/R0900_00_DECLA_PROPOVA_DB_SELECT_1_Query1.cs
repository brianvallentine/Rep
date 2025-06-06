using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(DTPROXVEN),DATE( '1999-12-31' ))
            INTO :WHOST-MIN-DTPROXVEN
            FROM SEGUROS.V0PROPOSTAVA
            WHERE SITUACAO IN ( '3' , '6' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(DTPROXVEN)
							,DATE( '1999-12-31' ))
											FROM SEGUROS.V0PROPOSTAVA
											WHERE SITUACAO IN ( '3' 
							, '6' )";

            return query;
        }
        public string WHOST_MIN_DTPROXVEN { get; set; }

        public static R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1 Execute(R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1 r0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_MIN_DTPROXVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}