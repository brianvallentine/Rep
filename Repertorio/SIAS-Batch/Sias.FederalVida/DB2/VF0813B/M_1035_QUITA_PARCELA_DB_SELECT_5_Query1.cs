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
    public class M_1035_QUITA_PARCELA_DB_SELECT_5_Query1 : QueryBasis<M_1035_QUITA_PARCELA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTCDG,
            VLCUSTAUXF,
            IMPSEGCDC,
            IMPSEGAUXF
            INTO :V0COBP-VLCUSTCDG,
            :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I,
            :V0COBP-IMPSEGCDG,
            :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND DTINIVIG <= :V0PARC-DTVENCTO
            AND DTTERVIG >= :V0PARC-DTVENCTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTCDG
							,
											VLCUSTAUXF
							,
											IMPSEGCDC
							,
											IMPSEGAUXF
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO}'";

            return query;
        }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_VLCUSTAUXF_I { get; set; }
        public string V0COBP_IMPSEGCDG { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0COBP_IMPSEGAUXF_I { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

        public static M_1035_QUITA_PARCELA_DB_SELECT_5_Query1 Execute(M_1035_QUITA_PARCELA_DB_SELECT_5_Query1 m_1035_QUITA_PARCELA_DB_SELECT_5_Query1)
        {
            var ths = m_1035_QUITA_PARCELA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1035_QUITA_PARCELA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1035_QUITA_PARCELA_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0COBP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_VLCUSTAUXF) ? "-1" : "0";
            dta.V0COBP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_IMPSEGAUXF) ? "-1" : "0";
            return dta;
        }

    }
}