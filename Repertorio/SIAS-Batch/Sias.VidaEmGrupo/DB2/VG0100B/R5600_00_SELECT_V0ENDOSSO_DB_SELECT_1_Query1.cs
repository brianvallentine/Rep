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
    public class R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            DTTERVIG
            INTO :V0ENDO-DTTERVIG
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1SOLF-NUM-APOL
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTTERVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND NRENDOS = 0";

            return query;
        }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }

        public static R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}