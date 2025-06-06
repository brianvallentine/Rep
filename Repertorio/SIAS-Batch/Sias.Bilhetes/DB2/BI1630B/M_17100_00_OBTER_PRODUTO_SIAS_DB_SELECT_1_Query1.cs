using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1 : QueryBasis<M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_PRODUTO, 0) ,
            VALUE(COD_PLANO, 0)
            INTO :PRDSIVPF-COD-PRODUTO ,
            :PRDSIVPF-COD-PLANO
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_EMPRESA_SIVPF = 1
            AND COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF
            AND DTH_FIM_VIGENCIA = '9999-12-31'
            AND COD_PLANO = :PROPOFID-COD-PLANO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_PRODUTO
							, 0) 
							,
											VALUE(COD_PLANO
							, 0)
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_EMPRESA_SIVPF = 1
											AND COD_PRODUTO_SIVPF = '{this.PROPOFID_COD_PRODUTO_SIVPF}'
											AND DTH_FIM_VIGENCIA = '9999-12-31'
											AND COD_PLANO = '{this.PROPOFID_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string PRDSIVPF_COD_PRODUTO { get; set; }
        public string PRDSIVPF_COD_PLANO { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }

        public static M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1 Execute(M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1 m_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1)
        {
            var ths = m_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}