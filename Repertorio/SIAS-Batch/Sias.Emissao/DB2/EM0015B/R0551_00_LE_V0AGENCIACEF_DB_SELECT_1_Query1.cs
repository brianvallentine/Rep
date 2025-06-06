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
    public class R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_ESCNEG
            INTO
            :V0AGENC-COD-ESCNEG
            FROM SEGUROS.V0AGENCIACEF
            WHERE
            COD_AGENCIA = :V0AGENC-COD-AGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_ESCNEG
											FROM SEGUROS.V0AGENCIACEF
											WHERE
											COD_AGENCIA = '{this.V0AGENC_COD_AGENCIA}'";

            return query;
        }
        public string V0AGENC_COD_ESCNEG { get; set; }
        public string V0AGENC_COD_AGENCIA { get; set; }

        public static R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1 Execute(R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1 r0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AGENC_COD_ESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}