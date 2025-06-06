using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1 : QueryBasis<M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_OPERACAO), 0)
            INTO :CA-VALOR-TOTAL
            FROM SEGUROS.V1HISTSINI
            WHERE DTMOVTO = :V1HIST-DTMOVTO
            AND NUM_APOL_SINISTRO = :V1MEST-APOL-SINI
            AND OPERACAO = :V1HIST-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_OPERACAO)
							, 0)
											FROM SEGUROS.V1HISTSINI
											WHERE DTMOVTO = '{this.V1HIST_DTMOVTO}'
											AND NUM_APOL_SINISTRO = '{this.V1MEST_APOL_SINI}'
											AND OPERACAO = '{this.V1HIST_OPERACAO}'";

            return query;
        }
        public string CA_VALOR_TOTAL { get; set; }
        public string V1MEST_APOL_SINI { get; set; }
        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_DTMOVTO { get; set; }

        public static M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1 Execute(M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1 m_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1)
        {
            var ths = m_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CA_VALOR_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}