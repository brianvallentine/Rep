using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 : QueryBasis<R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTMOVTO_AC)
            INTO :WHOST-DTMOVTO-AC:VIND-DTMOVTO-AC
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V1RELA-COD-EMPR
            AND CONGENER = :V1RELA-CONGENER
            AND SITUACAO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTMOVTO_AC)
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V1RELA_COD_EMPR}'
											AND CONGENER = '{this.V1RELA_CONGENER}'
											AND SITUACAO = '1'";

            return query;
        }
        public string WHOST_DTMOVTO_AC { get; set; }
        public string VIND_DTMOVTO_AC { get; set; }
        public string V1RELA_COD_EMPR { get; set; }
        public string V1RELA_CONGENER { get; set; }

        public static R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 Execute(R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTMOVTO_AC = result[i++].Value?.ToString();
            dta.VIND_DTMOVTO_AC = string.IsNullOrWhiteSpace(dta.WHOST_DTMOVTO_AC) ? "-1" : "0";
            return dta;
        }

    }
}