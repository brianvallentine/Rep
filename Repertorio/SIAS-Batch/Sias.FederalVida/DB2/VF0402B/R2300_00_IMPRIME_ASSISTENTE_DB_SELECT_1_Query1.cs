using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0402B
{
    public class R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1 : QueryBasis<R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMAST
            INTO :V0ASST-NOMAST
            FROM SEGUROS.V0ASSISTFC
            WHERE CODAST = :V0ASST-CODAST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMAST
											FROM SEGUROS.V0ASSISTFC
											WHERE CODAST = '{this.V0ASST_CODAST}'";

            return query;
        }
        public string V0ASST_NOMAST { get; set; }
        public string V0ASST_CODAST { get; set; }

        public static R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1 Execute(R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1 r2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ASST_NOMAST = result[i++].Value?.ToString();
            return dta;
        }

    }
}