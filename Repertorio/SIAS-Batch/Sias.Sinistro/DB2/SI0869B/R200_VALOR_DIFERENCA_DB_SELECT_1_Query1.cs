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
    public class R200_VALOR_DIFERENCA_DB_SELECT_1_Query1 : QueryBasis<R200_VALOR_DIFERENCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(VAL_OPERACAO,0)
            INTO :HOST-VALOR-DIFERENCA
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO = :HOST-COD-OPERACAO
            AND SIT_REGISTRO <> '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(VAL_OPERACAO
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO = '{this.HOST_COD_OPERACAO}'
											AND SIT_REGISTRO <> '2'";

            return query;
        }
        public string HOST_VALOR_DIFERENCA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string HOST_COD_OPERACAO { get; set; }

        public static R200_VALOR_DIFERENCA_DB_SELECT_1_Query1 Execute(R200_VALOR_DIFERENCA_DB_SELECT_1_Query1 r200_VALOR_DIFERENCA_DB_SELECT_1_Query1)
        {
            var ths = r200_VALOR_DIFERENCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_VALOR_DIFERENCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_VALOR_DIFERENCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_DIFERENCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}