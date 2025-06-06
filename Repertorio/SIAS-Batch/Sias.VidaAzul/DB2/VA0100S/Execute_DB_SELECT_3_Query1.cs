using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0100S
{
    public class Execute_DB_SELECT_3_Query1 : QueryBasis<Execute_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCIOF
            INTO :PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :RAMO
            AND DTINIVIG <= :DTINIVIG
            AND DTTERVIG >= :DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.RAMO}'
											AND DTINIVIG <= '{this.DTINIVIG}'
											AND DTTERVIG >= '{this.DTINIVIG}'";

            return query;
        }
        public string PCIOF { get; set; }
        public string DTINIVIG { get; set; }
        public string RAMO { get; set; }

        public static Execute_DB_SELECT_3_Query1 Execute(Execute_DB_SELECT_3_Query1 execute_DB_SELECT_3_Query1)
        {
            var ths = execute_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_3_Query1();
            var i = 0;
            dta.PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}