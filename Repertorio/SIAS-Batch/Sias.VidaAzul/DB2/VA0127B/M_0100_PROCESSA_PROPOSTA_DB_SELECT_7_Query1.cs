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
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(PRMVG),0),
            VALUE(SUM(PRMAP),0)
            INTO
            :V0HCTB-PREMIO400VG,
            :V0HCTB-PREMIO400AP
            FROM
            SEGUROS.V0HISTCONTABILVA
            WHERE
            NRCERTIF = :PROPVA-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            AND CODOPER BETWEEN 400 AND 499
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRMVG)
							,0)
							,
											VALUE(SUM(PRMAP)
							,0)
											FROM
											SEGUROS.V0HISTCONTABILVA
											WHERE
											NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'
											AND CODOPER BETWEEN 400 AND 499";

            return query;
        }
        public string V0HCTB_PREMIO400VG { get; set; }
        public string V0HCTB_PREMIO400AP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1();
            var i = 0;
            dta.V0HCTB_PREMIO400VG = result[i++].Value?.ToString();
            dta.V0HCTB_PREMIO400AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}