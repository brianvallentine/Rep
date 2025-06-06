using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PRMDIFVG+PRMDIFAP),0)
            INTO :V0DIFP-VLPRMTOT
            FROM SEGUROS.V0DIFPARCELVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = 9999
            AND SITUACAO = ' '
            AND CODOPER >= 600
            AND CODOPER <= 699
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PRMDIFVG+PRMDIFAP)
							,0)
											FROM SEGUROS.V0DIFPARCELVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = 9999
											AND SITUACAO = ' '
											AND CODOPER >= 600
											AND CODOPER <= 699";

            return query;
        }
        public string V0DIFP_VLPRMTOT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1 Execute(R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1 r1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_ACUMULA_ATRASO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0DIFP_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}