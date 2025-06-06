using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC
            INTO :V1PRAMO-RAMO-VG, :V1PRAMO-RAMO-AP,
            :V1PRAMO-RAMO-VGAP
            FROM SEGUROS.V1PARAMRAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VG
							, RAMO_AP
							, RAMO_VGAPC
											FROM SEGUROS.V1PARAMRAMO";

            return query;
        }
        public string V1PRAMO_RAMO_VG { get; set; }
        public string V1PRAMO_RAMO_AP { get; set; }
        public string V1PRAMO_RAMO_VGAP { get; set; }

        public static R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PRAMO_RAMO_VG = result[i++].Value?.ToString();
            dta.V1PRAMO_RAMO_AP = result[i++].Value?.ToString();
            dta.V1PRAMO_RAMO_VGAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}