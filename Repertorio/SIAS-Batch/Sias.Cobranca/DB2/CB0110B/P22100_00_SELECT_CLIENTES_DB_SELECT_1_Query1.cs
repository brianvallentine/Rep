using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            ,NOME_RAZAO
            ,TIPO_PESSOA
            ,CGCCPF
            INTO :CLIENTES-COD-CLIENTE
            ,:CLIENTES-NOME-RAZAO
            ,:CLIENTES-TIPO-PESSOA
            ,:CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											,NOME_RAZAO
											,TIPO_PESSOA
											,CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 p22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = p22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}