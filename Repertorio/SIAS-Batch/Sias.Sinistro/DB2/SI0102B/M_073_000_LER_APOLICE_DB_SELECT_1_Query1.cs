using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class M_073_000_LER_APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_073_000_LER_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN
            INTO :SEGV-CLIENTE
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE= :TAPDCORR-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE= '{this.TAPDCORR_NUM_APOL}'";

            return query;
        }
        public string SEGV_CLIENTE { get; set; }
        public string TAPDCORR_NUM_APOL { get; set; }

        public static M_073_000_LER_APOLICE_DB_SELECT_1_Query1 Execute(M_073_000_LER_APOLICE_DB_SELECT_1_Query1 m_073_000_LER_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_073_000_LER_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_073_000_LER_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_073_000_LER_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGV_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}