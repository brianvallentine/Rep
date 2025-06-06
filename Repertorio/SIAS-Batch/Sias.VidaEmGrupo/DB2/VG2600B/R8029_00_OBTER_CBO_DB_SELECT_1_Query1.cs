using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8029_00_OBTER_CBO_DB_SELECT_1_Query1 : QueryBasis<R8029_00_OBTER_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DESCR_CBO, ' ' )
            INTO :CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE COD_CBO = :CBO-COD-CBO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DESCR_CBO
							, ' ' )
											FROM SEGUROS.CBO
											WHERE COD_CBO = '{this.CBO_COD_CBO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CBO_DESCR_CBO { get; set; }
        public string CBO_COD_CBO { get; set; }

        public static R8029_00_OBTER_CBO_DB_SELECT_1_Query1 Execute(R8029_00_OBTER_CBO_DB_SELECT_1_Query1 r8029_00_OBTER_CBO_DB_SELECT_1_Query1)
        {
            var ths = r8029_00_OBTER_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8029_00_OBTER_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8029_00_OBTER_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}