using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9107B
{
    public class R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :HOST-COUNT
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND COD_OPERACAO IN (1081, 1082, 1083, 1084,
            1181, 1182, 1183, 1184)
            AND SIT_REGISTRO <> '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO IN (1081
							, 1082
							, 1083
							, 1084
							,
											1181
							, 1182
							, 1183
							, 1184)
											AND SIT_REGISTRO <> '2'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1 Execute(R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1 r1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}