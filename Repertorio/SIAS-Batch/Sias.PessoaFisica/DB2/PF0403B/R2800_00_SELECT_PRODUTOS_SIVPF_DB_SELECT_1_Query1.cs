using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0403B
{
    public class R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOME_PRODUTO
            INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-NOME-PRODUTO
            FROM SEGUROS.PRODUTOS_SIVPF A
            WHERE A.COD_EMPRESA_SIVPF =
            :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF
            AND A.COD_PRODUTO_SIVPF =
            :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF
            AND A.COD_PRODUTO =
            (SELECT MIN(B.COD_PRODUTO)
            FROM SEGUROS.PRODUTOS_SIVPF B
            WHERE B.COD_EMPRESA_SIVPF = A.COD_EMPRESA_SIVPF
            AND B.COD_PRODUTO_SIVPF = A.COD_PRODUTO_SIVPF)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOME_PRODUTO
											FROM SEGUROS.PRODUTOS_SIVPF A
											WHERE A.COD_EMPRESA_SIVPF =
											'{this.PRDSIVPF_COD_EMPRESA_SIVPF}'
											AND A.COD_PRODUTO_SIVPF =
											'{this.PRDSIVPF_COD_PRODUTO_SIVPF}'
											AND A.COD_PRODUTO =
											(SELECT MIN(B.COD_PRODUTO)
											FROM SEGUROS.PRODUTOS_SIVPF B
											WHERE B.COD_EMPRESA_SIVPF = A.COD_EMPRESA_SIVPF
											AND B.COD_PRODUTO_SIVPF = A.COD_PRODUTO_SIVPF)
											WITH UR";

            return query;
        }
        public string PRDSIVPF_NOME_PRODUTO { get; set; }
        public string PRDSIVPF_COD_EMPRESA_SIVPF { get; set; }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }

        public static R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1 Execute(R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1 r2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}