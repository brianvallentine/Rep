using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            MONTH(DTMOVABE),
            YEAR(DTMOVABE),
            DATE(DTMOVABE) + 15 DAYS
            INTO :V1SIST-DTMOVABE,
            :V1SIST-MESREFER,
            :V1SIST-ANOREFER,
            :V1SIST-DATA-LIMITE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'FI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											MONTH(DTMOVABE)
							,
											YEAR(DTMOVABE)
							,
											DATE(DTMOVABE) + 15 DAYS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'FI'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_MESREFER { get; set; }
        public string V1SIST_ANOREFER { get; set; }
        public string V1SIST_DATA_LIMITE { get; set; }

        public static R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_MESREFER = result[i++].Value?.ToString();
            dta.V1SIST_ANOREFER = result[i++].Value?.ToString();
            dta.V1SIST_DATA_LIMITE = result[i++].Value?.ToString();
            return dta;
        }

    }
}