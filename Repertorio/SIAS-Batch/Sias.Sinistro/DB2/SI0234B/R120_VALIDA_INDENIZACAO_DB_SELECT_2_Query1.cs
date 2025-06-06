using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0234B
{
    public class R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1 : QueryBasis<R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO IN (1001,1002,1003,1004)
            AND SIT_REGISTRO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO IN (1001
							,1002
							,1003
							,1004)
											AND SIT_REGISTRO = '1'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1 Execute(R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1 r120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1)
        {
            var ths = r120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R120_VALIDA_INDENIZACAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}