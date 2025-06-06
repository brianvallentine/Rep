using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1 : QueryBasis<M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(PCPARTIC)
            INTO :COSS-PCPARTIC:WPCPARTIC-IND
            FROM SEGUROS.V1APOLCOSCED
            WHERE NUM_APOLICE = :MEST-NUM-APOL
            AND DTINIVIG <= :MEST-DATORR
            AND DTTERVIG >= :MEST-DATORR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(PCPARTIC)
											FROM SEGUROS.V1APOLCOSCED
											WHERE NUM_APOLICE = '{this.MEST_NUM_APOL}'
											AND DTINIVIG <= '{this.MEST_DATORR}'
											AND DTTERVIG >= '{this.MEST_DATORR}'";

            return query;
        }
        public string COSS_PCPARTIC { get; set; }
        public string WPCPARTIC_IND { get; set; }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_DATORR { get; set; }

        public static M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1 Execute(M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1 m_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1)
        {
            var ths = m_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.COSS_PCPARTIC = result[i++].Value?.ToString();
            dta.WPCPARTIC_IND = string.IsNullOrWhiteSpace(dta.COSS_PCPARTIC) ? "-1" : "0";
            return dta;
        }

    }
}