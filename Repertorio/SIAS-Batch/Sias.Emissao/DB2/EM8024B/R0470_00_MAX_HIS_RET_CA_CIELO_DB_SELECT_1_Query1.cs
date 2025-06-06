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
    public class R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1 : QueryBasis<R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_RET_CONTROL_HIST),0) + 1
            INTO :WS-HOST-PROX-SEQ-HIST
            FROM SEGUROS.GE_RETORNO_CA_CIELO
            WHERE NUM_CERTIFICADO = :GE408-NUM-CERTIFICADO
            AND NUM_PARCELA = :GE408-NUM-PARCELA
            AND SEQ_CONTROL_CARTAO = :GE408-SEQ-CONTROL-CARTAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_RET_CONTROL_HIST)
							,0) + 1
											FROM SEGUROS.GE_RETORNO_CA_CIELO
											WHERE NUM_CERTIFICADO = '{this.GE408_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.GE408_NUM_PARCELA}'
											AND SEQ_CONTROL_CARTAO = '{this.GE408_SEQ_CONTROL_CARTAO}'
											WITH UR";

            return query;
        }
        public string WS_HOST_PROX_SEQ_HIST { get; set; }
        public string GE408_SEQ_CONTROL_CARTAO { get; set; }
        public string GE408_NUM_CERTIFICADO { get; set; }
        public string GE408_NUM_PARCELA { get; set; }

        public static R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1 Execute(R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1 r0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1)
        {
            var ths = r0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_PROX_SEQ_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}