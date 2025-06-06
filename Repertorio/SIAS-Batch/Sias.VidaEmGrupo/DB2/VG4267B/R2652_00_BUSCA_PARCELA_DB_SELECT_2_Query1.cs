using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 : QueryBasis<R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG,
            QUANT_VIDAS,
            IMPSEGUR,
            OCORHIST
            INTO :V0COBP-DTINIVIG-PARC,
            :V0COBP-QUANT-VIDAS,
            :V0COBP-IMPSEGUR,
            :V0COBP-OCORHIST
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PARC-NRCERTIF
            AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG
            AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
							,
											QUANT_VIDAS
							,
											IMPSEGUR
							,
											OCORHIST
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PARC_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO_ORIG}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO_ORIG}'";

            return query;
        }
        public string V0COBP_DTINIVIG_PARC { get; set; }
        public string V0COBP_QUANT_VIDAS { get; set; }
        public string V0COBP_IMPSEGUR { get; set; }
        public string V0COBP_OCORHIST { get; set; }
        public string V0PARC_DTVENCTO_ORIG { get; set; }
        public string V0PARC_NRCERTIF { get; set; }

        public static R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 Execute(R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1)
        {
            var ths = r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0COBP_DTINIVIG_PARC = result[i++].Value?.ToString();
            dta.V0COBP_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGUR = result[i++].Value?.ToString();
            dta.V0COBP_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}