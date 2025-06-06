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
    public class R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1 : QueryBasis<R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CHPFUN
            INTO
            :V0PRODU-CHPFUN
            FROM SEGUROS.V0PRODUTOR
            WHERE
            CODPDT = :V0PRODU-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CHPFUN
											FROM SEGUROS.V0PRODUTOR
											WHERE
											CODPDT = '{this.V0PRODU_CODPDT}'";

            return query;
        }
        public string V0PRODU_CHPFUN { get; set; }
        public string V0PRODU_CODPDT { get; set; }

        public static R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1 Execute(R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1 r0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1)
        {
            var ths = r0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRODU_CHPFUN = result[i++].Value?.ToString();
            return dta;
        }

    }
}