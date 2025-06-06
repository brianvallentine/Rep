using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_1000_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU
            INTO :V0PROD-CODPRODU
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :V1SEGV-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.V1SEGV_NRCERTIF}'";

            return query;
        }
        public string V0PROD_CODPRODU { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }

        public static M_1000_PROCESSA_DB_SELECT_1_Query1 Execute(M_1000_PROCESSA_DB_SELECT_1_Query1 m_1000_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_1000_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}