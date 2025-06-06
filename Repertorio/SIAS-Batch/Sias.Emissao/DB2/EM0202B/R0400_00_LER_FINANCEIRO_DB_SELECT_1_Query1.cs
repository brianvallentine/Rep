using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1 : QueryBasis<R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V1SIST-DTMOVABE-FI
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'FI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'FI'";

            return query;
        }
        public string V1SIST_DTMOVABE_FI { get; set; }

        public static R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1 Execute(R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1 r0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE_FI = result[i++].Value?.ToString();
            return dta;
        }

    }
}