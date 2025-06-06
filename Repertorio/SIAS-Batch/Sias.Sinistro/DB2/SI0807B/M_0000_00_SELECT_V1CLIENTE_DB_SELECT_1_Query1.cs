using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0807B
{
    public class M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V1CLIE-NOME
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :WHOST-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.WHOST_CODCLIEN}'";

            return query;
        }
        public string V1CLIE_NOME { get; set; }
        public string WHOST_CODCLIEN { get; set; }

        public static M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 Execute(M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLIE_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}