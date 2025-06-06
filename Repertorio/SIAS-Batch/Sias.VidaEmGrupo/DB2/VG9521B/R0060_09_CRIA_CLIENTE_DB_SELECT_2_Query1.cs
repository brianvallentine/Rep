using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1 : QueryBasis<R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO
            :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP
            FROM SEGUROS.ENDERECOS
            WHERE
            COD_CLIENTE = :SUBGVGAP-COD-CLIENTE
            AND OCORR_ENDERECO = :SUBGVGAP-OCORR-ENDERECO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
											FROM SEGUROS.ENDERECOS
											WHERE
											COD_CLIENTE = '{this.SUBGVGAP_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.SUBGVGAP_OCORR_ENDERECO}'";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }

        public static R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1 Execute(R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1 r0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1)
        {
            var ths = r0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}