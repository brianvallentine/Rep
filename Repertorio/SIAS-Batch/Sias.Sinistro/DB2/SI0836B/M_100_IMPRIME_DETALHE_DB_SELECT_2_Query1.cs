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
    public class M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1 : QueryBasis<M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN
            INTO :V0APOLICE-CODCLIEN
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :V0HISTMEST-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.V0HISTMEST_NUM_APOLICE}'";

            return query;
        }
        public string V0APOLICE_CODCLIEN { get; set; }
        public string V0HISTMEST_NUM_APOLICE { get; set; }

        public static M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1 Execute(M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1 m_100_IMPRIME_DETALHE_DB_SELECT_2_Query1)
        {
            var ths = m_100_IMPRIME_DETALHE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_100_IMPRIME_DETALHE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0APOLICE_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}