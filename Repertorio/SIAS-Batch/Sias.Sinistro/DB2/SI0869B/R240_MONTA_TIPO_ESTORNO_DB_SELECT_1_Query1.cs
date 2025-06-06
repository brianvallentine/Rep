using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1 : QueryBasis<R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO
            INTO :HOST-OPERACAO-EST
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORHIST = :SINISHIS-OCORR-HISTORICO
            AND OPERACAO IN (1001, 1003, 1004)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORHIST = '{this.SINISHIS_OCORR_HISTORICO}'
											AND OPERACAO IN (1001
							, 1003
							, 1004)";

            return query;
        }
        public string HOST_OPERACAO_EST { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1 Execute(R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1 r240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1)
        {
            var ths = r240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_OPERACAO_EST = result[i++].Value?.ToString();
            return dta;
        }

    }
}