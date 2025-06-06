using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1 : QueryBasis<DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :H-COD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.H_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string H_COD_CLIENTE { get; set; }

        public static DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1 Execute(DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1 dB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1)
        {
            var ths = dB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}