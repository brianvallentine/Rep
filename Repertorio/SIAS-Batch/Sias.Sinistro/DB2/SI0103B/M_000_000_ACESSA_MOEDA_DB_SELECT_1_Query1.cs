using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0103B
{
    public class M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEUNIM
            INTO :V0MOEDA-SIGLUNIM
            FROM SEGUROS.V0MOEDA
            WHERE CODUNIMO = :V1HISTMEST-COD-MOEDA-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEUNIM
											FROM SEGUROS.V0MOEDA
											WHERE CODUNIMO = '{this.V1HISTMEST_COD_MOEDA_SINI}'";

            return query;
        }
        public string V0MOEDA_SIGLUNIM { get; set; }
        public string V1HISTMEST_COD_MOEDA_SINI { get; set; }

        public static M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1 Execute(M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1 m_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_000_000_ACESSA_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MOEDA_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}