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
    public class M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 : QueryBasis<M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORDEM_CEDIDO
            INTO :V1ORDE-NRORDEM
            FROM SEGUROS.V1ORDECOSCED
            WHERE NUM_APOLICE = :V1MEST-NUM-APOL
            AND NRENDOS = :V1MEST-NRENDOS
            AND CODCOSS = :V1APCO-CODCOSS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORDEM_CEDIDO
											FROM SEGUROS.V1ORDECOSCED
											WHERE NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND NRENDOS = '{this.V1MEST_NRENDOS}'
											AND CODCOSS = '{this.V1APCO_CODCOSS}'";

            return query;
        }
        public string V1ORDE_NRORDEM { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_NRENDOS { get; set; }
        public string V1APCO_CODCOSS { get; set; }

        public static M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 Execute(M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1)
        {
            var ths = m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ORDE_NRORDEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}