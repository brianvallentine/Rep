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
    public class R0020_00_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<R0020_00_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP,
            PRMVG + PRMAP,
            OPCAOOPAG,
            DTVENCTO
            INTO :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-PRMTOT,
            :V0PARC-OPCAOPAG,
            :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0HCTA-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
							,
											PRMVG + PRMAP
							,
											OPCAOOPAG
							,
											DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCTA_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_PRMTOT { get; set; }
        public string V0PARC_OPCAOPAG { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static R0020_00_PROCESSA_DB_SELECT_1_Query1 Execute(R0020_00_PROCESSA_DB_SELECT_1_Query1 r0020_00_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = r0020_00_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_PRMTOT = result[i++].Value?.ToString();
            dta.V0PARC_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}