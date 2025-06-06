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
    public class R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 : QueryBasis<R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPRODU,
            CODCDT,
            CODPRODU,
            TEM_CDG
            INTO :V0PROD-NOMPRODU,
            :V0PROD-CODCDT,
            :V0PROD-CODPRODU,
            :V0PROD-TEM-CDG:VIND-TEMCDG
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND CODSUBES = :WHOST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPRODU
							,
											CODCDT
							,
											CODPRODU
							,
											TEM_CDG
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND CODSUBES = '{this.WHOST_CODSUBES}'";

            return query;
        }
        public string V0PROD_NOMPRODU { get; set; }
        public string V0PROD_CODCDT { get; set; }
        public string V0PROD_CODPRODU { get; set; }
        public string V0PROD_TEM_CDG { get; set; }
        public string VIND_TEMCDG { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 Execute(R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 r2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_NOMPRODU = result[i++].Value?.ToString();
            dta.V0PROD_CODCDT = result[i++].Value?.ToString();
            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROD_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEMCDG = string.IsNullOrWhiteSpace(dta.V0PROD_TEM_CDG) ? "-1" : "0";
            return dta;
        }

    }
}