using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1 : QueryBasis<M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT COD_EMPRESA_SIVPF
            INTO :PRDSIVPF-COD-EMPRESA-SIVPF
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_PRODUTO_SIVPF = :PRDSIVPF-COD-PRODUTO-SIVPF
            AND DTH_FIM_VIGENCIA = '9999-12-31'
            ORDER BY COD_EMPRESA_SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT COD_EMPRESA_SIVPF
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_PRODUTO_SIVPF = '{this.PRDSIVPF_COD_PRODUTO_SIVPF}'
											AND DTH_FIM_VIGENCIA = '9999-12-31'
											ORDER BY COD_EMPRESA_SIVPF
											WITH UR";

            return query;
        }
        public string PRDSIVPF_COD_EMPRESA_SIVPF { get; set; }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }

        public static M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1 Execute(M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1 m_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = m_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}