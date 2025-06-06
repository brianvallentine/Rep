using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0111B
{
    public class M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1 : QueryBasis<M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE
            INTO :V1FONTE-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1HISTMEST-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1HISTMEST_FONTE}'";

            return query;
        }
        public string V1FONTE_NOMEFTE { get; set; }
        public string V1HISTMEST_FONTE { get; set; }

        public static M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1 Execute(M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1 m_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1)
        {
            var ths = m_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_400_SELECT_V1FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONTE_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}