using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0268B
{
    public class R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            VLPREMIO,
            DTINIVIG,
            IMPSEGCDC
            INTO :V0COBE-IMPMORNATU,
            :V0COBE-VLPREMIO,
            :V0COBE-DTINIVIG,
            :V0COBE-IMPSEGCDG
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :WHOST-NRCERTIF
            AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG
            AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
							,
											VLPREMIO
							,
											DTINIVIG
							,
											IMPSEGCDC
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.WHOST_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO_ORIG}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO_ORIG}'";

            return query;
        }
        public string V0COBE_IMPMORNATU { get; set; }
        public string V0COBE_VLPREMIO { get; set; }
        public string V0COBE_DTINIVIG { get; set; }
        public string V0COBE_IMPSEGCDG { get; set; }
        public string V0PARC_DTVENCTO_ORIG { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 Execute(R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBE_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0COBE_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBE_DTINIVIG = result[i++].Value?.ToString();
            dta.V0COBE_IMPSEGCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}