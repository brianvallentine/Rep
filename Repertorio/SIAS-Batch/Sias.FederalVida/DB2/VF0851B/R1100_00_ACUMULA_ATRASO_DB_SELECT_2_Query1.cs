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
    public class R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1 : QueryBasis<R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(B.NRTIT),0)
            INTO :V0HCOB-NRTIT
            FROM SEGUROS.V0HISTCOBVA A,
            SEGUROS.V0COMPTITVA B
            WHERE A.NRCERTIF = :V0PROP-NRCERTIF
            AND B.NRTIT = A.NRTIT
            AND B.NRPARCEL = :V0PARC-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(B.NRTIT)
							,0)
											FROM SEGUROS.V0HISTCOBVA A
							,
											SEGUROS.V0COMPTITVA B
											WHERE A.NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND B.NRTIT = A.NRTIT
											AND B.NRPARCEL = '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1 Execute(R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1 r1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1)
        {
            var ths = r1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_ACUMULA_ATRASO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}