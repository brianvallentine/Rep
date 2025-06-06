using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1210_00_CONSULTA_COBERPROPVA_Query1 : QueryBasis<R1210_00_CONSULTA_COBERPROPVA_Query1>
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
            CODOPER,
            VALUE(DTINIVIG, '0001-01-01' )
            INTO :V0COBP-VLPREMIO,
            :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            :V0COBP-QTTITCAP,
            :V0COBP-VLCUSTCAP,
            :V0COBP-VLCUSTCDG,
            :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF,
            :V0COBP-CODOPER,
            :V0COBP-DTINIVIG-1
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTINIVIG <= :V0COBP-DTINIVIG
            AND DTTERVIG >= :V0COBP-DTINIVIG
            WITH UR
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
							,
											VALUE(DTINIVIG
							, '0001-01-01' )
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTINIVIG <= '{this.V0COBP_DTINIVIG}'
											AND DTTERVIG >= '{this.V0COBP_DTINIVIG}'
											WITH UR";

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
        public string V0COBP_DTINIVIG_1 { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0COBP_DTINIVIG { get; set; }

        public static R1210_00_CONSULTA_COBERPROPVA_Query1 Execute(R1210_00_CONSULTA_COBERPROPVA_Query1 r1210_00_CONSULTA_COBERPROPVA_Query1)
        {
            var ths = r1210_00_CONSULTA_COBERPROPVA_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_CONSULTA_COBERPROPVA_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_CONSULTA_COBERPROPVA_Query1();
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
            dta.V0COBP_DTINIVIG_1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}