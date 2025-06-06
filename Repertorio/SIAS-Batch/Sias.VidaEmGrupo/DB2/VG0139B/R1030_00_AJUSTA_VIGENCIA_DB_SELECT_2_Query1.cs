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
    public class R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1 : QueryBasis<R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:V0ENDO-DTTERVIG) - 1 DAY
            INTO :V0ENDO-DTTERVIG
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.V0ENDO_DTTERVIG}') - 1 DAY
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string V0ENDO_DTTERVIG { get; set; }

        public static R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1 Execute(R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1 r1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1)
        {
            var ths = r1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}