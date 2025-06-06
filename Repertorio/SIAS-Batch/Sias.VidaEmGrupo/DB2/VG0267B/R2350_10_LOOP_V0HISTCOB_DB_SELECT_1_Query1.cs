using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1 : QueryBasis<R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP,
            VLMULTA
            INTO :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-VLMULTA
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HIST-NRCERTIF
            AND NRPARCEL = :V0HIST-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
							,
											VLMULTA
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HIST_NRCERTIF}'
											AND NRPARCEL = '{this.V0HIST_NRPARCEL}'";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_VLMULTA { get; set; }
        public string V0HIST_NRCERTIF { get; set; }
        public string V0HIST_NRPARCEL { get; set; }

        public static R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1 Execute(R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1 r2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1)
        {
            var ths = r2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_VLMULTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}