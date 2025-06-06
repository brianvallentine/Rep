using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0846B
{
    public class R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1 : QueryBasis<R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_OPERACAO),0)
            INTO :V0VAL-OPERACAO-PEND1
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO
            AND OPERACAO IN (105,106,107,108,115,116,117,
            118,1001,1002,1003,1004,1009)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_OPERACAO)
							,0)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0NUM_APOL_SINISTRO}'
											AND OPERACAO IN (105
							,106
							,107
							,108
							,115
							,116
							,117
							,
											118
							,1001
							,1002
							,1003
							,1004
							,1009)";

            return query;
        }
        public string V0VAL_OPERACAO_PEND1 { get; set; }
        public string V0NUM_APOL_SINISTRO { get; set; }

        public static R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1 Execute(R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1 r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1)
        {
            var ths = r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0VAL_OPERACAO_PEND1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}