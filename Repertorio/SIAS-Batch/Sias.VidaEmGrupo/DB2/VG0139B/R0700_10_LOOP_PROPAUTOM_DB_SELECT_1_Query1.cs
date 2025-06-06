using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 : QueryBasis<R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :V0ENDO-CODPRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND COD_SUBGRUPO = :V0ENDO-CODSUBES
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0ENDO_CODSUBES}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0ENDO_CODPRODU { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_CODSUBES { get; set; }

        public static R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 Execute(R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 r0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1)
        {
            var ths = r0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}