using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VLPREMIO
            INTO
            :HISCOBPR-VLPREMIO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLPREMIO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND OCORR_HISTORICO = '{this.PROPOVA_OCORR_HISTORICO}'";

            return query;
        }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }

        public static R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}