using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1051S
{
    public class R1000_LE_MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R1000_LE_MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_HISTORICO),0)
            INTO :HOST-MAX-OCORR-HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_HISTORICO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string HOST_MAX_OCORR_HISTORICO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R1000_LE_MESTSINI_DB_SELECT_1_Query1 Execute(R1000_LE_MESTSINI_DB_SELECT_1_Query1 r1000_LE_MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1000_LE_MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_LE_MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_LE_MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_MAX_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}