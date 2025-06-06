using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0005S
{
    public class P0110_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0110_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO_ENVIO
            ,COD_EMPRESA_SIVPF
            ,COD_PRODUTO_SIVPF
            INTO :SITUACAO-ENVIO
            ,:COD-EMPRESA-SIVPF
            ,:COD-PRODUTO-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_IDENTIFICACAO = :NUM-IDENTIFICACAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO_ENVIO
											,COD_EMPRESA_SIVPF
											,COD_PRODUTO_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_IDENTIFICACAO = '{this.NUM_IDENTIFICACAO}'
											WITH UR";

            return query;
        }
        public string SITUACAO_ENVIO { get; set; }
        public string COD_EMPRESA_SIVPF { get; set; }
        public string COD_PRODUTO_SIVPF { get; set; }
        public string NUM_IDENTIFICACAO { get; set; }

        public static P0110_05_INICIO_DB_SELECT_1_Query1 Execute(P0110_05_INICIO_DB_SELECT_1_Query1 p0110_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0110_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0110_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0110_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SITUACAO_ENVIO = result[i++].Value?.ToString();
            dta.COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}