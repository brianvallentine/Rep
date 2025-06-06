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
    public class Execute_DB_SELECT_4_Query1 : QueryBasis<Execute_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLOPER, VLIOCC
            INTO :VLOPER-W, :VLIOCC-W
            FROM SEGUROS.V0SALCONTABAZ
            WHERE DTMOVTO = :DTMOVTO
            AND CODPRODAZ = :CODPRODAZ
            AND CODOPER = :CODOPER
            AND NUM_FATURA IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLOPER
							, VLIOCC
											FROM SEGUROS.V0SALCONTABAZ
											WHERE DTMOVTO = '{this.DTMOVTO}'
											AND CODPRODAZ = '{this.CODPRODAZ}'
											AND CODOPER = '{this.CODOPER}'
											AND NUM_FATURA IS NULL";

            return query;
        }
        public string VLOPER_W { get; set; }
        public string VLIOCC_W { get; set; }
        public string CODPRODAZ { get; set; }
        public string DTMOVTO { get; set; }
        public string CODOPER { get; set; }

        public static Execute_DB_SELECT_4_Query1 Execute(Execute_DB_SELECT_4_Query1 execute_DB_SELECT_4_Query1)
        {
            var ths = execute_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_4_Query1();
            var i = 0;
            dta.VLOPER_W = result[i++].Value?.ToString();
            dta.VLIOCC_W = result[i++].Value?.ToString();
            return dta;
        }

    }
}