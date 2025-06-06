using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 : QueryBasis<R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CARTA,
            DTEMICAR
            INTO :V0FOLH-COD-CARTA,
            :V0FOLH-DTEMICAR
            FROM SEGUROS.V0FOLHETO_INFO
            WHERE DTEMICAR = :V0FOLHM-DTEMICAR
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CARTA
							,
											DTEMICAR
											FROM SEGUROS.V0FOLHETO_INFO
											WHERE DTEMICAR = '{this.V0FOLHM_DTEMICAR}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V0FOLH_COD_CARTA { get; set; }
        public string V0FOLH_DTEMICAR { get; set; }
        public string V0FOLHM_DTEMICAR { get; set; }

        public static R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 Execute(R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1)
        {
            var ths = r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FOLH_COD_CARTA = result[i++].Value?.ToString();
            dta.V0FOLH_DTEMICAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}