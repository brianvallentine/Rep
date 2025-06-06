using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_0000_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMTIT
            INTO :CEDENT-NRTIT
            FROM SEGUROS.V0CEDENTE
            WHERE CODCDT = 19
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMTIT
											FROM SEGUROS.V0CEDENTE
											WHERE CODCDT = 19";

            return query;
        }
        public string CEDENT_NRTIT { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_2_Query1 m_0000_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.CEDENT_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}