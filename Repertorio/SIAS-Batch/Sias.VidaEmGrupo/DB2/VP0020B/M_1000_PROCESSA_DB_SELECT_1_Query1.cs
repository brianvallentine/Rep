using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1000_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_1000_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUREG,
            COD_UNIDADE,
            DIG_UNIDADE,
            NOME_UNIDADE,
            NOME_FUNCIONARIO,
            TIPO_VINCULO,
            NASCIMENTO,
            NUM_CPF,
            ENDERECO_CEF,
            CIDADE_CEF,
            SIGLA_UF,
            CEP,
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA,
            COD_ANGARIADOR
            INTO
            :SQL-SUREG,
            :SQL-UNIDADE,
            :SQL-DV,
            :SQLCEF-NOME-UNID,
            :SQL-NOME-FUNC,
            :SQL-TIPO-VINC,
            :SQL-DATA-NASC,
            :SQL-CPF,
            :SQL-ENDERECO,
            :SQL-CIDADE,
            :SQL-UF,
            :SQL-CEP,
            :SQL-AGENCIA,
            :SQL-OPERACAO,
            :SQL-CONTA,
            :SQL-DV-CONTA,
            :SQL-ANGARIADOR:SQL-IND-ANGAR
            FROM SEGUROS.V0FUNCIOCEF
            WHERE NUM_MATRICULA = :SQL-MATRICULA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUREG
							,
											COD_UNIDADE
							,
											DIG_UNIDADE
							,
											NOME_UNIDADE
							,
											NOME_FUNCIONARIO
							,
											TIPO_VINCULO
							,
											NASCIMENTO
							,
											NUM_CPF
							,
											ENDERECO_CEF
							,
											CIDADE_CEF
							,
											SIGLA_UF
							,
											CEP
							,
											COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
							,
											COD_ANGARIADOR
											FROM SEGUROS.V0FUNCIOCEF
											WHERE NUM_MATRICULA = '{this.SQL_MATRICULA}'";

            return query;
        }
        public string SQL_SUREG { get; set; }
        public string SQL_UNIDADE { get; set; }
        public string SQL_DV { get; set; }
        public string SQLCEF_NOME_UNID { get; set; }
        public string SQL_NOME_FUNC { get; set; }
        public string SQL_TIPO_VINC { get; set; }
        public string SQL_DATA_NASC { get; set; }
        public string SQL_CPF { get; set; }
        public string SQL_ENDERECO { get; set; }
        public string SQL_CIDADE { get; set; }
        public string SQL_UF { get; set; }
        public string SQL_CEP { get; set; }
        public string SQL_AGENCIA { get; set; }
        public string SQL_OPERACAO { get; set; }
        public string SQL_CONTA { get; set; }
        public string SQL_DV_CONTA { get; set; }
        public string SQL_ANGARIADOR { get; set; }
        public string SQL_IND_ANGAR { get; set; }
        public string SQL_MATRICULA { get; set; }

        public static M_1000_PROCESSA_DB_SELECT_1_Query1 Execute(M_1000_PROCESSA_DB_SELECT_1_Query1 m_1000_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_1000_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SQL_SUREG = result[i++].Value?.ToString();
            dta.SQL_UNIDADE = result[i++].Value?.ToString();
            dta.SQL_DV = result[i++].Value?.ToString();
            dta.SQLCEF_NOME_UNID = result[i++].Value?.ToString();
            dta.SQL_NOME_FUNC = result[i++].Value?.ToString();
            dta.SQL_TIPO_VINC = result[i++].Value?.ToString();
            dta.SQL_DATA_NASC = result[i++].Value?.ToString();
            dta.SQL_CPF = result[i++].Value?.ToString();
            dta.SQL_ENDERECO = result[i++].Value?.ToString();
            dta.SQL_CIDADE = result[i++].Value?.ToString();
            dta.SQL_UF = result[i++].Value?.ToString();
            dta.SQL_CEP = result[i++].Value?.ToString();
            dta.SQL_AGENCIA = result[i++].Value?.ToString();
            dta.SQL_OPERACAO = result[i++].Value?.ToString();
            dta.SQL_CONTA = result[i++].Value?.ToString();
            dta.SQL_DV_CONTA = result[i++].Value?.ToString();
            dta.SQL_ANGARIADOR = result[i++].Value?.ToString();
            dta.SQL_IND_ANGAR = string.IsNullOrWhiteSpace(dta.SQL_ANGARIADOR) ? "-1" : "0";
            return dta;
        }

    }
}