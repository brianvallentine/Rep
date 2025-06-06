using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 : QueryBasis<R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            CEP,
            SIGLA_UF
            INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO,
            :DCLPESSOA-ENDERECO.ENDERECO,
            :DCLPESSOA-ENDERECO.BAIRRO,
            :DCLPESSOA-ENDERECO.CIDADE,
            :DCLPESSOA-ENDERECO.CEP,
            :DCLPESSOA-ENDERECO.SIGLA-UF
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA
            AND OCORR_ENDERECO =
            :DCLPROPOSTAS-VA.OCOREND
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
											CEP
							,
											SIGLA_UF
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA =
											'{this.PROPOFID_COD_PESSOA}'
											AND OCORR_ENDERECO =
											'{this.OCOREND}'";

            return query;
        }
        public string OCORR_ENDERECO { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string CEP { get; set; }
        public string SIGLA_UF { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string OCOREND { get; set; }

        public static R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 Execute(R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1)
        {
            var ths = r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO = result[i++].Value?.ToString();
            dta.BAIRRO = result[i++].Value?.ToString();
            dta.CIDADE = result[i++].Value?.ToString();
            dta.CEP = result[i++].Value?.ToString();
            dta.SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}