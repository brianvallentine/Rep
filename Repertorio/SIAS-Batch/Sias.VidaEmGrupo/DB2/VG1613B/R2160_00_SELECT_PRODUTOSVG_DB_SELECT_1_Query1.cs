using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 : QueryBasis<R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(ORIG_PRODU, ' ' )
            INTO :PRODUVG-ORIG-PRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE
            AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(ORIG_PRODU
							, ' ' )
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PRODUVG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PRODUVG_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }

        public static R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 Execute(R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 r2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1)
        {
            var ths = r2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}