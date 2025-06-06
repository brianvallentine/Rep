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
    public class R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG
            ,PRMAP
            ,DTVENCTO
            ,PRMVG + PRMAP
            INTO :V0PARC-PRMVG
            ,:V0PARC-PRMAP
            ,:V0PARC-DTVENCTO
            ,:V0PARC-PRMTOT
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCEL
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
											,PRMAP
											,DTVENCTO
											,PRMVG + PRMAP
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCOB_NRPARCEL}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_PRMTOT { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }

        public static R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 r0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PARC_PRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}