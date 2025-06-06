using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0101S
{
    public class Execute_DB_SELECT_2_Query1 : QueryBasis<Execute_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA,
            DATA_REFERENCIA + 1 MONTH
            INTO :DTREF,
            :DTREF2
            FROM SEGUROS.V0FATURCONT
            WHERE NUM_APOLICE = 97010000889
            AND COD_SUBGRUPO = :CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
							,
											DATA_REFERENCIA + 1 MONTH
											FROM SEGUROS.V0FATURCONT
											WHERE NUM_APOLICE = 97010000889
											AND COD_SUBGRUPO = '{this.CODSUBES}'";

            return query;
        }
        public string DTREF { get; set; }
        public string DTREF2 { get; set; }
        public string CODSUBES { get; set; }

        public static Execute_DB_SELECT_2_Query1 Execute(Execute_DB_SELECT_2_Query1 execute_DB_SELECT_2_Query1)
        {
            var ths = execute_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_2_Query1();
            var i = 0;
            dta.DTREF = result[i++].Value?.ToString();
            dta.DTREF2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}