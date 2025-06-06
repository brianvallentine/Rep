using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 : QueryBasis<M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD,
            GARAN_ADIC_HD
            INTO :V1COND-GARAN-IEA,
            :V1COND-GARAN-IPA,
            :V1COND-GARAN-IPD,
            :V1COND-GARAN-HD
            FROM SEGUROS.V1CONDTEC
            WHERE NUM_APOLICE = :V1MEST-NUM-APOL
            AND COD_SUBGRUPO = :V1MEST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
							,
											GARAN_ADIC_HD
											FROM SEGUROS.V1CONDTEC
											WHERE NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1MEST_CODSUBES}'";

            return query;
        }
        public string V1COND_GARAN_IEA { get; set; }
        public string V1COND_GARAN_IPA { get; set; }
        public string V1COND_GARAN_IPD { get; set; }
        public string V1COND_GARAN_HD { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_CODSUBES { get; set; }

        public static M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 Execute(M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1)
        {
            var ths = m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COND_GARAN_IEA = result[i++].Value?.ToString();
            dta.V1COND_GARAN_IPA = result[i++].Value?.ToString();
            dta.V1COND_GARAN_IPD = result[i++].Value?.ToString();
            dta.V1COND_GARAN_HD = result[i++].Value?.ToString();
            return dta;
        }

    }
}