using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP,
            PRMVG + PRMAP,
            VLCUSTCDG,
            VLCUSTAUXF,
            IMPSEGCDC,
            IMPSEGAUXF,
            VLCUSTCAP,
            QTTITCAP,
            VALUE(PRMDIT, 0)
            INTO :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            :V0COBP-VLPREMIO,
            :V0COBP-VLCUSTCDG,
            :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I,
            :V0COBP-IMPSEGCDG,
            :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I,
            :V0COBP-VLCUSTCAP,
            :V0COBP-QTTITCAP,
            :V0COBP-PRMDIT
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF =:V0HCTA-NRCERTIF
            AND OCORHIST = :V0PROP-OCORHIST
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
							,
											PRMVG + PRMAP
							,
											VLCUSTCDG
							,
											VLCUSTAUXF
							,
											IMPSEGCDC
							,
											IMPSEGAUXF
							,
											VLCUSTCAP
							,
											QTTITCAP
							,
											VALUE(PRMDIT
							, 0)
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF ='{this.V0HCTA_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'
											WITH UR";

            return query;
        }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_VLCUSTAUXF_I { get; set; }
        public string V0COBP_IMPSEGCDG { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0COBP_IMPSEGAUXF_I { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }
        public string V0COBP_QTTITCAP { get; set; }
        public string V0COBP_PRMDIT { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1 Execute(R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1 r1000_00_QUITA_PARCELA_DB_SELECT_4_Query1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0COBP_PRMVG = result[i++].Value?.ToString();
            dta.V0COBP_PRMAP = result[i++].Value?.ToString();
            dta.V0COBP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_VLCUSTAUXF) ? "-1" : "0";
            dta.V0COBP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_IMPSEGAUXF) ? "-1" : "0";
            dta.V0COBP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.V0COBP_QTTITCAP = result[i++].Value?.ToString();
            dta.V0COBP_PRMDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}