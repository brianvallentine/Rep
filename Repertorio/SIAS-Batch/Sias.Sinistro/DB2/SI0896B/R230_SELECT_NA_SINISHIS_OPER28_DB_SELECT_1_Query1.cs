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
    public class R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1 : QueryBasis<R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :HOST-VAL-PRM-REMANESC
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINIPLAN-OCORHIST
            AND COD_OPERACAO = 28
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINIPLAN_OCORHIST}'
											AND COD_OPERACAO = 28";

            return query;
        }
        public string HOST_VAL_PRM_REMANESC { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINIPLAN_OCORHIST { get; set; }

        public static R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1 Execute(R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1 r230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1)
        {
            var ths = r230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VAL_PRM_REMANESC = result[i++].Value?.ToString();
            return dta;
        }

    }
}