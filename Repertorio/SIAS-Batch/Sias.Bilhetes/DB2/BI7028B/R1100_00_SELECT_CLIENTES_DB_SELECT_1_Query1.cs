using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF,
            DATA_NASCIMENTO,
            TIPO_PESSOA
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-CGCCPF,
            :CLIENTES-DATA-NASCIMENTO,
            :CLIENTES-TIPO-PESSOA
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :BILHETE-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
							,
											DATA_NASCIMENTO
							,
											TIPO_PESSOA
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.BILHETE_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }

        public static R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}