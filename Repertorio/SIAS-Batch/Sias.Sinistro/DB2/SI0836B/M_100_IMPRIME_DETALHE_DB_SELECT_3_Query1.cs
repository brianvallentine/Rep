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
    public class M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1 : QueryBasis<M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V0CLIENTE-NOME-RAZAO
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0APOLICE-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0APOLICE_CODCLIEN}'";

            return query;
        }
        public string V0CLIENTE_NOME_RAZAO { get; set; }
        public string V0APOLICE_CODCLIEN { get; set; }

        public static M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1 Execute(M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1 m_100_IMPRIME_DETALHE_DB_SELECT_3_Query1)
        {
            var ths = m_100_IMPRIME_DETALHE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_100_IMPRIME_DETALHE_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}