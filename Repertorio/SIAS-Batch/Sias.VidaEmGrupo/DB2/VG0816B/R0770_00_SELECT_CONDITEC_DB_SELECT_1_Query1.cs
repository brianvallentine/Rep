using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1 : QueryBasis<R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXA_AP_MORACID
            ,TAXA_AP_INVPERM
            ,TAXA_AP_AMDS
            ,TAXA_AP_DH
            ,TAXA_AP_DIT
            ,TAXA_AP
            ,CARREGA_PRINCIPAL
            ,CARREGA_CONJUGE
            ,CARREGA_FILHOS
            ,GARAN_ADIC_IEA
            ,GARAN_ADIC_IPA
            ,GARAN_ADIC_IPD
            INTO :CONDITEC-TAXA-AP-MORACID
            ,:CONDITEC-TAXA-AP-INVPERM
            ,:CONDITEC-TAXA-AP-AMDS
            ,:CONDITEC-TAXA-AP-DH
            ,:CONDITEC-TAXA-AP-DIT
            ,:CONDITEC-TAXA-AP
            ,:CONDITEC-CARREGA-PRINCIPAL
            ,:CONDITEC-CARREGA-CONJUGE
            ,:CONDITEC-CARREGA-FILHOS
            ,:CONDITEC-GARAN-ADIC-IEA
            ,:CONDITEC-GARAN-ADIC-IPA
            ,:CONDITEC-GARAN-ADIC-IPD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :CONDITEC-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_AP_MORACID
											,TAXA_AP_INVPERM
											,TAXA_AP_AMDS
											,TAXA_AP_DH
											,TAXA_AP_DIT
											,TAXA_AP
											,CARREGA_PRINCIPAL
											,CARREGA_CONJUGE
											,CARREGA_FILHOS
											,GARAN_ADIC_IEA
											,GARAN_ADIC_IPA
											,GARAN_ADIC_IPD
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.CONDITEC_COD_SUBGRUPO}'";

            return query;
        }
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
        public string CONDITEC_COD_SUBGRUPO { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1 Execute(R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1 r0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1)
        {
            var ths = r0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0770_00_SELECT_CONDITEC_DB_SELECT_1_Query1();
            var i = 0;
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
            return dta;
        }

    }
}