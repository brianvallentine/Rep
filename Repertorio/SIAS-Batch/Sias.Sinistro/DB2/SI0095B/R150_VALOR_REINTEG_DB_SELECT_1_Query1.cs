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
    public class R150_VALOR_REINTEG_DB_SELECT_1_Query1 : QueryBasis<R150_VALOR_REINTEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(VALOR_RETENCAO * -1,0)
            INTO :HOST-VALOR-REINTEG
            FROM SEGUROS.SINI_LOT_ABAT02
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_RETENCAO = '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(VALOR_RETENCAO * -1
							,0)
											FROM SEGUROS.SINI_LOT_ABAT02
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_RETENCAO = '2'";

            return query;
        }
        public string HOST_VALOR_REINTEG { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R150_VALOR_REINTEG_DB_SELECT_1_Query1 Execute(R150_VALOR_REINTEG_DB_SELECT_1_Query1 r150_VALOR_REINTEG_DB_SELECT_1_Query1)
        {
            var ths = r150_VALOR_REINTEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R150_VALOR_REINTEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R150_VALOR_REINTEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_REINTEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}