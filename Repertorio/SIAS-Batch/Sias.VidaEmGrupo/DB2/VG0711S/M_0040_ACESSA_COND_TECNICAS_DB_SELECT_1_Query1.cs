using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1 : QueryBasis<M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(CARREGA_CONJUGE, 0),
            VALUE(CARREGA_FILHOS, 0),
            VALUE(TAXA_AP_MORACID, 0),
            VALUE(TAXA_AP_INVPERM, 0),
            VALUE(TAXA_AP_AMDS, 0),
            VALUE(TAXA_AP_DH, 0),
            VALUE(TAXA_AP_DIT, 0),
            VALUE(GARAN_ADIC_IEA, 0),
            VALUE(GARAN_ADIC_IPA, 0),
            VALUE(GARAN_ADIC_IPD, 0),
            VALUE(GARAN_ADIC_HD, 0)
            INTO :CONDITEC-CARREGA-CONJUGE,
            :CONDITEC-CARREGA-FILHOS,
            :TAXA-AP-MORACID,
            :TAXA-AP-INVPERM,
            :TAXA-AP-AMDS,
            :TAXA-AP-DH,
            :TAXA-AP-DIT,
            :GARAN-ADIC-IEA,
            :GARAN-ADIC-IPA,
            :GARAN-ADIC-IPD,
            :GARAN-ADIC-HD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND COD_SUBGRUPO = :WS-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(CARREGA_CONJUGE
							, 0)
							,
											VALUE(CARREGA_FILHOS
							, 0)
							,
											VALUE(TAXA_AP_MORACID
							, 0)
							,
											VALUE(TAXA_AP_INVPERM
							, 0)
							,
											VALUE(TAXA_AP_AMDS
							, 0)
							,
											VALUE(TAXA_AP_DH
							, 0)
							,
											VALUE(TAXA_AP_DIT
							, 0)
							,
											VALUE(GARAN_ADIC_IEA
							, 0)
							,
											VALUE(GARAN_ADIC_IPA
							, 0)
							,
											VALUE(GARAN_ADIC_IPD
							, 0)
							,
											VALUE(GARAN_ADIC_HD
							, 0)
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WS_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string CONDITEC_CARREGA_FILHOS { get; set; }
        public string TAXA_AP_MORACID { get; set; }
        public string TAXA_AP_INVPERM { get; set; }
        public string TAXA_AP_AMDS { get; set; }
        public string TAXA_AP_DH { get; set; }
        public string TAXA_AP_DIT { get; set; }
        public string GARAN_ADIC_IEA { get; set; }
        public string GARAN_ADIC_IPA { get; set; }
        public string GARAN_ADIC_IPD { get; set; }
        public string GARAN_ADIC_HD { get; set; }
        public string WS_COD_SUBGRUPO { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1 Execute(M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1 m_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1)
        {
            var ths = m_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            dta.CONDITEC_CARREGA_FILHOS = result[i++].Value?.ToString();
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