using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0836B
{
    public class M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1 : QueryBasis<M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :V0SINIAUTO1-NUM-ITEM
            FROM SEGUROS.V0SINISTRO_AUTO1
            WHERE NUM_APOL_SINISTRO = :V0HISTMEST-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.V0SINISTRO_AUTO1
											WHERE NUM_APOL_SINISTRO = '{this.V0HISTMEST_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string V0SINIAUTO1_NUM_ITEM { get; set; }
        public string V0HISTMEST_NUM_APOL_SINISTRO { get; set; }

        public static M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1 Execute(M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1 m_100_IMPRIME_DETALHE_DB_SELECT_1_Query1)
        {
            var ths = m_100_IMPRIME_DETALHE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_100_IMPRIME_DETALHE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SINIAUTO1_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}