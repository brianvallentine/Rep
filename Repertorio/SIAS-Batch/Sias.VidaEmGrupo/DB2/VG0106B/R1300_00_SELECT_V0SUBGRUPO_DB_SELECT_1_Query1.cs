using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0106B
{
    public class R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_FATURAMENTO
            INTO :V0SUBG-PERI-FATUR
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :V1FATC-NUM-APOL
            AND COD_SUBGRUPO = :V1FATC-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_FATURAMENTO
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.V1FATC_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1FATC_COD_SUBG}'";

            return query;
        }
        public string V0SUBG_PERI_FATUR { get; set; }
        public string V1FATC_NUM_APOL { get; set; }
        public string V1FATC_COD_SUBG { get; set; }

        public static R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1 r1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SUBG_PERI_FATUR = result[i++].Value?.ToString();
            return dta;
        }

    }
}