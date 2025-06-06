using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :V0SEGU-NUM-ITEM
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0HCOB-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0HCOB_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V0SEGU_NUM_ITEM { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 Execute(R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 r1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGU_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}