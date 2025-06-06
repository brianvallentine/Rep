using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0095B
{
    public class R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1 : QueryBasis<R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VALOR_RETENCAO * -1),0)
            INTO :HOST-VALOR-IOF-AGRAV
            FROM SEGUROS.SINI_LOT_ABAT02
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_RETENCAO = '6'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VALOR_RETENCAO * -1)
							,0)
											FROM SEGUROS.SINI_LOT_ABAT02
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_RETENCAO = '6'";

            return query;
        }
        public string HOST_VALOR_IOF_AGRAV { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1 Execute(R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1 r180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1)
        {
            var ths = r180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_IOF_AGRAV = result[i++].Value?.ToString();
            return dta;
        }

    }
}