using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1 : QueryBasis<R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(DTINIVIG) - 1 DAY
            INTO :LOTERI01-DTINIVIG
            FROM SEGUROS.LOTERICO01
            WHERE NUM_APOLICE = :V0APO-NUM-APOLICE
            AND COD_LOT_CEF = :V0LOT-COD-LOT-FENAL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MIN(DTINIVIG) - 1 DAY
											FROM SEGUROS.LOTERICO01
											WHERE NUM_APOLICE = '{this.V0APO_NUM_APOLICE}'
											AND COD_LOT_CEF = '{this.V0LOT_COD_LOT_FENAL}'";

            return query;
        }
        public string LOTERI01_DTINIVIG { get; set; }
        public string V0LOT_COD_LOT_FENAL { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }

        public static R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1 Execute(R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1 r0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1)
        {
            var ths = r0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTERI01_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}