using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class R1000_SELECT_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1000_SELECT_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO,
            C.TIPO_PESSOA,
            C.CGCCPF
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-TIPO-PESSOA,
            :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES C
            WHERE C.COD_CLIENTE = :APOLIAUT-COD-CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
							,
											C.TIPO_PESSOA
							,
											C.CGCCPF
											FROM SEGUROS.CLIENTES C
											WHERE C.COD_CLIENTE = '{this.APOLIAUT_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string APOLIAUT_COD_CLIENTE { get; set; }

        public static R1000_SELECT_CLIENTE_DB_SELECT_1_Query1 Execute(R1000_SELECT_CLIENTE_DB_SELECT_1_Query1 r1000_SELECT_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1000_SELECT_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_SELECT_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_SELECT_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}