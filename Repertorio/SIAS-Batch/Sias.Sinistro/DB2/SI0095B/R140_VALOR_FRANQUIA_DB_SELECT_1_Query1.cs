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
    public class R140_VALOR_FRANQUIA_DB_SELECT_1_Query1 : QueryBasis<R140_VALOR_FRANQUIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(VALOR_RETENCAO * -1,0)
            INTO :HOST-VALOR-FRANQUIA
            FROM SEGUROS.SINI_LOT_ABAT02
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_RETENCAO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(VALOR_RETENCAO * -1
							,0)
											FROM SEGUROS.SINI_LOT_ABAT02
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_RETENCAO = '1'";

            return query;
        }
        public string HOST_VALOR_FRANQUIA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R140_VALOR_FRANQUIA_DB_SELECT_1_Query1 Execute(R140_VALOR_FRANQUIA_DB_SELECT_1_Query1 r140_VALOR_FRANQUIA_DB_SELECT_1_Query1)
        {
            var ths = r140_VALOR_FRANQUIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R140_VALOR_FRANQUIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R140_VALOR_FRANQUIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_FRANQUIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}