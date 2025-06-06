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
    public class DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_CLIENTE),0)
            INTO :CLIENTES-COD-CLIENTE
            FROM SEGUROS.CLIENTES
            WHERE CGCCPF = :CLIENTES-CGCCPF
            AND TIPO_PESSOA = :H-TIPO-PESSOA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_CLIENTE)
							,0)
											FROM SEGUROS.CLIENTES
											WHERE CGCCPF = '{this.CLIENTES_CGCCPF}'
											AND TIPO_PESSOA = '{this.H_TIPO_PESSOA}'";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string H_TIPO_PESSOA { get; set; }

        public static DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1 Execute(DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1 dB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = dB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}