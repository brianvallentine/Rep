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
    public class R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1 : QueryBasis<R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DTINIVIG), '9999-12-31' )
            INTO :WS-MAX-DTINIVIG
            FROM SEGUROS.LOTERICO01
            WHERE NUM_APOLICE = :V0APO-NUM-APOLICE
            AND COD_LOT_CEF = :V0LOT-COD-LOT-FENAL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DTINIVIG)
							, '9999-12-31' )
											FROM SEGUROS.LOTERICO01
											WHERE NUM_APOLICE = '{this.V0APO_NUM_APOLICE}'
											AND COD_LOT_CEF = '{this.V0LOT_COD_LOT_FENAL}'";

            return query;
        }
        public string WS_MAX_DTINIVIG { get; set; }
        public string V0LOT_COD_LOT_FENAL { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }

        public static R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1 Execute(R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1 r0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = r0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MAX_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}