using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            TIPO_PESSOA,
            CGCCPF
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-TIPO-PESSOA,
            :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											TIPO_PESSOA
							,
											CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.SINIITEM_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string SINIITEM_COD_CLIENTE { get; set; }

        public static R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 Execute(R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 r2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}