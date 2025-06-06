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
    public class R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 : QueryBasis<R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_AGENCIA ,
            A.NOME_AGENCIA ,
            A.COD_SUREG ,
            B.ENDERECO ,
            B.BAIRRO ,
            B.CIDADE ,
            B.UF
            INTO :AGENCCEF-COD-AGENCIA ,
            :AGENCCEF-NOME-AGENCIA ,
            :AGENCCEF-COD-SUREG ,
            :UNIDACEF-ENDERECO:VIND-NULL01 ,
            :UNIDACEF-BAIRRO:VIND-NULL02 ,
            :UNIDACEF-CIDADE:VIND-NULL03 ,
            :UNIDACEF-UF:VIND-NULL04
            FROM SEGUROS.AGENCIAS_CEF A,
            SEGUROS.UNIDADE_CEF B
            WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            AND A.COD_AGENCIA = B.COD_UNIDADE
            AND A.COD_SUREG = B.COD_SUREG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_AGENCIA 
							,
											A.NOME_AGENCIA 
							,
											A.COD_SUREG 
							,
											B.ENDERECO 
							,
											B.BAIRRO 
							,
											B.CIDADE 
							,
											B.UF
											FROM SEGUROS.AGENCIAS_CEF A
							,
											SEGUROS.UNIDADE_CEF B
											WHERE A.COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											AND A.COD_AGENCIA = B.COD_UNIDADE
											AND A.COD_SUREG = B.COD_SUREG
											WITH UR";

            return query;
        }
        public string AGENCCEF_COD_AGENCIA { get; set; }
        public string AGENCCEF_NOME_AGENCIA { get; set; }
        public string AGENCCEF_COD_SUREG { get; set; }
        public string UNIDACEF_ENDERECO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string UNIDACEF_BAIRRO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string UNIDACEF_CIDADE { get; set; }
        public string VIND_NULL03 { get; set; }
        public string UNIDACEF_UF { get; set; }
        public string VIND_NULL04 { get; set; }

        public static R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 Execute(R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 r0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_COD_SUREG = result[i++].Value?.ToString();
            dta.UNIDACEF_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.UNIDACEF_ENDERECO) ? "-1" : "0";
            dta.UNIDACEF_BAIRRO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.UNIDACEF_BAIRRO) ? "-1" : "0";
            dta.UNIDACEF_CIDADE = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.UNIDACEF_CIDADE) ? "-1" : "0";
            dta.UNIDACEF_UF = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.UNIDACEF_UF) ? "-1" : "0";
            return dta;
        }

    }
}