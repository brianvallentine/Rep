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
    public class M_1035_QUITA_PARCELA_DB_SELECT_4_Query1 : QueryBasis<M_1035_QUITA_PARCELA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static M_1035_QUITA_PARCELA_DB_SELECT_4_Query1 Execute(M_1035_QUITA_PARCELA_DB_SELECT_4_Query1 m_1035_QUITA_PARCELA_DB_SELECT_4_Query1)
        {
            var ths = m_1035_QUITA_PARCELA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1035_QUITA_PARCELA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1035_QUITA_PARCELA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}