using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SEQ_PRD_PROPOSTA
            INTO
            :PRDSIVPF-SEQ-PRD-PROPOSTA:VIND-SEQ-NUM
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF
            AND COD_PRODUTO = :PROPOVA-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SEQ_PRD_PROPOSTA
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_PRODUTO_SIVPF = '{this.PROPOFID_COD_PRODUTO_SIVPF}'
											AND COD_PRODUTO = '{this.PROPOVA_COD_PRODUTO}'";

            return query;
        }
        public string PRDSIVPF_SEQ_PRD_PROPOSTA { get; set; }
        public string VIND_SEQ_NUM { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }

        public static R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1 Execute(R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1 r1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_SEQ_PRD_PROPOSTA = result[i++].Value?.ToString();
            dta.VIND_SEQ_NUM = string.IsNullOrWhiteSpace(dta.PRDSIVPF_SEQ_PRD_PROPOSTA) ? "-1" : "0";
            return dta;
        }

    }
}