using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1 : QueryBasis<R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_PRODUTO = :SINISHIS-COD-PRODUTO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO = 1070
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_PRODUTO = '{this.SINISHIS_COD_PRODUTO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO = 1070";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }

        public static R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1 Execute(R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1 r110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1)
        {
            var ths = r110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}