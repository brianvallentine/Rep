using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP01B
{
    public class R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1 : QueryBasis<R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CLI.NOME_RAZAO ,
            CLI.TIPO_PESSOA ,
            CASE CLI.TIPO_PESSOA
            WHEN 'F' THEN 'PESSOA FISICA  '
            WHEN 'J' THEN 'PESSOA JURIDICA'
            END AS 'TIPO DE PESSOA' ,
            CLI.CGCCPF AS 'CPF / CNPJ DO FAVORECIDO' ,
            LOT.ENDERECO ,
            LOT.BAIRRO ,
            LOT.CIDADE ,
            LOT.CEP ,
            LOT.SIGLA_UF
            INTO :FORNECED-NOME-FORNECEDOR,
            :FORNECED-TIPO-PESSOA,
            :W-NOME-TIPO-PESSOA,
            :FORNECED-CGCCPF,
            :FORNECED-ENDERECO,
            :FORNECED-BAIRRO,
            :FORNECED-CIDADE,
            :FORNECED-CEP,
            :FORNECED-SIGLA-UF
            FROM
            SEGUROS.SINI_LOTERICO01 X,
            SEGUROS.LOTERICO01 LOT,
            SEGUROS.CLIENTES CLI
            WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND LOT.COD_CLIENTE = X.COD_CLIENTE
            AND CLI.COD_CLIENTE = X.COD_CLIENTE
            AND LOT.TIMESTAMP =
            (SELECT MAX(ZZ.TIMESTAMP)
            FROM SEGUROS.SINI_LOTERICO01 XX,
            SEGUROS.LOTERICO01 ZZ
            WHERE XX.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND ZZ.COD_CLIENTE = XX.COD_CLIENTE
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CLI.NOME_RAZAO 
							,
											CLI.TIPO_PESSOA 
							,
											CASE CLI.TIPO_PESSOA
											WHEN 'F' THEN 'PESSOA FISICA  '
											WHEN 'J' THEN 'PESSOA JURIDICA'
											END AS TIPODEPESSOA 
							,
											CLI.CGCCPF AS CPFCNPJDOFAVORECIDO 
							,
											LOT.ENDERECO 
							,
											LOT.BAIRRO 
							,
											LOT.CIDADE 
							,
											LOT.CEP 
							,
											LOT.SIGLA_UF
											FROM
											SEGUROS.SINI_LOTERICO01 X
							,
											SEGUROS.LOTERICO01 LOT
							,
											SEGUROS.CLIENTES CLI
											WHERE X.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND LOT.COD_CLIENTE = X.COD_CLIENTE
											AND CLI.COD_CLIENTE = X.COD_CLIENTE
											AND LOT.TIMESTAMP =
											(SELECT MAX(ZZ.TIMESTAMP)
											FROM SEGUROS.SINI_LOTERICO01 XX
							,
											SEGUROS.LOTERICO01 ZZ
											WHERE XX.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND ZZ.COD_CLIENTE = XX.COD_CLIENTE
											)";

            return query;
        }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string FORNECED_TIPO_PESSOA { get; set; }
        public string W_NOME_TIPO_PESSOA { get; set; }
        public string FORNECED_CGCCPF { get; set; }
        public string FORNECED_ENDERECO { get; set; }
        public string FORNECED_BAIRRO { get; set; }
        public string FORNECED_CIDADE { get; set; }
        public string FORNECED_CEP { get; set; }
        public string FORNECED_SIGLA_UF { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1 Execute(R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1 r2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1)
        {
            var ths = r2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1();
            var i = 0;
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.W_NOME_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            dta.FORNECED_ENDERECO = result[i++].Value?.ToString();
            dta.FORNECED_BAIRRO = result[i++].Value?.ToString();
            dta.FORNECED_CIDADE = result[i++].Value?.ToString();
            dta.FORNECED_CEP = result[i++].Value?.ToString();
            dta.FORNECED_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}