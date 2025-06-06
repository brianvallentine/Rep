using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0490_00_OBTER_CBO_DB_SELECT_1_Query1 : QueryBasis<R0490_00_OBTER_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_CBO
            INTO :CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE COD_CBO = :CBO-COD-CBO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_CBO
											FROM SEGUROS.CBO
											WHERE COD_CBO = '{this.CBO_COD_CBO}'
											WITH UR";

            return query;
        }
        public string CBO_DESCR_CBO { get; set; }
        public string CBO_COD_CBO { get; set; }

        public static R0490_00_OBTER_CBO_DB_SELECT_1_Query1 Execute(R0490_00_OBTER_CBO_DB_SELECT_1_Query1 r0490_00_OBTER_CBO_DB_SELECT_1_Query1)
        {
            var ths = r0490_00_OBTER_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0490_00_OBTER_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0490_00_OBTER_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}