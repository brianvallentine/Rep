using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO,
            :DCLENDERECOS.ENDERECO-ENDERECO,
            :DCLENDERECOS.ENDERECO-BAIRRO,
            :DCLENDERECOS.ENDERECO-CIDADE,
            :DCLENDERECOS.ENDERECO-SIGLA-UF,
            :DCLENDERECOS.ENDERECO-CEP
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE
            AND ENDERECO = :DCLPESSOA-ENDERECO.ENDERECO
            AND BAIRRO = :DCLPESSOA-ENDERECO.BAIRRO
            AND CIDADE = :DCLPESSOA-ENDERECO.CIDADE
            AND SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF
            AND CEP = :DCLPESSOA-ENDERECO.CEP
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OCORR_ENDERECO
							,
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
											WHERE COD_CLIENTE = '{this.COD_CLIENTE}'
											AND ENDERECO = '{this.ENDERECO}'
											AND BAIRRO = '{this.BAIRRO}'
											AND CIDADE = '{this.CIDADE}'
											AND SIGLA_UF = '{this.SIGLA_UF}'
											AND CEP = '{this.CEP}'";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO { get; set; }
        public string SIGLA_UF { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string COD_CLIENTE { get; set; }
        public string CEP { get; set; }

        public static R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 Execute(R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}