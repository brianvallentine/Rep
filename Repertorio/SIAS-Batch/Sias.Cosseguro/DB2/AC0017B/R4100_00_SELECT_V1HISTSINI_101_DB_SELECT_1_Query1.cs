using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1 : QueryBasis<R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO,
            DTMOVTO
            INTO :V2HSIN-VAL-OPER,
            :V2HSIN-DTMOVTO
            FROM SEGUROS.V1HISTSINI
            WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI
            AND OPERACAO = 0101
            AND OCORHIST = 01
            AND TIPREG = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
							,
											DTMOVTO
											FROM SEGUROS.V1HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND OPERACAO = 0101
											AND OCORHIST = 01
											AND TIPREG = '1'";

            return query;
        }
        public string V2HSIN_VAL_OPER { get; set; }
        public string V2HSIN_DTMOVTO { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }

        public static R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1 Execute(R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1 r4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1)
        {
            var ths = r4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1();
            var i = 0;
            dta.V2HSIN_VAL_OPER = result[i++].Value?.ToString();
            dta.V2HSIN_DTMOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}