using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU,
            NOMPRODU
            INTO :V0PROD-CODPRODU,
            :V0PROD-NOMPRODU
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :V0SUBG-NUM-APOL
            AND CODSUBES = :V0SUBG-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
							,
											NOMPRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.V0SUBG_NUM_APOL}'
											AND CODSUBES = '{this.V0SUBG_COD_SUBG}'";

            return query;
        }
        public string V0PROD_CODPRODU { get; set; }
        public string V0PROD_NOMPRODU { get; set; }
        public string V0SUBG_NUM_APOL { get; set; }
        public string V0SUBG_COD_SUBG { get; set; }

        public static R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1 Execute(R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1 r0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROD_NOMPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}