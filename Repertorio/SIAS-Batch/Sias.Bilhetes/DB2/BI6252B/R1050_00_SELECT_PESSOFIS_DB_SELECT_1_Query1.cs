using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PESSOA ,
            A.CPF ,
            A.DATA_NASCIMENTO ,
            A.SEXO ,
            A.COD_USUARIO ,
            A.ESTADO_CIVIL ,
            A.NUM_IDENTIDADE ,
            A.ORGAO_EXPEDIDOR ,
            A.UF_EXPEDIDORA ,
            A.DATA_EXPEDICAO ,
            A.COD_CBO ,
            A.TIPO_IDENT_SIVPF ,
            B.NOME_PESSOA
            INTO :PESSOFIS-COD-PESSOA ,
            :PESSOFIS-CPF ,
            :PESSOFIS-DATA-NASCIMENTO ,
            :PESSOFIS-SEXO ,
            :PESSOFIS-COD-USUARIO ,
            :PESSOFIS-ESTADO-CIVIL ,
            :PESSOFIS-NUM-IDENTIDADE:VIND-NUM-IDENT ,
            :PESSOFIS-ORGAO-EXPEDIDOR:VIND-ORGAO-EXP ,
            :PESSOFIS-UF-EXPEDIDORA:VIND-UF-EXP ,
            :PESSOFIS-DATA-EXPEDICAO:VIND-DTEXPEDI ,
            :PESSOFIS-COD-CBO:VIND-COD-CBO ,
            :PESSOFIS-TIPO-IDENT-SIVPF:VIND-TP-IDENT ,
            :PESSOA-NOME-PESSOA
            FROM SEGUROS.PESSOA_FISICA A,
            SEGUROS.PESSOA B
            WHERE A.CPF = :CLIENTES-CGCCPF
            AND A.DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO
            AND A.COD_PESSOA = B.COD_PESSOA
            ORDER BY A.COD_PESSOA DESC
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_PESSOA 
							,
											A.CPF 
							,
											A.DATA_NASCIMENTO 
							,
											A.SEXO 
							,
											A.COD_USUARIO 
							,
											A.ESTADO_CIVIL 
							,
											A.NUM_IDENTIDADE 
							,
											A.ORGAO_EXPEDIDOR 
							,
											A.UF_EXPEDIDORA 
							,
											A.DATA_EXPEDICAO 
							,
											A.COD_CBO 
							,
											A.TIPO_IDENT_SIVPF 
							,
											B.NOME_PESSOA
											FROM SEGUROS.PESSOA_FISICA A
							,
											SEGUROS.PESSOA B
											WHERE A.CPF = '{this.CLIENTES_CGCCPF}'
											AND A.DATA_NASCIMENTO = '{this.CLIENTES_DATA_NASCIMENTO}'
											AND A.COD_PESSOA = B.COD_PESSOA
											ORDER BY A.COD_PESSOA DESC
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string PESSOFIS_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }
        public string PESSOFIS_DATA_NASCIMENTO { get; set; }
        public string PESSOFIS_SEXO { get; set; }
        public string PESSOFIS_COD_USUARIO { get; set; }
        public string PESSOFIS_ESTADO_CIVIL { get; set; }
        public string PESSOFIS_NUM_IDENTIDADE { get; set; }
        public string VIND_NUM_IDENT { get; set; }
        public string PESSOFIS_ORGAO_EXPEDIDOR { get; set; }
        public string VIND_ORGAO_EXP { get; set; }
        public string PESSOFIS_UF_EXPEDIDORA { get; set; }
        public string VIND_UF_EXP { get; set; }
        public string PESSOFIS_DATA_EXPEDICAO { get; set; }
        public string VIND_DTEXPEDI { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }
        public string VIND_COD_CBO { get; set; }
        public string PESSOFIS_TIPO_IDENT_SIVPF { get; set; }
        public string VIND_TP_IDENT { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 r1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOFIS_COD_PESSOA = result[i++].Value?.ToString();
            dta.PESSOFIS_CPF = result[i++].Value?.ToString();
            dta.PESSOFIS_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.PESSOFIS_SEXO = result[i++].Value?.ToString();
            dta.PESSOFIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.PESSOFIS_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.PESSOFIS_NUM_IDENTIDADE = result[i++].Value?.ToString();
            dta.VIND_NUM_IDENT = string.IsNullOrWhiteSpace(dta.PESSOFIS_NUM_IDENTIDADE) ? "-1" : "0";
            dta.PESSOFIS_ORGAO_EXPEDIDOR = result[i++].Value?.ToString();
            dta.VIND_ORGAO_EXP = string.IsNullOrWhiteSpace(dta.PESSOFIS_ORGAO_EXPEDIDOR) ? "-1" : "0";
            dta.PESSOFIS_UF_EXPEDIDORA = result[i++].Value?.ToString();
            dta.VIND_UF_EXP = string.IsNullOrWhiteSpace(dta.PESSOFIS_UF_EXPEDIDORA) ? "-1" : "0";
            dta.PESSOFIS_DATA_EXPEDICAO = result[i++].Value?.ToString();
            dta.VIND_DTEXPEDI = string.IsNullOrWhiteSpace(dta.PESSOFIS_DATA_EXPEDICAO) ? "-1" : "0";
            dta.PESSOFIS_COD_CBO = result[i++].Value?.ToString();
            dta.VIND_COD_CBO = string.IsNullOrWhiteSpace(dta.PESSOFIS_COD_CBO) ? "-1" : "0";
            dta.PESSOFIS_TIPO_IDENT_SIVPF = result[i++].Value?.ToString();
            dta.VIND_TP_IDENT = string.IsNullOrWhiteSpace(dta.PESSOFIS_TIPO_IDENT_SIVPF) ? "-1" : "0";
            dta.PESSOA_NOME_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}