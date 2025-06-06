using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0710S
{
    public class M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1 : QueryBasis<M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD,
            GARAN_ADIC_HD
            INTO :TAXA-AP-MORACID,
            :TAXA-AP-INVPERM,
            :TAXA-AP-AMDS,
            :TAXA-AP-DH,
            :TAXA-AP-DIT,
            :GARAN-ADIC-IEA,
            :GARAN-ADIC-IPA,
            :GARAN-ADIC-IPD,
            :GARAN-ADIC-HD
            FROM SEGUROS.V1CONDTEC
            WHERE NUM_APOLICE = :NUM-APOLICE
            AND COD_SUBGRUPO = :COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_AP_MORACID
							,
											TAXA_AP_INVPERM
							,
											TAXA_AP_AMDS
							,
											TAXA_AP_DH
							,
											TAXA_AP_DIT
							,
											GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
							,
											GARAN_ADIC_HD
											FROM SEGUROS.V1CONDTEC
											WHERE NUM_APOLICE = '{this.NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.COD_SUBGRUPO}'";

            return query;
        }
        public string TAXA_AP_MORACID { get; set; }
        public string TAXA_AP_INVPERM { get; set; }
        public string TAXA_AP_AMDS { get; set; }
        public string TAXA_AP_DH { get; set; }
        public string TAXA_AP_DIT { get; set; }
        public string GARAN_ADIC_IEA { get; set; }
        public string GARAN_ADIC_IPA { get; set; }
        public string GARAN_ADIC_IPD { get; set; }
        public string GARAN_ADIC_HD { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string NUM_APOLICE { get; set; }

        public static M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1 Execute(M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1 m_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1)
        {
            var ths = m_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.TAXA_AP_DH = result[i++].Value?.ToString();
            dta.TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.GARAN_ADIC_IPD = result[i++].Value?.ToString();
            dta.GARAN_ADIC_HD = result[i++].Value?.ToString();
            return dta;
        }

    }
}