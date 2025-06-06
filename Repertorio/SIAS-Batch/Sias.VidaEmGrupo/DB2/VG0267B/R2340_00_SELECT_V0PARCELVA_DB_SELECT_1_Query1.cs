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
    public class R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 : QueryBasis<R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG + PRMAP - VLMULTA,
            DTVENCTO,
            PRMVG,
            PRMAP,
            VLMULTA
            INTO :V0PARC-VLPRMTOT,
            :V0PARC-DTVENCTO,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-VLMULTA
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :WHOST-NRCERTIF
            AND NRPARCEL = :WHOST-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG + PRMAP - VLMULTA
							,
											DTVENCTO
							,
											PRMVG
							,
											PRMAP
							,
											VLMULTA
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.WHOST_NRCERTIF}'
											AND NRPARCEL = '{this.WHOST_NRPARCEL}'";

            return query;
        }
        public string V0PARC_VLPRMTOT { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_VLMULTA { get; set; }
        public string WHOST_NRCERTIF { get; set; }
        public string WHOST_NRPARCEL { get; set; }

        public static R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 Execute(R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1)
        {
            var ths = r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_VLMULTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}