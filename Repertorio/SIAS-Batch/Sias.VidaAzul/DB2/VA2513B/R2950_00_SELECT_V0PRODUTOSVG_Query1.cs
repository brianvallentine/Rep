using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R2950_00_SELECT_V0PRODUTOSVG_Query1 : QueryBasis<R2950_00_SELECT_V0PRODUTOSVG_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU,
            NOMPRODU,
            CODCDT,
            ORIG_PRODU
            INTO :V0PROD-CODPRODU,
            :V0PROD-NOMPRODU,
            :V0PROD-CODCDT,
            :V0PROD-ORIG-PRODU:VIND-ORIG-PRODU
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND CODSUBES = :WHOST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
							,
											NOMPRODU
							,
											CODCDT
							,
											ORIG_PRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND CODSUBES = '{this.WHOST_CODSUBES}'";

            return query;
        }
        public string V0PROD_CODPRODU { get; set; }
        public string V0PROD_NOMPRODU { get; set; }
        public string V0PROD_CODCDT { get; set; }
        public string V0PROD_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2950_00_SELECT_V0PRODUTOSVG_Query1 Execute(R2950_00_SELECT_V0PRODUTOSVG_Query1 r2950_00_SELECT_V0PRODUTOSVG_Query1)
        {
            var ths = r2950_00_SELECT_V0PRODUTOSVG_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2950_00_SELECT_V0PRODUTOSVG_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2950_00_SELECT_V0PRODUTOSVG_Query1();
            var i = 0;
            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROD_NOMPRODU = result[i++].Value?.ToString();
            dta.V0PROD_CODCDT = result[i++].Value?.ToString();
            dta.V0PROD_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.V0PROD_ORIG_PRODU) ? "-1" : "0";
            return dta;
        }

    }
}