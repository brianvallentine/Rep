using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0073B
{
    public class R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :MOVIMCOB-SIT-REGISTRO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE NUM_NOSSO_TITULO =
            :MOVIMCOB-NUM-NOSSO-TITULO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE NUM_NOSSO_TITULO =
											'{this.MOVIMCOB_NUM_NOSSO_TITULO}'
											WITH UR";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }

        public static R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 Execute(R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 r3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}