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
    public class R130_VALOR_APURADO_DB_SELECT_1_Query1 : QueryBasis<R130_VALOR_APURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO,
            DATA_MOVIMENTO
            INTO :HOST-VALOR-APURADO,
            :HOST-DATA-VALOR-APURADO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO = :HOST-COD-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
							,
											DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO = '{this.HOST_COD_OPERACAO}'";

            return query;
        }
        public string HOST_VALOR_APURADO { get; set; }
        public string HOST_DATA_VALOR_APURADO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string HOST_COD_OPERACAO { get; set; }

        public static R130_VALOR_APURADO_DB_SELECT_1_Query1 Execute(R130_VALOR_APURADO_DB_SELECT_1_Query1 r130_VALOR_APURADO_DB_SELECT_1_Query1)
        {
            var ths = r130_VALOR_APURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_VALOR_APURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_VALOR_APURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_APURADO = result[i++].Value?.ToString();
            dta.HOST_DATA_VALOR_APURADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}