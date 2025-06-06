using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0817B
{
    public class M_0100_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF,
            NRPARCEL,
            VLPRMTOT,
            SITUACAO,
            OCORHIST,
            CODOPER,
            NRTIT
            INTO :V0HCOB-NRCERTIF,
            :V0HCOB-NRPARCEL,
            :V0HCOB-VLPRMTOT,
            :V0HCOB-SITUACAO,
            :V0HCOB-OCORHIST,
            :V0HCOB-CODOPER,
            :V0HCOB-NRTIT
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0PARC-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
							,
											NRPARCEL
							,
											VLPRMTOT
							,
											SITUACAO
							,
											OCORHIST
							,
											CODOPER
							,
											NRTIT
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0PARC_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string V0HCOB_SITUACAO { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_CODOPER { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0PARC_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static M_0100_PROCESSA_DB_SELECT_1_Query1 Execute(M_0100_PROCESSA_DB_SELECT_1_Query1 m_0100_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_0100_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCOB_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCOB_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HCOB_SITUACAO = result[i++].Value?.ToString();
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCOB_CODOPER = result[i++].Value?.ToString();
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}