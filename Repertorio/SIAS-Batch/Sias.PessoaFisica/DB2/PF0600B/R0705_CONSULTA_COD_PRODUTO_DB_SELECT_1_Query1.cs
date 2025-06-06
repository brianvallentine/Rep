using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_PRODUTO, 0)
            INTO :PRDSIVPF-COD-PRODUTO
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_EMPRESA_SIVPF = 1
            AND COD_PRODUTO_SIVPF = :PRDSIVPF-COD-PRODUTO-SIVPF
            AND DTH_FIM_VIGENCIA = '9999-12-31'
            AND COD_PLANO = :PRDSIVPF-COD-PLANO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_PRODUTO
							, 0)
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_EMPRESA_SIVPF = 1
											AND COD_PRODUTO_SIVPF = '{this.PRDSIVPF_COD_PRODUTO_SIVPF}'
											AND DTH_FIM_VIGENCIA = '9999-12-31'
											AND COD_PLANO = '{this.PRDSIVPF_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string PRDSIVPF_COD_PRODUTO { get; set; }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }
        public string PRDSIVPF_COD_PLANO { get; set; }

        public static R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1 Execute(R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1 r0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}