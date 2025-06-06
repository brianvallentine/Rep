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
    public class R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1 : QueryBasis<R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :HOST-VAL-FRANQUIA-CEF
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINIPLAN-OCORHIST
            AND COD_OPERACAO = 2
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINIPLAN_OCORHIST}'
											AND COD_OPERACAO = 2";

            return query;
        }
        public string HOST_VAL_FRANQUIA_CEF { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINIPLAN_OCORHIST { get; set; }

        public static R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1 Execute(R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1 r220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1)
        {
            var ths = r220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VAL_FRANQUIA_CEF = result[i++].Value?.ToString();
            return dta;
        }

    }
}