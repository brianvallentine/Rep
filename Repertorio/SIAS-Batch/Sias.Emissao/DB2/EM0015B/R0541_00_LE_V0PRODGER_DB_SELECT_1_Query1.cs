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
    public class R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1 : QueryBasis<R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PROD_GERENTE
            INTO
            :V0PRODG-COD-PROD-GERENTE
            FROM SEGUROS.V0PRODGER
            WHERE
            COD_AGENCIA = :V0PRODG-COD-AGENCIA
            AND DATA_INIVIGENCIA <= :V0PRODG-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :V0PRODG-DATA-TERVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PROD_GERENTE
											FROM SEGUROS.V0PRODGER
											WHERE
											COD_AGENCIA = '{this.V0PRODG_COD_AGENCIA}'
											AND DATA_INIVIGENCIA <= '{this.V0PRODG_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.V0PRODG_DATA_TERVIGENCIA}'";

            return query;
        }
        public string V0PRODG_COD_PROD_GERENTE { get; set; }
        public string V0PRODG_DATA_INIVIGENCIA { get; set; }
        public string V0PRODG_DATA_TERVIGENCIA { get; set; }
        public string V0PRODG_COD_AGENCIA { get; set; }

        public static R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1 Execute(R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1 r0541_00_LE_V0PRODGER_DB_SELECT_1_Query1)
        {
            var ths = r0541_00_LE_V0PRODGER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRODG_COD_PROD_GERENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}