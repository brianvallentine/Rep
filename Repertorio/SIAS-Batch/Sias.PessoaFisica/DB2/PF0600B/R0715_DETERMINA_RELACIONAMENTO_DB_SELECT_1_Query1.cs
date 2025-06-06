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
    public class R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 : QueryBasis<R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT COD_PRODUTO_SIVPF,
            COD_RELAC,
            COD_EMPRESA_SIVPF
            INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF,
            :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC,
            :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_PRODUTO_SIVPF =
            :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF
            AND DTH_INI_VIGENCIA <
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO
            AND DTH_FIM_VIGENCIA >
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO
            ORDER BY COD_PRODUTO_SIVPF, COD_RELAC, COD_EMPRESA_SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT COD_PRODUTO_SIVPF
							,
											COD_RELAC
							,
											COD_EMPRESA_SIVPF
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_PRODUTO_SIVPF =
											'{this.PRDSIVPF_COD_PRODUTO_SIVPF}'
											AND DTH_INI_VIGENCIA <
											'{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND DTH_FIM_VIGENCIA >
											'{this.SISTEMAS_DATA_MOV_ABERTO}'
											ORDER BY COD_PRODUTO_SIVPF
							, COD_RELAC
							, COD_EMPRESA_SIVPF
											WITH UR";

            return query;
        }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }
        public string PRDSIVPF_COD_EMPRESA_SIVPF { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 Execute(R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_RELAC = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}