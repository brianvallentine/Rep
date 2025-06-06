using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_CLIENTE ,
            A.COD_ENDERECO ,
            A.ENDERECO ,
            A.BAIRRO ,
            A.CIDADE ,
            A.SIGLA_UF ,
            A.CEP ,
            A.DDD ,
            A.TELEFONE ,
            A.DES_COMPLEMENTO
            INTO :ENDERECO-COD-CLIENTE ,
            :ENDERECO-COD-ENDERECO ,
            :ENDERECO-ENDERECO ,
            :ENDERECO-BAIRRO ,
            :ENDERECO-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :ENDERECO-CEP ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            :ENDERECO-DES-COMPLEMENTO:VIND-NULL01
            FROM SEGUROS.ENDERECOS A
            WHERE A.COD_CLIENTE = :ENDERECO-COD-CLIENTE
            AND A.OCORR_ENDERECO =
            ( SELECT MAX(B.OCORR_ENDERECO)
            FROM SEGUROS.ENDERECOS B
            WHERE A.COD_CLIENTE = B.COD_CLIENTE )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_CLIENTE 
							,
											A.COD_ENDERECO 
							,
											A.ENDERECO 
							,
											A.BAIRRO 
							,
											A.CIDADE 
							,
											A.SIGLA_UF 
							,
											A.CEP 
							,
											A.DDD 
							,
											A.TELEFONE 
							,
											A.DES_COMPLEMENTO
											FROM SEGUROS.ENDERECOS A
											WHERE A.COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'
											AND A.OCORR_ENDERECO =
											( SELECT MAX(B.OCORR_ENDERECO)
											FROM SEGUROS.ENDERECOS B
											WHERE A.COD_CLIENTE = B.COD_CLIENTE )
											WITH UR";

            return query;
        }
        public string ENDERECO_COD_CLIENTE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_DES_COMPLEMENTO { get; set; }
        public string VIND_NULL01 { get; set; }

        public static R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1 Execute(R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1 r0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.ENDERECO_DES_COMPLEMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.ENDERECO_DES_COMPLEMENTO) ? "-1" : "0";
            return dta;
        }

    }
}