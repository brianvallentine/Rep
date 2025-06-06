using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0502B
{
    public class R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1>
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
            B.SEQ_ENDERECO ,
            B.DTH_CADASTRAMENTO ,
            B.IND_ENDERECO ,
            B.STA_ENDERECO ,
            B.NOM_LOGRADOURO ,
            B.DES_NUM_IMOVEL ,
            B.DES_COMPL_ENDERECO ,
            B.NOM_BAIRRO ,
            B.NOM_CIDADE ,
            B.COD_CEP ,
            B.COD_UF ,
            B.STA_CORRESPONDER ,
            B.STA_PROPAGANDA
            INTO :OD001-NUM-PESSOA ,
            :OD001-DTH-CADASTRAMENTO ,
            :OD001-NUM-DV-PESSOA ,
            :OD001-IND-PESSOA ,
            :OD001-STA-INF-INTEGRA ,
            :OD007-SEQ-ENDERECO ,
            :OD007-DTH-CADASTRAMENTO ,
            :OD007-IND-ENDERECO ,
            :OD007-STA-ENDERECO ,
            :OD007-NOM-LOGRADOURO:VIND-NULL01 ,
            :OD007-DES-NUM-IMOVEL:VIND-NULL02 ,
            :OD007-DES-COMPL-ENDERECO:VIND-NULL03 ,
            :OD007-NOM-BAIRRO:VIND-NULL04 ,
            :OD007-NOM-CIDADE:VIND-NULL05 ,
            :OD007-COD-CEP:VIND-NULL06 ,
            :OD007-COD-UF:VIND-NULL07 ,
            :OD007-STA-CORRESPONDER ,
            :OD007-STA-PROPAGANDA
            FROM ODS.OD_PESSOA A ,
            ODS.OD_PESSOA_ENDERECO B
            WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA
            AND B.NUM_PESSOA = A.NUM_PESSOA
            AND B.SEQ_ENDERECO = :OD007-SEQ-ENDERECO
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
											B.SEQ_ENDERECO 
							,
											B.DTH_CADASTRAMENTO 
							,
											B.IND_ENDERECO 
							,
											B.STA_ENDERECO 
							,
											B.NOM_LOGRADOURO 
							,
											B.DES_NUM_IMOVEL 
							,
											B.DES_COMPL_ENDERECO 
							,
											B.NOM_BAIRRO 
							,
											B.NOM_CIDADE 
							,
											B.COD_CEP 
							,
											B.COD_UF 
							,
											B.STA_CORRESPONDER 
							,
											B.STA_PROPAGANDA
											FROM ODS.OD_PESSOA A 
							,
											ODS.OD_PESSOA_ENDERECO B
											WHERE A.NUM_PESSOA = '{this.OD001_NUM_PESSOA}'
											AND B.NUM_PESSOA = A.NUM_PESSOA
											AND B.SEQ_ENDERECO = '{this.OD007_SEQ_ENDERECO}'
											WITH UR";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_DTH_CADASTRAMENTO { get; set; }
        public string OD007_IND_ENDERECO { get; set; }
        public string OD007_STA_ENDERECO { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD007_COD_UF { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD007_STA_CORRESPONDER { get; set; }
        public string OD007_STA_PROPAGANDA { get; set; }

        public static R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1 Execute(R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1 r200_CONSULTA_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r200_CONSULTA_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD007_SEQ_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD007_IND_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_STA_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD007_NOM_LOGRADOURO) ? "-1" : "0";
            dta.OD007_DES_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD007_DES_NUM_IMOVEL) ? "-1" : "0";
            dta.OD007_DES_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.OD007_DES_COMPL_ENDERECO) ? "-1" : "0";
            dta.OD007_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.OD007_NOM_BAIRRO) ? "-1" : "0";
            dta.OD007_NOM_CIDADE = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.OD007_NOM_CIDADE) ? "-1" : "0";
            dta.OD007_COD_CEP = result[i++].Value?.ToString();
            dta.VIND_NULL06 = string.IsNullOrWhiteSpace(dta.OD007_COD_CEP) ? "-1" : "0";
            dta.OD007_COD_UF = result[i++].Value?.ToString();
            dta.VIND_NULL07 = string.IsNullOrWhiteSpace(dta.OD007_COD_UF) ? "-1" : "0";
            dta.OD007_STA_CORRESPONDER = result[i++].Value?.ToString();
            dta.OD007_STA_PROPAGANDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}