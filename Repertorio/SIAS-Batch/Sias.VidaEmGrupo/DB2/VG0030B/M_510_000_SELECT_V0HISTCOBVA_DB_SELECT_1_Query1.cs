using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT,
            OCORHIST,
            DTVENCTO
            INTO :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :V0HCOB-DTVENCTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :MNUM-CERTIFICADO
            AND NRPARCEL = :V0PROP-NRPARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
							,
											OCORHIST
							,
											DTVENCTO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.MNUM_CERTIFICADO}'
											AND NRPARCEL = '{this.V0PROP_NRPARCELA}'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_NRPARCELA { get; set; }

        public static M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 Execute(M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 m_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = m_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}