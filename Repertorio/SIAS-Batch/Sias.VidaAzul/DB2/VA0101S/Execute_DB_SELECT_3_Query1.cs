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
    public class Execute_DB_SELECT_3_Query1 : QueryBasis<Execute_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_FATURA
            INTO :NUM-FATURA
            FROM SEGUROS.V0FATURAS
            WHERE NUM_APOLICE = 97010000889
            AND COD_SUBGRUPO = :CODSUBES
            AND NUM_FATURA = :NUM-FATURA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_FATURA
											FROM SEGUROS.V0FATURAS
											WHERE NUM_APOLICE = 97010000889
											AND COD_SUBGRUPO = '{this.CODSUBES}'
											AND NUM_FATURA = '{this.NUM_FATURA}'";

            return query;
        }
        public string NUM_FATURA { get; set; }
        public string CODSUBES { get; set; }

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
            dta.NUM_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}