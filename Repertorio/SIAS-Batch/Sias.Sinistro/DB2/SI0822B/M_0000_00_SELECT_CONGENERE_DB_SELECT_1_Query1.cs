using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0822B
{
    public class M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMECONG
            INTO :V0CONGENERE-NOMECONG
            FROM SEGUROS.V0CONGENERE
            WHERE CONGENER = :V0CONGENERE-CONGENER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMECONG
											FROM SEGUROS.V0CONGENERE
											WHERE CONGENER = '{this.V0CONGENERE_CONGENER}'";

            return query;
        }
        public string V0CONGENERE_NOMECONG { get; set; }
        public string V0CONGENERE_CONGENER { get; set; }

        public static M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1 Execute(M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1 m_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONGENERE_NOMECONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}