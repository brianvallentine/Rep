using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1110B
{
    public class P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CLIENTES.CGCCPF
            ,VALUE(CLIENTES.NOME_RAZAO, ' ' )
            INTO :CLIENTES-CGCCPF
            ,:CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES CLIENTES
            WHERE CLIENTES.COD_CLIENTE = :PROPOVA-COD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CLIENTES.CGCCPF
											,VALUE(CLIENTES.NOME_RAZAO
							, ' ' )
											FROM SEGUROS.CLIENTES CLIENTES
											WHERE CLIENTES.COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1 Execute(P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1 p2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = p2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}