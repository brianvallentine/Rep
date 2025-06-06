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
    public class Execute_DB_SELECT_1_Query1 : QueryBasis<Execute_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODSUBES,
            RAMO
            INTO :CODSUBES,
            :RAMO
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = 97010000889
            AND CODPRODAZ = :CODPRODAZ
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODSUBES
							,
											RAMO
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = 97010000889
											AND CODPRODAZ = '{this.CODPRODAZ}'";

            return query;
        }
        public string CODSUBES { get; set; }
        public string RAMO { get; set; }
        public string CODPRODAZ { get; set; }

        public static Execute_DB_SELECT_1_Query1 Execute(Execute_DB_SELECT_1_Query1 execute_DB_SELECT_1_Query1)
        {
            var ths = execute_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_1_Query1();
            var i = 0;
            dta.CODSUBES = result[i++].Value?.ToString();
            dta.RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}