using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA_SIVPF
            , COD_PRODUTO_SIVPF
            , COD_PRODUTO
            , COD_RELAC
            INTO :PRDSIVPF-COD-EMPRESA-SIVPF
            ,:PRDSIVPF-COD-PRODUTO-SIVPF
            ,:PRDSIVPF-COD-PRODUTO
            ,:PRDSIVPF-COD-RELAC
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_EMPRESA_SIVPF = 1
            AND COD_PRODUTO = :PRDSIVPF-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA_SIVPF
											, COD_PRODUTO_SIVPF
											, COD_PRODUTO
											, COD_RELAC
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_EMPRESA_SIVPF = 1
											AND COD_PRODUTO = '{this.PRDSIVPF_COD_PRODUTO}'";

            return query;
        }
        public string PRDSIVPF_COD_EMPRESA_SIVPF { get; set; }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }
        public string PRDSIVPF_COD_PRODUTO { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }

        public static R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 Execute(R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_RELAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}