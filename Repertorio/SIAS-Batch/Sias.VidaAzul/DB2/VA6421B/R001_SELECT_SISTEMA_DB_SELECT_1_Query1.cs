using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6421B
{
    public class R001_SELECT_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R001_SELECT_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            DTMOVABE
            INTO :V0SIST-DTMOVABE,
            :V0FATUR-DTREFER
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											DTMOVABE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VG'";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0FATUR_DTREFER { get; set; }

        public static R001_SELECT_SISTEMA_DB_SELECT_1_Query1 Execute(R001_SELECT_SISTEMA_DB_SELECT_1_Query1 r001_SELECT_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r001_SELECT_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R001_SELECT_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R001_SELECT_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V0FATUR_DTREFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}