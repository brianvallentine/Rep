using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1 : QueryBasis<R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMTIT ,
            NUMTITMAX
            INTO :V0CEDE-NUMTIT ,
            :V0CEDE-NUMTITMAX
            FROM SEGUROS.V0CEDENTE
            WHERE CODCDT = 26
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMTIT 
							,
											NUMTITMAX
											FROM SEGUROS.V0CEDENTE
											WHERE CODCDT = 26
											WITH UR";

            return query;
        }
        public string V0CEDE_NUMTIT { get; set; }
        public string V0CEDE_NUMTITMAX { get; set; }

        public static R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1 Execute(R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1 r0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1)
        {
            var ths = r0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CEDE_NUMTIT = result[i++].Value?.ToString();
            dta.V0CEDE_NUMTITMAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}