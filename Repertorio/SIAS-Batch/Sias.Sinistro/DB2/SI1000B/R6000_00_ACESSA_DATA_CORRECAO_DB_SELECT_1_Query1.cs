using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000B
{
    public class R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            MAX(DTMOVTO)
            INTO
            :V0HSIN-DTMOVTO-MAX:V0HSIN-VAR-INDICA
            FROM
            SEGUROS.V1HISTSINI
            WHERE
            NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND
            SITUACAO = '2' AND
            DTMOVTO <= :V1SIST-DTMOVABE AND
            OPERACAO IN (1001, 1009, 107, 117)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											MAX(DTMOVTO)
											FROM
											SEGUROS.V1HISTSINI
											WHERE
											NUM_APOL_SINISTRO = '{this.V1MSIN_NUM_SINI}' AND
											SITUACAO = '2' AND
											DTMOVTO <= '{this.V1SIST_DTMOVABE}' AND
											OPERACAO IN (1001
							, 1009
							, 107
							, 117)";

            return query;
        }
        public string V0HSIN_DTMOVTO_MAX { get; set; }
        public string V0HSIN_VAR_INDICA { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1 Execute(R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1 r6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSIN_DTMOVTO_MAX = result[i++].Value?.ToString();
            dta.V0HSIN_VAR_INDICA = string.IsNullOrWhiteSpace(dta.V0HSIN_DTMOVTO_MAX) ? "-1" : "0";
            return dta;
        }

    }
}