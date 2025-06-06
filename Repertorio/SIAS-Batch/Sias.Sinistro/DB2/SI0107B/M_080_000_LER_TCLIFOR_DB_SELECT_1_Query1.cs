using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0107B
{
    public class M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1 : QueryBasis<M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NOME
            INTO
            :TCLIFOR-NOME
            FROM SEGUROS.V1FORNECEDOR
            WHERE
            CLIFOR = :HOST-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME
											FROM SEGUROS.V1FORNECEDOR
											WHERE
											CLIFOR = '{this.HOST_CODPDT}'";

            return query;
        }
        public string TCLIFOR_NOME { get; set; }
        public string HOST_CODPDT { get; set; }

        public static M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1 Execute(M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1 m_080_000_LER_TCLIFOR_DB_SELECT_1_Query1)
        {
            var ths = m_080_000_LER_TCLIFOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_080_000_LER_TCLIFOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.TCLIFOR_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}