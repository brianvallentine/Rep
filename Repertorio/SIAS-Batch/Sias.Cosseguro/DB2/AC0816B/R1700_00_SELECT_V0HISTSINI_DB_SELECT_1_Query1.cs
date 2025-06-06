using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :V0HSIN-VAL-OPER
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V1CHSI-NUM-SINI
            AND OPERACAO = :V0HSIN-OPERACAO
            AND OCORHIST = :V1CHSI-OCORHIST
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1CHSI_NUM_SINI}'
											AND OPERACAO = '{this.V0HSIN_OPERACAO}'
											AND OCORHIST = '{this.V1CHSI_OCORHIST}'
											WITH UR";

            return query;
        }
        public string V0HSIN_VAL_OPER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V0HSIN_OPERACAO { get; set; }
        public string V1CHSI_OCORHIST { get; set; }

        public static R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 r1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSIN_VAL_OPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}