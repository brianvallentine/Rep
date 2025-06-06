using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1473B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1>
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
            TELEFONE
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            :ENDERECO-TELEFONE
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            AND OCORR_ENDERECO = :PROPOVA-OCOREND
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
											TELEFONE
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.PROPOVA_OCOREND}'";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}