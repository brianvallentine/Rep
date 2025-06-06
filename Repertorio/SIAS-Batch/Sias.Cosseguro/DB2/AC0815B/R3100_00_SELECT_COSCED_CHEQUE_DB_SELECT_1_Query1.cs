using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLRCOMIS,
            OUTRDEBIT
            INTO :V0CCHQ-COMISSAO,
            :V0CCHQ-OUTRDEBIT
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V1RELA-COD-EMPR
            AND CONGENER = :V1RELA-CONGENER
            AND DTMOVTO_AC = :V1RELA-DATA-SOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLRCOMIS
							,
											OUTRDEBIT
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V1RELA_COD_EMPR}'
											AND CONGENER = '{this.V1RELA_CONGENER}'
											AND DTMOVTO_AC = '{this.V1RELA_DATA_SOL}'";

            return query;
        }
        public string V0CCHQ_COMISSAO { get; set; }
        public string V0CCHQ_OUTRDEBIT { get; set; }
        public string V1RELA_COD_EMPR { get; set; }
        public string V1RELA_CONGENER { get; set; }
        public string V1RELA_DATA_SOL { get; set; }

        public static R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 Execute(R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 r3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CCHQ_COMISSAO = result[i++].Value?.ToString();
            dta.V0CCHQ_OUTRDEBIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}