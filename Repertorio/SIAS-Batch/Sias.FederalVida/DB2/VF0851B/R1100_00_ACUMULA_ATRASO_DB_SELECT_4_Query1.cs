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
    public class R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1 : QueryBasis<R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS
            INTO :V0HCTA-NSAS:WS-NULL1
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            AND SITUACAO IN ( '0' , '3' )
            FETCH FIRST 1 ROW ONLY
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NSAS
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'
											AND SITUACAO IN ( '0' 
							, '3' )
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string V0HCTA_NSAS { get; set; }
        public string WS_NULL1 { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1 Execute(R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1 r1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1)
        {
            var ths = r1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_ACUMULA_ATRASO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0HCTA_NSAS = result[i++].Value?.ToString();
            dta.WS_NULL1 = string.IsNullOrWhiteSpace(dta.V0HCTA_NSAS) ? "-1" : "0";
            return dta;
        }

    }
}