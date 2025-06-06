using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8000_INTEGRA_VG_DB_SELECT_1_Query1 : QueryBasis<M_8000_INTEGRA_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GARAN_ADIC_IEA,
            GARAN_ADIC_IPA
            INTO :CONDTE-IEA,
            :CONDTE-IPA
            FROM SEGUROS.V0CONDTEC
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
											FROM SEGUROS.V0CONDTEC
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'";

            return query;
        }
        public string CONDTE_IEA { get; set; }
        public string CONDTE_IPA { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_8000_INTEGRA_VG_DB_SELECT_1_Query1 Execute(M_8000_INTEGRA_VG_DB_SELECT_1_Query1 m_8000_INTEGRA_VG_DB_SELECT_1_Query1)
        {
            var ths = m_8000_INTEGRA_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8000_INTEGRA_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8000_INTEGRA_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDTE_IEA = result[i++].Value?.ToString();
            dta.CONDTE_IPA = result[i++].Value?.ToString();
            return dta;
        }

    }
}