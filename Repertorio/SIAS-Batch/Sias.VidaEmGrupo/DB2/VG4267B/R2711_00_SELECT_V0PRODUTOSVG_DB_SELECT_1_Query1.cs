using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 : QueryBasis<R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CODCDT
            INTO
            :V0PROD-CODCDT
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND CODSUBES = :WHOST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CODCDT
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND CODSUBES = '{this.WHOST_CODSUBES}'";

            return query;
        }
        public string V0PROD_CODCDT { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 Execute(R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 r2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1)
        {
            var ths = r2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_CODCDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}