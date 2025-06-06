using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1 : QueryBasis<R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1>
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
            INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO,
            :DCLPESSOA-ENDERECO.ENDERECO,
            :DCLPESSOA-ENDERECO.BAIRRO,
            :DCLPESSOA-ENDERECO.CIDADE,
            :DCLPESSOA-ENDERECO.SIGLA-UF,
            :DCLPESSOA-ENDERECO.CEP
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            AND TIPO_ENDER = 2
            AND SITUACAO_ENDERECO = 'A'
            AND OCORR_ENDERECO =
            :DCLPESSOA-ENDERECO.OCORR-ENDERECO
            WITH UR
            END-EXEC.
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
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											AND TIPO_ENDER = 2
											AND SITUACAO_ENDERECO = 'A'
											AND OCORR_ENDERECO =
											'{this.OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string OCORR_ENDERECO { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_UF { get; set; }
        public string CEP { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }

        public static R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1 Execute(R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1 r0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1)
        {
            var ths = r0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1();
            var i = 0;
            dta.OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO = result[i++].Value?.ToString();
            dta.BAIRRO = result[i++].Value?.ToString();
            dta.CIDADE = result[i++].Value?.ToString();
            dta.SIGLA_UF = result[i++].Value?.ToString();
            dta.CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}