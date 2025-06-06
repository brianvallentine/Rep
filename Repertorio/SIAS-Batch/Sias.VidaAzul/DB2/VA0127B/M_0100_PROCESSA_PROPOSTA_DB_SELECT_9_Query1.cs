using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(COUNT(*),0)
            INTO
            :HOST-COUNT-CRED
            FROM SEGUROS.V0DIFPARCELVA
            WHERE
            NRCERTIF = :PROPVA-NRCERTIF
            AND NRPARCELDIF = :V0PARC-NRPARCEL
            AND CODOPER BETWEEN 600 AND 699
            AND DTVENCTO = :V0PARC-DTVENCTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0DIFPARCELVA
											WHERE
											NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND NRPARCELDIF = '{this.V0PARC_NRPARCEL}'
											AND CODOPER BETWEEN 600 AND 699
											AND DTVENCTO = '{this.V0PARC_DTVENCTO}'";

            return query;
        }
        public string HOST_COUNT_CRED { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1();
            var i = 0;
            dta.HOST_COUNT_CRED = result[i++].Value?.ToString();
            return dta;
        }

    }
}