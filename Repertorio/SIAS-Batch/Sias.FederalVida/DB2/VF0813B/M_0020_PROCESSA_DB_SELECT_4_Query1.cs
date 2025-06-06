using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_0020_PROCESSA_DB_SELECT_4_Query1 : QueryBasis<M_0020_PROCESSA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP,
            DTVENCTO
            INTO :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
							,
											DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCOB_NRPARCEL}'";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }

        public static M_0020_PROCESSA_DB_SELECT_4_Query1 Execute(M_0020_PROCESSA_DB_SELECT_4_Query1 m_0020_PROCESSA_DB_SELECT_4_Query1)
        {
            var ths = m_0020_PROCESSA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_PROCESSA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_PROCESSA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}