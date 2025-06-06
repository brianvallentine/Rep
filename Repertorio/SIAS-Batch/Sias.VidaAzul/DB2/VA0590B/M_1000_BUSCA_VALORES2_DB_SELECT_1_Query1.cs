using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1 : QueryBasis<M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU,
            VLPREMIO
            INTO :HISCOBPR-IMP-MORNATU
            , :HISCOBPR-VLPREMIO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND OCORR_HISTORICO = :HISCONPA-NUM-PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU
							,
											VLPREMIO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND OCORR_HISTORICO = '{this.HISCONPA_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1 Execute(M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1 m_1000_BUSCA_VALORES2_DB_SELECT_1_Query1)
        {
            var ths = m_1000_BUSCA_VALORES2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}