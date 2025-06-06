using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class R111050_LE_AGENCIAS_DB_SELECT_1_Query1 : QueryBasis<R111050_LE_AGENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_ESCNEG
            INTO
            :AGENCCEF-COD-ESCNEG
            FROM SEGUROS.AGENCIAS_CEF
            WHERE COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_ESCNEG
											FROM SEGUROS.AGENCIAS_CEF
											WHERE COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'";

            return query;
        }
        public string AGENCCEF_COD_ESCNEG { get; set; }
        public string AGENCCEF_COD_AGENCIA { get; set; }

        public static R111050_LE_AGENCIAS_DB_SELECT_1_Query1 Execute(R111050_LE_AGENCIAS_DB_SELECT_1_Query1 r111050_LE_AGENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r111050_LE_AGENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111050_LE_AGENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111050_LE_AGENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_ESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}