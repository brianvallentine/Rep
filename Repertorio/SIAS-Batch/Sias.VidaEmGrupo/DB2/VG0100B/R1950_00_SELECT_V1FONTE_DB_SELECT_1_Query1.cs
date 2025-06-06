using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1 : QueryBasis<R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PROPAUTOM
            INTO :V0FONT-PROPAUTOM
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :W1SUBG-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PROPAUTOM
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.W1SUBG_COD_FONTE}'";

            return query;
        }
        public string V0FONT_PROPAUTOM { get; set; }
        public string W1SUBG_COD_FONTE { get; set; }

        public static R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1 Execute(R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1 r1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1)
        {
            var ths = r1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FONT_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}