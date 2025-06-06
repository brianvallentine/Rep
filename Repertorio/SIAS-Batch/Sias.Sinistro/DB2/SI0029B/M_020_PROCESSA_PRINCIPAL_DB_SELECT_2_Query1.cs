using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0029B
{
    public class M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTMOVTO)
            INTO :V0HIST-DTMOVTO
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO
            AND OPERACAO IN (1081,1082,1083,1084)
            AND SITUACAO <> '2'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX(DTMOVTO)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MEST_NUM_APOL_SINISTRO}'
											AND OPERACAO IN (1081
							,1082
							,1083
							,1084)
											AND SITUACAO <> '2'";

            return query;
        }
        public string V0HIST_DTMOVTO { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }

        public static M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1 m_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HIST_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}