using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 : QueryBasis<M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMECONG
            INTO :V1CONGE-NOMECONG
            FROM SEGUROS.V1CONGENERE
            WHERE CONGENER = :V1RELA-CONGE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMECONG
											FROM SEGUROS.V1CONGENERE
											WHERE CONGENER = '{this.V1RELA_CONGE}'";

            return query;
        }
        public string V1CONGE_NOMECONG { get; set; }
        public string V1RELA_CONGE { get; set; }

        public static M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 Execute(M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1)
        {
            var ths = m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CONGE_NOMECONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}