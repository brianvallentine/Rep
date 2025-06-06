using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0500B
{
    public class R200_CONSULTA_PF_DB_SELECT_1_Query1 : QueryBasis<R200_CONSULTA_PF_DB_SELECT_1_Query1>
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
            B.NUM_CPF ,
            B.NUM_DV_CPF ,
            B.NOM_PESSOA ,
            B.DTH_NASCIMENTO ,
            B.STA_SEXO ,
            B.IND_ESTADO_CIVIL ,
            B.STA_PESSOA ,
            B.NOM_TRATAMENTO ,
            B.COD_UF ,
            B.NUM_MUNICIPIO ,
            B.NUM_INSC_SOCIAL ,
            B.NUM_DV_INSC_SOCIAL ,
            B.NUM_GRAU_INSTRUCAO ,
            B.NOM_REDUZIDO ,
            B.COD_CBO ,
            B.NOM_PRIMEIRO ,
            B.NOM_ULTIMO
            INTO :OD001-NUM-PESSOA ,
            :OD001-DTH-CADASTRAMENTO ,
            :OD001-NUM-DV-PESSOA ,
            :OD001-IND-PESSOA ,
            :OD001-STA-INF-INTEGRA ,
            :OD002-NUM-PESSOA ,
            :OD002-NUM-CPF ,
            :OD002-NUM-DV-CPF ,
            :OD002-NOM-PESSOA ,
            :OD002-DTH-NASCIMENTO:VIND-NULL01 ,
            :OD002-STA-SEXO:VIND-NULL02 ,
            :OD002-IND-ESTADO-CIVIL:VIND-NULL03 ,
            :OD002-STA-PESSOA ,
            :OD002-NOM-TRATAMENTO:VIND-NULL04 ,
            :OD002-COD-UF:VIND-NULL05 ,
            :OD002-NUM-MUNICIPIO:VIND-NULL06 ,
            :OD002-NUM-INSC-SOCIAL:VIND-NULL07 ,
            :OD002-NUM-DV-INSC-SOCIAL:VIND-NULL08 ,
            :OD002-NUM-GRAU-INSTRUCAO:VIND-NULL09 ,
            :OD002-NOM-REDUZIDO:VIND-NULL10 ,
            :OD002-COD-CBO:VIND-NULL11 ,
            :OD002-NOM-PRIMEIRO:VIND-NULL12 ,
            :OD002-NOM-ULTIMO:VIND-NULL13
            FROM ODS.OD_PESSOA A,
            ODS.OD_PESSOA_FISICA B
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
											B.NUM_CPF 
							,
											B.NUM_DV_CPF 
							,
											B.NOM_PESSOA 
							,
											B.DTH_NASCIMENTO 
							,
											B.STA_SEXO 
							,
											B.IND_ESTADO_CIVIL 
							,
											B.STA_PESSOA 
							,
											B.NOM_TRATAMENTO 
							,
											B.COD_UF 
							,
											B.NUM_MUNICIPIO 
							,
											B.NUM_INSC_SOCIAL 
							,
											B.NUM_DV_INSC_SOCIAL 
							,
											B.NUM_GRAU_INSTRUCAO 
							,
											B.NOM_REDUZIDO 
							,
											B.COD_CBO 
							,
											B.NOM_PRIMEIRO 
							,
											B.NOM_ULTIMO
											FROM ODS.OD_PESSOA A
							,
											ODS.OD_PESSOA_FISICA B
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
        public string OD002_NUM_PESSOA { get; set; }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string OD002_DTH_NASCIMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD002_STA_SEXO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD002_IND_ESTADO_CIVIL { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD002_STA_PESSOA { get; set; }
        public string OD002_NOM_TRATAMENTO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD002_COD_UF { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD002_NUM_MUNICIPIO { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD002_NUM_INSC_SOCIAL { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD002_NUM_DV_INSC_SOCIAL { get; set; }
        public string VIND_NULL08 { get; set; }
        public string OD002_NUM_GRAU_INSTRUCAO { get; set; }
        public string VIND_NULL09 { get; set; }
        public string OD002_NOM_REDUZIDO { get; set; }
        public string VIND_NULL10 { get; set; }
        public string OD002_COD_CBO { get; set; }
        public string VIND_NULL11 { get; set; }
        public string OD002_NOM_PRIMEIRO { get; set; }
        public string VIND_NULL12 { get; set; }
        public string OD002_NOM_ULTIMO { get; set; }
        public string VIND_NULL13 { get; set; }

        public static R200_CONSULTA_PF_DB_SELECT_1_Query1 Execute(R200_CONSULTA_PF_DB_SELECT_1_Query1 r200_CONSULTA_PF_DB_SELECT_1_Query1)
        {
            var ths = r200_CONSULTA_PF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_CONSULTA_PF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_CONSULTA_PF_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD002_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NUM_CPF = result[i++].Value?.ToString();
            dta.OD002_NUM_DV_CPF = result[i++].Value?.ToString();
            dta.OD002_NOM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_DTH_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD002_DTH_NASCIMENTO) ? "-1" : "0";
            dta.OD002_STA_SEXO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD002_STA_SEXO) ? "-1" : "0";
            dta.OD002_IND_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.OD002_IND_ESTADO_CIVIL) ? "-1" : "0";
            dta.OD002_STA_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NOM_TRATAMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.OD002_NOM_TRATAMENTO) ? "-1" : "0";
            dta.OD002_COD_UF = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.OD002_COD_UF) ? "-1" : "0";
            dta.OD002_NUM_MUNICIPIO = result[i++].Value?.ToString();
            dta.VIND_NULL06 = string.IsNullOrWhiteSpace(dta.OD002_NUM_MUNICIPIO) ? "-1" : "0";
            dta.OD002_NUM_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.VIND_NULL07 = string.IsNullOrWhiteSpace(dta.OD002_NUM_INSC_SOCIAL) ? "-1" : "0";
            dta.OD002_NUM_DV_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.VIND_NULL08 = string.IsNullOrWhiteSpace(dta.OD002_NUM_DV_INSC_SOCIAL) ? "-1" : "0";
            dta.OD002_NUM_GRAU_INSTRUCAO = result[i++].Value?.ToString();
            dta.VIND_NULL09 = string.IsNullOrWhiteSpace(dta.OD002_NUM_GRAU_INSTRUCAO) ? "-1" : "0";
            dta.OD002_NOM_REDUZIDO = result[i++].Value?.ToString();
            dta.VIND_NULL10 = string.IsNullOrWhiteSpace(dta.OD002_NOM_REDUZIDO) ? "-1" : "0";
            dta.OD002_COD_CBO = result[i++].Value?.ToString();
            dta.VIND_NULL11 = string.IsNullOrWhiteSpace(dta.OD002_COD_CBO) ? "-1" : "0";
            dta.OD002_NOM_PRIMEIRO = result[i++].Value?.ToString();
            dta.VIND_NULL12 = string.IsNullOrWhiteSpace(dta.OD002_NOM_PRIMEIRO) ? "-1" : "0";
            dta.OD002_NOM_ULTIMO = result[i++].Value?.ToString();
            dta.VIND_NULL13 = string.IsNullOrWhiteSpace(dta.OD002_NOM_ULTIMO) ? "-1" : "0";
            return dta;
        }

    }
}