using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1010_LE_FORNECEDOR_DB_SELECT_1_Query1 : QueryBasis<R1010_LE_FORNECEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FORNECEDOR,
            NOME_FORNECEDOR,
            COD_SERVICO_ISS,
            COD_BANCO
            INTO :FORNECED-COD-FORNECEDOR,
            :FORNECED-NOME-FORNECEDOR,
            :FORNECED-COD-SERVICO-ISS,
            :FORNECED-COD-BANCO
            FROM SEGUROS.FORNECEDORES
            WHERE COD_FORNECEDOR = :FORNECED-COD-FORNECEDOR
            AND TIPO_REGISTRO = '4'
            AND COD_SERVICO_ISS = :FORNECED-COD-SERVICO-ISS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FORNECEDOR
							,
											NOME_FORNECEDOR
							,
											COD_SERVICO_ISS
							,
											COD_BANCO
											FROM SEGUROS.FORNECEDORES
											WHERE COD_FORNECEDOR = '{this.FORNECED_COD_FORNECEDOR}'
											AND TIPO_REGISTRO = '4'
											AND COD_SERVICO_ISS = '{this.FORNECED_COD_SERVICO_ISS}'
											WITH UR";

            return query;
        }
        public string FORNECED_COD_FORNECEDOR { get; set; }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string FORNECED_COD_SERVICO_ISS { get; set; }
        public string FORNECED_COD_BANCO { get; set; }

        public static R1010_LE_FORNECEDOR_DB_SELECT_1_Query1 Execute(R1010_LE_FORNECEDOR_DB_SELECT_1_Query1 r1010_LE_FORNECEDOR_DB_SELECT_1_Query1)
        {
            var ths = r1010_LE_FORNECEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_LE_FORNECEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_LE_FORNECEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.FORNECED_COD_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_COD_SERVICO_ISS = result[i++].Value?.ToString();
            dta.FORNECED_COD_BANCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}