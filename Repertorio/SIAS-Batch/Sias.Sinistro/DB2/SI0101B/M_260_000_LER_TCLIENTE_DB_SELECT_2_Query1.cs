using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0101B
{
    public class M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1 : QueryBasis<M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO
            :CLIE-NOME-RAZAO
            FROM
            SEGUROS.V0CLIENTE
            WHERE
            COD_CLIENTE = :CLIE-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM
											SEGUROS.V0CLIENTE
											WHERE
											COD_CLIENTE = '{this.CLIE_COD_CLIENTE}'";

            return query;
        }
        public string CLIE_NOME_RAZAO { get; set; }
        public string CLIE_COD_CLIENTE { get; set; }

        public static M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1 Execute(M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1 m_260_000_LER_TCLIENTE_DB_SELECT_2_Query1)
        {
            var ths = m_260_000_LER_TCLIENTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_260_000_LER_TCLIENTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}