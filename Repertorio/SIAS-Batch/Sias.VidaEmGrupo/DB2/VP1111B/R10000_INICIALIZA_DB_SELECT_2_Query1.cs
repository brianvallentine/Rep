using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class R10000_INICIALIZA_DB_SELECT_2_Query1 : QueryBasis<R10000_INICIALIZA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(SUBSTR(CHAR(DATE(CURRENT DATE)),1,7)
            || '-01' )
            , DATE(SUBSTR(CHAR(DATE(CURRENT DATE)
            + 1 MONTH),1,7)|| '-01' ) - 1 DAY
            INTO :WS-DT-INI, :WS-DT-FIM
            FROM SYSIBM.SYSDUMMY1
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE(SUBSTR(CHAR(DATE(CURRENT DATE))
							,1
							,7)
											|| '-01' )
											, DATE(SUBSTR(CHAR(DATE(CURRENT DATE)
											+ 1 MONTH)
							,1
							,7)|| '-01' ) - 1 DAY
											FROM SYSIBM.SYSDUMMY1
											WITH UR";

            return query;
        }
        public string WS_DT_INI { get; set; }
        public string WS_DT_FIM { get; set; }

        public static R10000_INICIALIZA_DB_SELECT_2_Query1 Execute(R10000_INICIALIZA_DB_SELECT_2_Query1 r10000_INICIALIZA_DB_SELECT_2_Query1)
        {
            var ths = r10000_INICIALIZA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R10000_INICIALIZA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R10000_INICIALIZA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_DT_INI = result[i++].Value?.ToString();
            dta.WS_DT_FIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}