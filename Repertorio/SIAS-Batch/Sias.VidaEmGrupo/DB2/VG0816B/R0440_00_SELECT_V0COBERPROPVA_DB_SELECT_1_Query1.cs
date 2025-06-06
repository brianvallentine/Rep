using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG
            ,PRMAP
            ,VLPREMIO
            ,PRMVG + PRMAP
            ,IMPMORNATU
            ,IMPMORACID
            ,IMPDIT
            ,QUANT_VIDAS
            ,IMPINVPERM
            ,IMPDH
            ,VLCUSTAUXF
            ,IMPSEGAUXF
            ,VLCUSTCDG
            ,IMPSEGCDC
            ,VLCUSTCAP
            ,QTTITCAP
            INTO :V0COBP-PRMVG
            ,:V0COBP-PRMAP
            ,:V0COBP-VLPREMIO
            ,:V0COBP-PRMTOT
            ,:V0COBP-IMPMORNATU
            ,:V0COBP-IMPMORACID
            ,:V0COBP-IMPDIT
            ,:V0COBP-QUANT-VIDAS
            ,:V0COBP-IMPINVPERM
            ,:V0COBP-IMPDH
            ,:V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I
            ,:V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I
            ,:V0COBP-VLCUSTCDG
            ,:V0COBP-IMPSEGCDG
            ,:V0COBP-VLCUSTCAP
            ,:V0COBP-QTTITCAP
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND DTINIVIG <= :V0PARC-DTVENCTO
            AND DTTERVIG >= :V0PARC-DTVENCTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
											,PRMAP
											,VLPREMIO
											,PRMVG + PRMAP
											,IMPMORNATU
											,IMPMORACID
											,IMPDIT
											,QUANT_VIDAS
											,IMPINVPERM
											,IMPDH
											,VLCUSTAUXF
											,IMPSEGAUXF
											,VLCUSTCDG
											,IMPSEGCDC
											,VLCUSTCAP
											,QTTITCAP
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0COBP_PRMTOT { get; set; }
        public string V0COBP_IMPMORNATU { get; set; }
        public string V0COBP_IMPMORACID { get; set; }
        public string V0COBP_IMPDIT { get; set; }
        public string V0COBP_QUANT_VIDAS { get; set; }
        public string V0COBP_IMPINVPERM { get; set; }
        public string V0COBP_IMPDH { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_VLCUSTAUXF_I { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0COBP_IMPSEGAUXF_I { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0COBP_IMPSEGCDG { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }
        public string V0COBP_QTTITCAP { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

        public static R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 Execute(R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 r0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBP_PRMVG = result[i++].Value?.ToString();
            dta.V0COBP_PRMAP = result[i++].Value?.ToString();
            dta.V0COBP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBP_PRMTOT = result[i++].Value?.ToString();
            dta.V0COBP_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0COBP_IMPMORACID = result[i++].Value?.ToString();
            dta.V0COBP_IMPDIT = result[i++].Value?.ToString();
            dta.V0COBP_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.V0COBP_IMPINVPERM = result[i++].Value?.ToString();
            dta.V0COBP_IMPDH = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_VLCUSTAUXF) ? "-1" : "0";
            dta.V0COBP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_IMPSEGAUXF) ? "-1" : "0";
            dta.V0COBP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.V0COBP_QTTITCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}