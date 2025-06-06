using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0857B
{
    public class R31020_LE_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R31020_LE_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_IRB,
            COD_PRODUTO
            INTO
            :SINISMES-NUM-IRB,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE COD_FONTE = :SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_IRB
							,
											COD_PRODUTO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SIDOCACO_DAC_PROTOCOLO_SINI}'";

            return query;
        }
        public string SINISMES_NUM_IRB { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R31020_LE_SINISMES_DB_SELECT_1_Query1 Execute(R31020_LE_SINISMES_DB_SELECT_1_Query1 r31020_LE_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r31020_LE_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31020_LE_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31020_LE_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_NUM_IRB = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}