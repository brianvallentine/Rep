using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0200_VERIFICA_COBER_DB_SELECT_1_Query1 : QueryBasis<M_0200_VERIFICA_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT ,
            TAXA_AP ,
            CARREGA_PRINCIPAL,
            CARREGA_CONJUGE ,
            CARREGA_FILHOS ,
            GARAN_ADIC_IEA ,
            GARAN_ADIC_IPA ,
            GARAN_ADIC_IPD ,
            GARAN_ADIC_HD ,
            TAXA_DESPESA_ADM ,
            TAXA_IRB ,
            LIM_CAP_MORNATU ,
            LIM_CAP_MORACID ,
            LIM_CAP_INVAPER
            INTO
            :CONDITEC-NUM-APOLICE ,
            :CONDITEC-COD-SUBGRUPO ,
            :CONDITEC-QTD-SAL-MORNATU ,
            :CONDITEC-QTD-SAL-MORACID ,
            :CONDITEC-QTD-SAL-INVPERM ,
            :CONDITEC-TAXA-AP-MORACID ,
            :CONDITEC-TAXA-AP-INVPERM ,
            :CONDITEC-TAXA-AP-AMDS ,
            :CONDITEC-TAXA-AP-DH ,
            :CONDITEC-TAXA-AP-DIT ,
            :CONDITEC-TAXA-AP ,
            :CONDITEC-CARREGA-PRINCIPAL,
            :CONDITEC-CARREGA-CONJUGE ,
            :CONDITEC-CARREGA-FILHOS ,
            :CONDITEC-GARAN-ADIC-IEA ,
            :CONDITEC-GARAN-ADIC-IPA ,
            :CONDITEC-GARAN-ADIC-IPD ,
            :CONDITEC-GARAN-ADIC-HD ,
            :CONDITEC-TAXA-DESPESA-ADM ,
            :CONDITEC-TAXA-IRB ,
            :CONDITEC-LIM-CAP-MORNATU ,
            :CONDITEC-LIM-CAP-MORACID ,
            :CONDITEC-LIM-CAP-INVAPER
            FROM
            SEGUROS.CONDICOES_TECNICAS
            WHERE
            NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											QTD_SAL_MORNATU
							,
											QTD_SAL_MORACID
							,
											QTD_SAL_INVPERM
							,
											TAXA_AP_MORACID
							,
											TAXA_AP_INVPERM
							,
											TAXA_AP_AMDS 
							,
											TAXA_AP_DH 
							,
											TAXA_AP_DIT 
							,
											TAXA_AP 
							,
											CARREGA_PRINCIPAL
							,
											CARREGA_CONJUGE 
							,
											CARREGA_FILHOS 
							,
											GARAN_ADIC_IEA 
							,
											GARAN_ADIC_IPA 
							,
											GARAN_ADIC_IPD 
							,
											GARAN_ADIC_HD 
							,
											TAXA_DESPESA_ADM 
							,
											TAXA_IRB 
							,
											LIM_CAP_MORNATU 
							,
											LIM_CAP_MORACID 
							,
											LIM_CAP_INVAPER
											FROM
											SEGUROS.CONDICOES_TECNICAS
											WHERE
											NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'";

            return query;
        }
        public string CONDITEC_NUM_APOLICE { get; set; }
        public string CONDITEC_COD_SUBGRUPO { get; set; }
        public string CONDITEC_QTD_SAL_MORNATU { get; set; }
        public string CONDITEC_QTD_SAL_MORACID { get; set; }
        public string CONDITEC_QTD_SAL_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_MORACID { get; set; }
        public string CONDITEC_TAXA_AP_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_AMDS { get; set; }
        public string CONDITEC_TAXA_AP_DH { get; set; }
        public string CONDITEC_TAXA_AP_DIT { get; set; }
        public string CONDITEC_TAXA_AP { get; set; }
        public string CONDITEC_CARREGA_PRINCIPAL { get; set; }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string CONDITEC_CARREGA_FILHOS { get; set; }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string CONDITEC_GARAN_ADIC_HD { get; set; }
        public string CONDITEC_TAXA_DESPESA_ADM { get; set; }
        public string CONDITEC_TAXA_IRB { get; set; }
        public string CONDITEC_LIM_CAP_MORNATU { get; set; }
        public string CONDITEC_LIM_CAP_MORACID { get; set; }
        public string CONDITEC_LIM_CAP_INVAPER { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_0200_VERIFICA_COBER_DB_SELECT_1_Query1 Execute(M_0200_VERIFICA_COBER_DB_SELECT_1_Query1 m_0200_VERIFICA_COBER_DB_SELECT_1_Query1)
        {
            var ths = m_0200_VERIFICA_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0200_VERIFICA_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0200_VERIFICA_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CONDITEC_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.CONDITEC_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.CONDITEC_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP = result[i++].Value?.ToString();
            dta.CONDITEC_CARREGA_PRINCIPAL = result[i++].Value?.ToString();
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            dta.CONDITEC_CARREGA_FILHOS = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPD = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_HD = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_DESPESA_ADM = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_IRB = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_MORNATU = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_INVAPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}