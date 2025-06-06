using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1 : QueryBasis<R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NOME_RAZAO ,
            ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            DDD ,
            TELEFONE ,
            DATA_NASCIMENTO
            INTO
            :GECLIMOV-NOME-RAZAO :VIND-NOME-RAZAO,
            :GECLIMOV-ENDERECO :VIND-ENDERECO ,
            :GECLIMOV-BAIRRO :VIND-BAIRRO ,
            :GECLIMOV-CIDADE :VIND-CIDADE ,
            :GECLIMOV-SIGLA-UF :VIND-SIGLA-UF ,
            :GECLIMOV-CEP :VIND-CEP ,
            :GECLIMOV-DDD :VIND-DDD ,
            :GECLIMOV-TELEFONE :VIND-TELEFONE ,
            :GECLIMOV-DATA-NASCIMENTO :VIND-DATA-NASC
            FROM SEGUROS.GE_CLIENTES_MOVTO
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            AND OCORR_HIST = :MOVIMVGA-OCORR-ENDERECO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME_RAZAO 
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
							,
											DDD 
							,
											TELEFONE 
							,
											DATA_NASCIMENTO
											FROM SEGUROS.GE_CLIENTES_MOVTO
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											AND OCORR_HIST = '{this.MOVIMVGA_OCORR_ENDERECO}'";

            return query;
        }
        public string GECLIMOV_NOME_RAZAO { get; set; }
        public string VIND_NOME_RAZAO { get; set; }
        public string GECLIMOV_ENDERECO { get; set; }
        public string VIND_ENDERECO { get; set; }
        public string GECLIMOV_BAIRRO { get; set; }
        public string VIND_BAIRRO { get; set; }
        public string GECLIMOV_CIDADE { get; set; }
        public string VIND_CIDADE { get; set; }
        public string GECLIMOV_SIGLA_UF { get; set; }
        public string VIND_SIGLA_UF { get; set; }
        public string GECLIMOV_CEP { get; set; }
        public string VIND_CEP { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_DDD { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_TELEFONE { get; set; }
        public string GECLIMOV_DATA_NASCIMENTO { get; set; }
        public string VIND_DATA_NASC { get; set; }
        public string MOVIMVGA_OCORR_ENDERECO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1 Execute(R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1 r1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1)
        {
            var ths = r1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECLIMOV_NOME_RAZAO = result[i++].Value?.ToString();
            dta.VIND_NOME_RAZAO = string.IsNullOrWhiteSpace(dta.GECLIMOV_NOME_RAZAO) ? "-1" : "0";
            dta.GECLIMOV_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_ENDERECO = string.IsNullOrWhiteSpace(dta.GECLIMOV_ENDERECO) ? "-1" : "0";
            dta.GECLIMOV_BAIRRO = result[i++].Value?.ToString();
            dta.VIND_BAIRRO = string.IsNullOrWhiteSpace(dta.GECLIMOV_BAIRRO) ? "-1" : "0";
            dta.GECLIMOV_CIDADE = result[i++].Value?.ToString();
            dta.VIND_CIDADE = string.IsNullOrWhiteSpace(dta.GECLIMOV_CIDADE) ? "-1" : "0";
            dta.GECLIMOV_SIGLA_UF = result[i++].Value?.ToString();
            dta.VIND_SIGLA_UF = string.IsNullOrWhiteSpace(dta.GECLIMOV_SIGLA_UF) ? "-1" : "0";
            dta.GECLIMOV_CEP = result[i++].Value?.ToString();
            dta.VIND_CEP = string.IsNullOrWhiteSpace(dta.GECLIMOV_CEP) ? "-1" : "0";
            dta.GECLIMOV_DDD = result[i++].Value?.ToString();
            dta.VIND_DDD = string.IsNullOrWhiteSpace(dta.GECLIMOV_DDD) ? "-1" : "0";
            dta.GECLIMOV_TELEFONE = result[i++].Value?.ToString();
            dta.VIND_TELEFONE = string.IsNullOrWhiteSpace(dta.GECLIMOV_TELEFONE) ? "-1" : "0";
            dta.GECLIMOV_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DATA_NASC = string.IsNullOrWhiteSpace(dta.GECLIMOV_DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}