using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1 : QueryBasis<M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (VALCPR / 100 ) + 1
            INTO :W-V0COTACAO-VALCPR
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = 24
            AND DTINIVIG <= :V0COTACAO-DTINIVIG
            AND DTTERVIG >= :V0COTACAO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (VALCPR / 100 ) + 1
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = 24
											AND DTINIVIG <= '{this.V0COTACAO_DTINIVIG}'
											AND DTTERVIG >= '{this.V0COTACAO_DTINIVIG}'";

            return query;
        }
        public string W_V0COTACAO_VALCPR { get; set; }
        public string V0COTACAO_DTINIVIG { get; set; }

        public static M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1 Execute(M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1 m_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1)
        {
            var ths = m_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_V0COTACAO_VALCPR = result[i++].Value?.ToString();
            return dta;
        }

    }
}