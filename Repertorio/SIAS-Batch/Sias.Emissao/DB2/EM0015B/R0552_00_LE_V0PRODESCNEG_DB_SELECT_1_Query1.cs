using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1 : QueryBasis<R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_MATRICULA
            INTO
            :V0PRODE-NUM-MATRICULA
            FROM SEGUROS.V0PRODESCNEG
            WHERE
            COD_ESCNEG = :V0PRODE-COD-ESCNEG
            AND DATA_INIVIGENCIA <= :V0PRODE-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :V0PRODE-DATA-TERVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_MATRICULA
											FROM SEGUROS.V0PRODESCNEG
											WHERE
											COD_ESCNEG = '{this.V0PRODE_COD_ESCNEG}'
											AND DATA_INIVIGENCIA <= '{this.V0PRODE_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.V0PRODE_DATA_TERVIGENCIA}'";

            return query;
        }
        public string V0PRODE_NUM_MATRICULA { get; set; }
        public string V0PRODE_DATA_INIVIGENCIA { get; set; }
        public string V0PRODE_DATA_TERVIGENCIA { get; set; }
        public string V0PRODE_COD_ESCNEG { get; set; }

        public static R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1 Execute(R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1 r0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1)
        {
            var ths = r0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRODE_NUM_MATRICULA = result[i++].Value?.ToString();
            return dta;
        }

    }
}