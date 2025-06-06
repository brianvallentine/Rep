using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_334_000_LER_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<M_334_000_LER_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOME_RAZAO
            INTO :V1CLI-NOME-RAZAO
            FROM
            SEGUROS.V1CLIENTE
            WHERE
            COD_CLIENTE = :V1SEGVG-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME_RAZAO
											FROM
											SEGUROS.V1CLIENTE
											WHERE
											COD_CLIENTE = '{this.V1SEGVG_CLIENTE}'";

            return query;
        }
        public string V1CLI_NOME_RAZAO { get; set; }
        public string V1SEGVG_CLIENTE { get; set; }

        public static M_334_000_LER_CLIENTE_DB_SELECT_1_Query1 Execute(M_334_000_LER_CLIENTE_DB_SELECT_1_Query1 m_334_000_LER_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = m_334_000_LER_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_334_000_LER_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_334_000_LER_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLI_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}