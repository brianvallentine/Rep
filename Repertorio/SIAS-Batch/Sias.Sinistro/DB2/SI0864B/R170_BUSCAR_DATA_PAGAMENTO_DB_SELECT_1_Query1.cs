using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1 : QueryBasis<R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO
            INTO :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 1003
            AND SIT_REGISTRO <> '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 1003
											AND SIT_REGISTRO <> '2'";

            return query;
        }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1 Execute(R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1 r170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}