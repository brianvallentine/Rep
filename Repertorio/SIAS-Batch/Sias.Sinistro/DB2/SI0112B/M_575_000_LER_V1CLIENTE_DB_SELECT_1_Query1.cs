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
    public class M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 : QueryBasis<M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :CLIEN-NOME
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = :SEGVG-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = '{this.SEGVG_COD_CLIENTE}'";

            return query;
        }
        public string CLIEN_NOME { get; set; }
        public string SEGVG_COD_CLIENTE { get; set; }

        public static M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 Execute(M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIEN_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}