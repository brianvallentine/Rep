using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R1100_00_MONTA_SORT_DB_SELECT_1_Query1 : QueryBasis<R1100_00_MONTA_SORT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE,
            CODCLIEN,
            CODPRODU,
            NUM_APOLICE,
            CODSUBES,
            DTQITBCO
            INTO :V0PRVA-FONTE,
            :V0PRVA-CODCLIEN,
            :V0PRVA-CODPRODU,
            :V0PRVA-NUM-APOLICE,
            :V0PRVA-CODSUBES,
            :V0PRVA-DTQITBCO
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :V0EVEN-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE
							,
											CODCLIEN
							,
											CODPRODU
							,
											NUM_APOLICE
							,
											CODSUBES
							,
											DTQITBCO
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.V0EVEN_NRCERTIF}'";

            return query;
        }
        public string V0PRVA_FONTE { get; set; }
        public string V0PRVA_CODCLIEN { get; set; }
        public string V0PRVA_CODPRODU { get; set; }
        public string V0PRVA_NUM_APOLICE { get; set; }
        public string V0PRVA_CODSUBES { get; set; }
        public string V0PRVA_DTQITBCO { get; set; }
        public string V0EVEN_NRCERTIF { get; set; }

        public static R1100_00_MONTA_SORT_DB_SELECT_1_Query1 Execute(R1100_00_MONTA_SORT_DB_SELECT_1_Query1 r1100_00_MONTA_SORT_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_MONTA_SORT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MONTA_SORT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MONTA_SORT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRVA_FONTE = result[i++].Value?.ToString();
            dta.V0PRVA_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PRVA_CODPRODU = result[i++].Value?.ToString();
            dta.V0PRVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PRVA_CODSUBES = result[i++].Value?.ToString();
            dta.V0PRVA_DTQITBCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}