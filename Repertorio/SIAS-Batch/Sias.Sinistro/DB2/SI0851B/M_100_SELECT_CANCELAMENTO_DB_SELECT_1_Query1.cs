using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0851B
{
    public class M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1 : QueryBasis<M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTMOVTO)
            INTO :V0HIST-DTMOVTO
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO
            AND OPERACAO IN (107,108,117,118)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTMOVTO)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MEST_NUM_APOL_SINISTRO}'
											AND OPERACAO IN (107
							,108
							,117
							,118)";

            return query;
        }
        public string V0HIST_DTMOVTO { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }

        public static M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1 Execute(M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1 m_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HIST_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}