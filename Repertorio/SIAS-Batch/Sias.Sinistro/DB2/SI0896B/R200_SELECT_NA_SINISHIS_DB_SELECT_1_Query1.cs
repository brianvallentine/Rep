using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0896B
{
    public class R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO,
            DATA_MOVIMENTO,
            VAL_OPERACAO
            INTO :SINISHIS-COD-OPERACAO,
            :SINISHIS-DATA-MOVIMENTO,
            :SINISHIS-VAL-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINIPLAN-OCORHIST
            AND COD_OPERACAO IN (1001,1002,1003,1004,1009)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO
							,
											DATA_MOVIMENTO
							,
											VAL_OPERACAO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINIPLAN_OCORHIST}'
											AND COD_OPERACAO IN (1001
							,1002
							,1003
							,1004
							,1009)";

            return query;
        }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINIPLAN_OCORHIST { get; set; }

        public static R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1 Execute(R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1 r200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}