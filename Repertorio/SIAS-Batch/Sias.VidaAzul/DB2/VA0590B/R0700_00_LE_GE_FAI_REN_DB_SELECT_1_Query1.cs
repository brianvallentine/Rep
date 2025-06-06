using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1 : QueryBasis<R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLR_MIN_FAIXA
            , VLR_MAX_FAIXA
            INTO :GE243-VLR-MIN-FAIXA
            ,:GE243-VLR-MAX-FAIXA
            FROM SEGUROS.GE_FAIXA_RENDA
            WHERE NUM_FAIXA_RENDA = :GE243-NUM-FAIXA-RENDA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLR_MIN_FAIXA
											, VLR_MAX_FAIXA
											FROM SEGUROS.GE_FAIXA_RENDA
											WHERE NUM_FAIXA_RENDA = '{this.GE243_NUM_FAIXA_RENDA}'
											WITH UR";

            return query;
        }
        public string GE243_VLR_MIN_FAIXA { get; set; }
        public string GE243_VLR_MAX_FAIXA { get; set; }
        public string GE243_NUM_FAIXA_RENDA { get; set; }

        public static R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1 Execute(R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1 r0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1)
        {
            var ths = r0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE243_VLR_MIN_FAIXA = result[i++].Value?.ToString();
            dta.GE243_VLR_MAX_FAIXA = result[i++].Value?.ToString();
            return dta;
        }

    }
}