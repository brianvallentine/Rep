using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 : QueryBasis<R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA,
            CPF,
            DATA_NASCIMENTO,
            SEXO,
            TIPO_IDENT_SIVPF,
            NUM_IDENTIDADE,
            ORGAO_EXPEDIDOR,
            UF_EXPEDIDORA,
            DATA_EXPEDICAO,
            COD_CBO,
            COD_USUARIO,
            ESTADO_CIVIL,
            TIMESTAMP
            INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA,
            :DCLPESSOA-FISICA.CPF:VIND-CPF,
            :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI,
            :DCLPESSOA-FISICA.SEXO:VIND-SEXO,
            :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT,
            :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT,
            :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP,
            :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP,
            :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI,
            :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO,
            :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP
            FROM SEGUROS.PESSOA_FISICA
            WHERE CPF = :DCLPESSOA-FISICA.CPF
            AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO
            AND SEXO = :DCLPESSOA-FISICA.SEXO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
							,
											CPF
							,
											DATA_NASCIMENTO
							,
											SEXO
							,
											TIPO_IDENT_SIVPF
							,
											NUM_IDENTIDADE
							,
											ORGAO_EXPEDIDOR
							,
											UF_EXPEDIDORA
							,
											DATA_EXPEDICAO
							,
											COD_CBO
							,
											COD_USUARIO
							,
											ESTADO_CIVIL
							,
											TIMESTAMP
											FROM SEGUROS.PESSOA_FISICA
											WHERE CPF = '{this.CPF}'
											AND DATA_NASCIMENTO = '{this.DATA_NASCIMENTO}'
											AND SEXO = '{this.SEXO}'
											WITH UR";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string VIND_COD_PESSOA { get; set; }
        public string CPF { get; set; }
        public string VIND_CPF { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASCI { get; set; }
        public string SEXO { get; set; }
        public string VIND_SEXO { get; set; }
        public string TIPO_IDENT_SIVPF { get; set; }
        public string VIND_TP_IDENT { get; set; }
        public string NUM_IDENTIDADE { get; set; }
        public string VIND_NUM_IDENT { get; set; }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string VIND_ORGAO_EXP { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string VIND_UF_EXP { get; set; }
        public string DATA_EXPEDICAO { get; set; }
        public string VIND_DTEXPEDI { get; set; }
        public string COD_CBO { get; set; }
        public string VIND_COD_CBO { get; set; }
        public string COD_USUARIO { get; set; }
        public string VIND_COD_USUR { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string TIMESTAMP { get; set; }
        public string VIND_TIMESTAMP { get; set; }

        public static R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 Execute(R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1)
        {
            var ths = r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.VIND_COD_PESSOA = string.IsNullOrWhiteSpace(dta.COD_PESSOA) ? "-1" : "0";
            dta.CPF = result[i++].Value?.ToString();
            dta.VIND_CPF = string.IsNullOrWhiteSpace(dta.CPF) ? "-1" : "0";
            dta.DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASCI = string.IsNullOrWhiteSpace(dta.DATA_NASCIMENTO) ? "-1" : "0";
            dta.SEXO = result[i++].Value?.ToString();
            dta.VIND_SEXO = string.IsNullOrWhiteSpace(dta.SEXO) ? "-1" : "0";
            dta.TIPO_IDENT_SIVPF = result[i++].Value?.ToString();
            dta.VIND_TP_IDENT = string.IsNullOrWhiteSpace(dta.TIPO_IDENT_SIVPF) ? "-1" : "0";
            dta.NUM_IDENTIDADE = result[i++].Value?.ToString();
            dta.VIND_NUM_IDENT = string.IsNullOrWhiteSpace(dta.NUM_IDENTIDADE) ? "-1" : "0";
            dta.ORGAO_EXPEDIDOR = result[i++].Value?.ToString();
            dta.VIND_ORGAO_EXP = string.IsNullOrWhiteSpace(dta.ORGAO_EXPEDIDOR) ? "-1" : "0";
            dta.UF_EXPEDIDORA = result[i++].Value?.ToString();
            dta.VIND_UF_EXP = string.IsNullOrWhiteSpace(dta.UF_EXPEDIDORA) ? "-1" : "0";
            dta.DATA_EXPEDICAO = result[i++].Value?.ToString();
            dta.VIND_DTEXPEDI = string.IsNullOrWhiteSpace(dta.DATA_EXPEDICAO) ? "-1" : "0";
            dta.COD_CBO = result[i++].Value?.ToString();
            dta.VIND_COD_CBO = string.IsNullOrWhiteSpace(dta.COD_CBO) ? "-1" : "0";
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.VIND_COD_USUR = string.IsNullOrWhiteSpace(dta.COD_USUARIO) ? "-1" : "0";
            dta.ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.TIMESTAMP = result[i++].Value?.ToString();
            dta.VIND_TIMESTAMP = string.IsNullOrWhiteSpace(dta.TIMESTAMP) ? "-1" : "0";
            return dta;
        }

    }
}