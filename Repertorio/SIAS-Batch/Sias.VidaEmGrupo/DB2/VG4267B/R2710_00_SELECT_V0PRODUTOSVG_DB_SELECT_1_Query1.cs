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
    public class R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 : QueryBasis<R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            CODSUBES ,
            ESTR_COBR ,
            ORIG_PRODU
            INTO
            :V0PROD-NUM-APOLICE,
            :V0PROD-CODSUBES ,
            :V0PROD-ESTR-COBR:V0PROD-ESTR-COBR-I,
            :V0PROD-ORIG-PRODU:V0PROD-ORIG-PRODU-I
            FROM
            SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :V0HIST-NRAPOLICE
            AND CODSUBES = :V0HIST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											CODSUBES 
							,
											ESTR_COBR 
							,
											ORIG_PRODU
											FROM
											SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.V0HIST_NRAPOLICE}'
											AND CODSUBES = '{this.V0HIST_CODSUBES}'";

            return query;
        }
        public string V0PROD_NUM_APOLICE { get; set; }
        public string V0PROD_CODSUBES { get; set; }
        public string V0PROD_ESTR_COBR { get; set; }
        public string V0PROD_ESTR_COBR_I { get; set; }
        public string V0PROD_ORIG_PRODU { get; set; }
        public string V0PROD_ORIG_PRODU_I { get; set; }
        public string V0HIST_NRAPOLICE { get; set; }
        public string V0HIST_CODSUBES { get; set; }

        public static R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 Execute(R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1)
        {
            var ths = r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROD_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROD_ESTR_COBR = result[i++].Value?.ToString();
            dta.V0PROD_ESTR_COBR_I = string.IsNullOrWhiteSpace(dta.V0PROD_ESTR_COBR) ? "-1" : "0";
            dta.V0PROD_ORIG_PRODU = result[i++].Value?.ToString();
            dta.V0PROD_ORIG_PRODU_I = string.IsNullOrWhiteSpace(dta.V0PROD_ORIG_PRODU) ? "-1" : "0";
            return dta;
        }

    }
}