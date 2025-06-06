using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :WS-COD-CLI-ATU
            FROM SEGUROS.CLIENTES
            WHERE CGCCPF = :BI0005L-S-CPF
            AND DATA_NASCIMENTO = :BI0005L-S-DATA-NASC
            AND NOME_RAZAO <> ' '
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.CLIENTES
											WHERE CGCCPF = '{this.BI0005L_S_CPF}'
											AND DATA_NASCIMENTO = '{this.BI0005L_S_DATA_NASC}'
											AND NOME_RAZAO <> ' '
											WITH UR";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string BI0005L_S_DATA_NASC { get; set; }
        public string BI0005L_S_CPF { get; set; }

        public static M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1 Execute(M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1 m_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = m_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_CLI_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}