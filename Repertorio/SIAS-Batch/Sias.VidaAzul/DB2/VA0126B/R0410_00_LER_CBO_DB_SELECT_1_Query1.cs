using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class R0410_00_LER_CBO_DB_SELECT_1_Query1 : QueryBasis<R0410_00_LER_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CBO
            , DESCR_CBO
            INTO :CBO-COD-CBO
            ,:CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE DESCR_CBO = :CBO-DESCR-CBO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CBO
											, DESCR_CBO
											FROM SEGUROS.CBO
											WHERE DESCR_CBO = '{this.CBO_DESCR_CBO}'";

            return query;
        }
        public string CBO_COD_CBO { get; set; }
        public string CBO_DESCR_CBO { get; set; }

        public static R0410_00_LER_CBO_DB_SELECT_1_Query1 Execute(R0410_00_LER_CBO_DB_SELECT_1_Query1 r0410_00_LER_CBO_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_LER_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_LER_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_LER_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_COD_CBO = result[i++].Value?.ToString();
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}