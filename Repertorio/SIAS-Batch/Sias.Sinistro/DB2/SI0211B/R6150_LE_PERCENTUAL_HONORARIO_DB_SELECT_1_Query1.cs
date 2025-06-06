using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1 : QueryBasis<R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(PCT_OPERACAO,0)
            INTO :HOST-PCT-OPERACAO
            FROM SEGUROS.SI_RESSARC_PARCELA P
            WHERE P.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND P.OCORR_HISTORICO = :SI111-OCORR-HISTORICO
            AND P.COD_OPERACAO = 4003
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(PCT_OPERACAO
							,0)
											FROM SEGUROS.SI_RESSARC_PARCELA P
											WHERE P.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND P.OCORR_HISTORICO = '{this.SI111_OCORR_HISTORICO}'
											AND P.COD_OPERACAO = 4003";

            return query;
        }
        public string HOST_PCT_OPERACAO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }

        public static R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1 Execute(R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1 r6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1)
        {
            var ths = r6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_PCT_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}