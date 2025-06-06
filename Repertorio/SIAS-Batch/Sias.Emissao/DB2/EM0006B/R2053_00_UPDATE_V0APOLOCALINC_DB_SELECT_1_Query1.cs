using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1 : QueryBasis<R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OCORHIST
            INTO
            :V1APLI-OCORHIST
            FROM
            SEGUROS.V1APOLOCALINC
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOL
            AND NUM_RISCO = :V1PRLI-NUM-RISCO
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OCORHIST
											FROM
											SEGUROS.V1APOLOCALINC
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOL}'
											AND NUM_RISCO = '{this.V1PRLI_NUM_RISCO}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1APLI_OCORHIST { get; set; }
        public string V1PRLI_NUM_RISCO { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }

        public static R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1 Execute(R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1 r2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1)
        {
            var ths = r2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APLI_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}