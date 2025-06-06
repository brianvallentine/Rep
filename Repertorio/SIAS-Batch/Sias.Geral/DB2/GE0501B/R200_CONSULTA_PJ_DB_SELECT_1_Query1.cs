using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0501B
{
    public class R200_CONSULTA_PJ_DB_SELECT_1_Query1 : QueryBasis<R200_CONSULTA_PJ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PESSOA ,
            A.DTH_CADASTRAMENTO ,
            A.NUM_DV_PESSOA ,
            A.IND_PESSOA ,
            A.STA_INF_INTEGRA ,
            B.NUM_PESSOA ,
            B.NUM_CNPJ ,
            B.NUM_FILIAL ,
            B.NUM_DV_CNPJ ,
            B.NOM_RAZAO_SOCIAL ,
            B.STA_PESSOA ,
            B.NUM_RAMO_ATIVIDADE,
            B.DTH_FUNDACAO ,
            B.NOM_FANTASIA ,
            B.NOM_SIGLA_PESSOA ,
            B.NUM_INSC_ESTADUAL ,
            B.NUM_INSC_MUNICIPAL,
            B.COD_UF ,
            B.NUM_MUNICIPIO ,
            B.COD_CNAE ,
            B.NUM_SOCIOS ,
            B.STA_FRANQUIA ,
            B.IND_FINALIDADE
            INTO :OD001-NUM-PESSOA ,
            :OD001-DTH-CADASTRAMENTO ,
            :OD001-NUM-DV-PESSOA ,
            :OD001-IND-PESSOA ,
            :OD001-STA-INF-INTEGRA ,
            :OD003-NUM-PESSOA ,
            :OD003-NUM-CNPJ ,
            :OD003-NUM-FILIAL ,
            :OD003-NUM-DV-CNPJ ,
            :OD003-NOM-RAZAO-SOCIAL,
            :OD003-STA-PESSOA ,
            :OD003-NUM-RAMO-ATIVIDADE:IND-NULL-01,
            :OD003-DTH-FUNDACAO:IND-NULL-02,
            :OD003-NOM-FANTASIA:IND-NULL-03,
            :OD003-NOM-SIGLA-PESSOA:IND-NULL-04,
            :OD003-NUM-INSC-ESTADUAL:IND-NULL-05,
            :OD003-NUM-INSC-MUNICIPAL:IND-NULL-06,
            :OD003-COD-UF:IND-NULL-07,
            :OD003-NUM-MUNICIPIO:IND-NULL-08,
            :OD003-COD-CNAE:IND-NULL-09,
            :OD003-NUM-SOCIOS:IND-NULL-10,
            :OD003-STA-FRANQUIA:IND-NULL-11,
            :OD003-IND-FINALIDADE:IND-NULL-12
            FROM ODS.OD_PESSOA A,
            ODS.OD_PESSOA_JURIDICA B
            WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA
            AND B.NUM_PESSOA = A.NUM_PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PESSOA 
							,
											A.DTH_CADASTRAMENTO 
							,
											A.NUM_DV_PESSOA 
							,
											A.IND_PESSOA 
							,
											A.STA_INF_INTEGRA 
							,
											B.NUM_PESSOA 
							,
											B.NUM_CNPJ 
							,
											B.NUM_FILIAL 
							,
											B.NUM_DV_CNPJ 
							,
											B.NOM_RAZAO_SOCIAL 
							,
											B.STA_PESSOA 
							,
											B.NUM_RAMO_ATIVIDADE
							,
											B.DTH_FUNDACAO 
							,
											B.NOM_FANTASIA 
							,
											B.NOM_SIGLA_PESSOA 
							,
											B.NUM_INSC_ESTADUAL 
							,
											B.NUM_INSC_MUNICIPAL
							,
											B.COD_UF 
							,
											B.NUM_MUNICIPIO 
							,
											B.COD_CNAE 
							,
											B.NUM_SOCIOS 
							,
											B.STA_FRANQUIA 
							,
											B.IND_FINALIDADE
											FROM ODS.OD_PESSOA A
							,
											ODS.OD_PESSOA_JURIDICA B
											WHERE A.NUM_PESSOA = '{this.OD001_NUM_PESSOA}'
											AND B.NUM_PESSOA = A.NUM_PESSOA
											WITH UR";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD003_NUM_PESSOA { get; set; }
        public string OD003_NUM_CNPJ { get; set; }
        public string OD003_NUM_FILIAL { get; set; }
        public string OD003_NUM_DV_CNPJ { get; set; }
        public string OD003_NOM_RAZAO_SOCIAL { get; set; }
        public string OD003_STA_PESSOA { get; set; }
        public string OD003_NUM_RAMO_ATIVIDADE { get; set; }
        public string IND_NULL_01 { get; set; }
        public string OD003_DTH_FUNDACAO { get; set; }
        public string IND_NULL_02 { get; set; }
        public string OD003_NOM_FANTASIA { get; set; }
        public string IND_NULL_03 { get; set; }
        public string OD003_NOM_SIGLA_PESSOA { get; set; }
        public string IND_NULL_04 { get; set; }
        public string OD003_NUM_INSC_ESTADUAL { get; set; }
        public string IND_NULL_05 { get; set; }
        public string OD003_NUM_INSC_MUNICIPAL { get; set; }
        public string IND_NULL_06 { get; set; }
        public string OD003_COD_UF { get; set; }
        public string IND_NULL_07 { get; set; }
        public string OD003_NUM_MUNICIPIO { get; set; }
        public string IND_NULL_08 { get; set; }
        public string OD003_COD_CNAE { get; set; }
        public string IND_NULL_09 { get; set; }
        public string OD003_NUM_SOCIOS { get; set; }
        public string IND_NULL_10 { get; set; }
        public string OD003_STA_FRANQUIA { get; set; }
        public string IND_NULL_11 { get; set; }
        public string OD003_IND_FINALIDADE { get; set; }
        public string IND_NULL_12 { get; set; }

        public static R200_CONSULTA_PJ_DB_SELECT_1_Query1 Execute(R200_CONSULTA_PJ_DB_SELECT_1_Query1 r200_CONSULTA_PJ_DB_SELECT_1_Query1)
        {
            var ths = r200_CONSULTA_PJ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_CONSULTA_PJ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_CONSULTA_PJ_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD003_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD003_NUM_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NUM_FILIAL = result[i++].Value?.ToString();
            dta.OD003_NUM_DV_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NOM_RAZAO_SOCIAL = result[i++].Value?.ToString();
            dta.OD003_STA_PESSOA = result[i++].Value?.ToString();
            dta.OD003_NUM_RAMO_ATIVIDADE = result[i++].Value?.ToString();
            dta.IND_NULL_01 = string.IsNullOrWhiteSpace(dta.OD003_NUM_RAMO_ATIVIDADE) ? "-1" : "0";
            dta.OD003_DTH_FUNDACAO = result[i++].Value?.ToString();
            dta.IND_NULL_02 = string.IsNullOrWhiteSpace(dta.OD003_DTH_FUNDACAO) ? "-1" : "0";
            dta.OD003_NOM_FANTASIA = result[i++].Value?.ToString();
            dta.IND_NULL_03 = string.IsNullOrWhiteSpace(dta.OD003_NOM_FANTASIA) ? "-1" : "0";
            dta.OD003_NOM_SIGLA_PESSOA = result[i++].Value?.ToString();
            dta.IND_NULL_04 = string.IsNullOrWhiteSpace(dta.OD003_NOM_SIGLA_PESSOA) ? "-1" : "0";
            dta.OD003_NUM_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.IND_NULL_05 = string.IsNullOrWhiteSpace(dta.OD003_NUM_INSC_ESTADUAL) ? "-1" : "0";
            dta.OD003_NUM_INSC_MUNICIPAL = result[i++].Value?.ToString();
            dta.IND_NULL_06 = string.IsNullOrWhiteSpace(dta.OD003_NUM_INSC_MUNICIPAL) ? "-1" : "0";
            dta.OD003_COD_UF = result[i++].Value?.ToString();
            dta.IND_NULL_07 = string.IsNullOrWhiteSpace(dta.OD003_COD_UF) ? "-1" : "0";
            dta.OD003_NUM_MUNICIPIO = result[i++].Value?.ToString();
            dta.IND_NULL_08 = string.IsNullOrWhiteSpace(dta.OD003_NUM_MUNICIPIO) ? "-1" : "0";
            dta.OD003_COD_CNAE = result[i++].Value?.ToString();
            dta.IND_NULL_09 = string.IsNullOrWhiteSpace(dta.OD003_COD_CNAE) ? "-1" : "0";
            dta.OD003_NUM_SOCIOS = result[i++].Value?.ToString();
            dta.IND_NULL_10 = string.IsNullOrWhiteSpace(dta.OD003_NUM_SOCIOS) ? "-1" : "0";
            dta.OD003_STA_FRANQUIA = result[i++].Value?.ToString();
            dta.IND_NULL_11 = string.IsNullOrWhiteSpace(dta.OD003_STA_FRANQUIA) ? "-1" : "0";
            dta.OD003_IND_FINALIDADE = result[i++].Value?.ToString();
            dta.IND_NULL_12 = string.IsNullOrWhiteSpace(dta.OD003_IND_FINALIDADE) ? "-1" : "0";
            return dta;
        }

    }
}