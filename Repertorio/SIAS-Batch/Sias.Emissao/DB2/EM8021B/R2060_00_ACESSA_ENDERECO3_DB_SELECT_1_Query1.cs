using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1 : QueryBasis<R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP,
            VALUE(DES_COMPLEMENTO, ' ' )
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            :ENDERECO-DES-COMPLEMENTO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE
            AND OCORR_ENDERECO =
            (SELECT MAX(OCORR_ENDERECO)
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
							,
											VALUE(DES_COMPLEMENTO
							, ' ' )
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.SINIITEM_COD_CLIENTE}'
											AND OCORR_ENDERECO =
											(SELECT MAX(OCORR_ENDERECO)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.SINIITEM_COD_CLIENTE}')
											WITH UR";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DES_COMPLEMENTO { get; set; }
        public string SINIITEM_COD_CLIENTE { get; set; }

        public static R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1 Execute(R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1 r2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1)
        {
            var ths = r2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DES_COMPLEMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}