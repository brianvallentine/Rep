using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VAL_OPERACAO
            INTO :V0HSIN-VAL-OPERACAO
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V0MSIN-NUM-SINI
            AND OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_OPERACAO
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MSIN_NUM_SINI}'
											AND OPERACAO = 101";

            return query;
        }
        public string V0HSIN_VAL_OPERACAO { get; set; }
        public string V0MSIN_NUM_SINI { get; set; }

        public static R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 r1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSIN_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}