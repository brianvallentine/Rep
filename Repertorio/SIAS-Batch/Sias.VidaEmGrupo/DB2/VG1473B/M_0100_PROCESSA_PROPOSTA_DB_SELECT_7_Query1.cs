using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
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
            TELEFONE,
            DES_COMPLEMENTO,
            DDD
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            :ENDERECO-TELEFONE,
            :ENDERECO-DES-COMPLEMENTO:ENDERECO-DES-COMPLEMENTO-I,
            :ENDERECO-DDD
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO
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
											TELEFONE
							,
											DES_COMPLEMENTO
							,
											DDD
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.SEGURVGA_OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_DES_COMPLEMENTO { get; set; }
        public string ENDERECO_DES_COMPLEMENTO_I { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

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
            dta.ENDERECO_DES_COMPLEMENTO = result[i++].Value?.ToString();
            dta.ENDERECO_DES_COMPLEMENTO_I = string.IsNullOrWhiteSpace(dta.ENDERECO_DES_COMPLEMENTO) ? "-1" : "0";
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            return dta;
        }

    }
}