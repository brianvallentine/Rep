using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 : QueryBasis<R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTEMICAR)
            INTO :V0FOLHM-DTEMICAR
            FROM SEGUROS.V0FOLHETO_INFO
            WHERE SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTEMICAR)
											FROM SEGUROS.V0FOLHETO_INFO
											WHERE SITUACAO = '0'";

            return query;
        }
        public string V0FOLHM_DTEMICAR { get; set; }

        public static R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 Execute(R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1)
        {
            var ths = r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FOLHM_DTEMICAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}