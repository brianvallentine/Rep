using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE,
            NRRCAP
            INTO :V0RCAP-FONTE,
            :V0RCAP-NRRCAP
            FROM SEGUROS.V0RCAP
            WHERE (NRTIT = :V0RCAP-NRTIT
            OR NRCERTIF = :V0RCAP-NRCERTIF)
            AND OPERACAO >= 100
            AND OPERACAO <= 199
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE
							,
											NRRCAP
											FROM SEGUROS.V0RCAP
											WHERE (NRTIT = '{this.V0RCAP_NRTIT}'
											OR NRCERTIF = '{this.V0RCAP_NRCERTIF}')
											AND OPERACAO >= 100
											AND OPERACAO <= 199
											AND SITUACAO = '0'";

            return query;
        }
        public string V0RCAP_FONTE { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_NRCERTIF { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 Execute(M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1)
        {
            var ths = m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0RCAP_FONTE = result[i++].Value?.ToString();
            dta.V0RCAP_NRRCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}