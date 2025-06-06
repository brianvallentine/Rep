using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0122B
{
    public class M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 : QueryBasis<M_300_150_240_COBERTURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD,
            GARAN_ADIC_HD
            INTO :CONDTEC-GAR-IEA,
            :CONDTEC-GAR-IPA,
            :CONDTEC-GAR-IPD,
            :CONDTEC-GAR-HD
            FROM SEGUROS.V1CONDTEC
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND COD_SUBGRUPO = :SEGURAVG-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
							,
											GARAN_ADIC_HD
											FROM SEGUROS.V1CONDTEC
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.SEGURAVG_COD_SUBG}'";

            return query;
        }
        public string CONDTEC_GAR_IEA { get; set; }
        public string CONDTEC_GAR_IPA { get; set; }
        public string CONDTEC_GAR_IPD { get; set; }
        public string CONDTEC_GAR_HD { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_COD_SUBG { get; set; }

        public static M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 Execute(M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 m_300_150_240_COBERTURAS_DB_SELECT_1_Query1)
        {
            var ths = m_300_150_240_COBERTURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_150_240_COBERTURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_150_240_COBERTURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDTEC_GAR_IEA = result[i++].Value?.ToString();
            dta.CONDTEC_GAR_IPA = result[i++].Value?.ToString();
            dta.CONDTEC_GAR_IPD = result[i++].Value?.ToString();
            dta.CONDTEC_GAR_HD = result[i++].Value?.ToString();
            return dta;
        }

    }
}