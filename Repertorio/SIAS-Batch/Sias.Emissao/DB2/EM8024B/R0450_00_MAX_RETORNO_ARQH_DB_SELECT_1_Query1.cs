using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1 : QueryBasis<R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_RETORNO_MOVIMENTO),0) + 1
            INTO :WS-HOST-PROX-SEQ-ARQH
            FROM SEGUROS.GE_CONTROLE_ARQH
            WHERE NUM_OCORR_MOVTO = :GE105-NUM-OCORR-MOVTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_RETORNO_MOVIMENTO)
							,0) + 1
											FROM SEGUROS.GE_CONTROLE_ARQH
											WHERE NUM_OCORR_MOVTO = '{this.GE105_NUM_OCORR_MOVTO}'
											WITH UR";

            return query;
        }
        public string WS_HOST_PROX_SEQ_ARQH { get; set; }
        public string GE105_NUM_OCORR_MOVTO { get; set; }

        public static R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1 Execute(R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1 r0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_PROX_SEQ_ARQH = result[i++].Value?.ToString();
            return dta;
        }

    }
}