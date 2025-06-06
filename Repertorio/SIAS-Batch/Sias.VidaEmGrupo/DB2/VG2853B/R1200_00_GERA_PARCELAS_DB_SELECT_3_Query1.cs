using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO,
            PRMVG,
            PRMAP,
            QTTITCAP,
            VLCUSTCAP,
            VLCUSTCDG,
            VLCUSTAUXF,
            CODOPER
            INTO :V0COBP-VLPREMIO,
            :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            :V0COBP-QTTITCAP,
            :V0COBP-VLCUSTCAP,
            :V0COBP-VLCUSTCDG,
            :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF,
            :V0COBP-CODOPER
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND OCORHIST = :V0PROP-NRPARCEL-NEW
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
							,
											PRMVG
							,
											PRMAP
							,
											QTTITCAP
							,
											VLCUSTCAP
							,
											VLCUSTCDG
							,
											VLCUSTAUXF
							,
											CODOPER
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_NRPARCEL_NEW}'";

            return query;
        }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0COBP_QTTITCAP { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_IVLCUSTAUXF { get; set; }
        public string V0COBP_CODOPER { get; set; }
        public string V0PROP_NRPARCEL_NEW { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 Execute(R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1)
        {
            var ths = r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0COBP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBP_PRMVG = result[i++].Value?.ToString();
            dta.V0COBP_PRMAP = result[i++].Value?.ToString();
            dta.V0COBP_QTTITCAP = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBP_IVLCUSTAUXF = string.IsNullOrWhiteSpace(dta.V0COBP_VLCUSTAUXF) ? "-1" : "0";
            dta.V0COBP_CODOPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}