using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0055B
{
    public class R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1 : QueryBasis<R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NUMOPG
            INTO :V1ADIA-NUMOPG
            FROM SEGUROS.V0ADIANTA
            WHERE CODPDT = 17256
            AND NUM_APOLICE = :WHOST-NUM-APOL
            AND NUMOPG > 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMOPG
											FROM SEGUROS.V0ADIANTA
											WHERE CODPDT = 17256
											AND NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NUMOPG > 0";

            return query;
        }
        public string V1ADIA_NUMOPG { get; set; }
        public string WHOST_NUM_APOL { get; set; }

        public static R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1 Execute(R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1 r2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ADIA_NUMOPG = result[i++].Value?.ToString();
            return dta;
        }

    }
}