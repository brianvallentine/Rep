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
    public class R1200_00_GERA_PARCELAS_Query1 : QueryBasis<R1200_00_GERA_PARCELAS_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPRMTOT
            INTO :V0PARC-PRMTOTANT
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTVENCTO >= :V0COBP-DTINIVIG-1
            AND CODOPER IN (112,113)
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLPRMTOT
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTVENCTO >= '{this.V0COBP_DTINIVIG_1}'
											AND CODOPER IN (112
							,113)
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0PARC_PRMTOTANT { get; set; }
        public string V0COBP_DTINIVIG_1 { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1200_00_GERA_PARCELAS_Query1 Execute(R1200_00_GERA_PARCELAS_Query1 r1200_00_GERA_PARCELAS_Query1)
        {
            var ths = r1200_00_GERA_PARCELAS_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_GERA_PARCELAS_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_GERA_PARCELAS_Query1();
            var i = 0;
            dta.V0PARC_PRMTOTANT = result[i++].Value?.ToString();
            return dta;
        }

    }
}