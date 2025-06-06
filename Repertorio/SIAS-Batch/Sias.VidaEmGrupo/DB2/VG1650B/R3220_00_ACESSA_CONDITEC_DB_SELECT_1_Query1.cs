using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1 : QueryBasis<R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            TAXA_AP,
            LIM_CAP_MORNATU,
            LIM_CAP_MORACID,
            LIM_CAP_INVAPER,
            GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD,
            GARAN_ADIC_HD
            INTO :CONDITEC-QTD-SAL-MORNATU,
            :CONDITEC-QTD-SAL-MORACID,
            :CONDITEC-QTD-SAL-INVPERM,
            :CONDITEC-TAXA-AP-MORACID,
            :CONDITEC-TAXA-AP-INVPERM,
            :CONDITEC-TAXA-AP-AMDS,
            :CONDITEC-TAXA-AP-DH,
            :CONDITEC-TAXA-AP-DIT,
            :CONDITEC-TAXA-AP,
            :CONDITEC-LIM-CAP-MORNATU,
            :CONDITEC-LIM-CAP-MORACID,
            :CONDITEC-LIM-CAP-INVAPER,
            :CONDITEC-GARAN-ADIC-IEA,
            :CONDITEC-GARAN-ADIC-IPA,
            :CONDITEC-GARAN-ADIC-IPD,
            :CONDITEC-GARAN-ADIC-HD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTD_SAL_MORNATU
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
											LIM_CAP_MORNATU
							,
											LIM_CAP_MORACID
							,
											LIM_CAP_INVAPER
							,
											GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
							,
											GARAN_ADIC_HD
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'";

            return query;
        }
        public string CONDITEC_QTD_SAL_MORNATU { get; set; }
        public string CONDITEC_QTD_SAL_MORACID { get; set; }
        public string CONDITEC_QTD_SAL_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_MORACID { get; set; }
        public string CONDITEC_TAXA_AP_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_AMDS { get; set; }
        public string CONDITEC_TAXA_AP_DH { get; set; }
        public string CONDITEC_TAXA_AP_DIT { get; set; }
        public string CONDITEC_TAXA_AP { get; set; }
        public string CONDITEC_LIM_CAP_MORNATU { get; set; }
        public string CONDITEC_LIM_CAP_MORACID { get; set; }
        public string CONDITEC_LIM_CAP_INVAPER { get; set; }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string CONDITEC_GARAN_ADIC_HD { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1 Execute(R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1 r3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1)
        {
            var ths = r3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.CONDITEC_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.CONDITEC_TAXA_AP = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_MORNATU = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_MORACID = result[i++].Value?.ToString();
            dta.CONDITEC_LIM_CAP_INVAPER = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPD = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_HD = result[i++].Value?.ToString();
            return dta;
        }

    }
}