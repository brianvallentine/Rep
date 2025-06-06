using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1 : QueryBasis<R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE NUM_NOSSO_TITULO >= :WSHOST-NUMSIV01
            AND NUM_NOSSO_TITULO <= :WSHOST-NUMSIV02
            AND SIT_REGISTRO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE NUM_NOSSO_TITULO >= '{this.WSHOST_NUMSIV01}'
											AND NUM_NOSSO_TITULO <= '{this.WSHOST_NUMSIV02}'
											AND SIT_REGISTRO = '1'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string WSHOST_NUMSIV01 { get; set; }
        public string WSHOST_NUMSIV02 { get; set; }

        public static R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1 Execute(R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1 r0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1)
        {
            var ths = r0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}