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
    public class R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1 : QueryBasis<R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROTOCOLO_SINI
            INTO :SINISMES-NUM-PROTOCOLO-SINI
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROTOCOLO_SINI
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1 Execute(R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1 r120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1)
        {
            var ths = r120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R120_VALIDA_INDENIZACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}