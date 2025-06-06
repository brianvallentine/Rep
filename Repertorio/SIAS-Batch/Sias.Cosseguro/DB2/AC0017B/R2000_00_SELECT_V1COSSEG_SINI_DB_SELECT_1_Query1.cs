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
    public class R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 : QueryBasis<R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CONGENER,
            NUM_SINISTRO,
            TIPSGU
            INTO :V1CSIN-CONGENER,
            :V1CSIN-NUM-SINI,
            :V1CSIN-TIPSGU
            FROM SEGUROS.V1COSSEG_SINI
            WHERE CONGENER = :V1APCD-CODCOSS
            AND NUM_SINISTRO = :V1MSIN-NUM-SINI
            AND TIPSGU = :V0APOL-TIPSGU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CONGENER
							,
											NUM_SINISTRO
							,
											TIPSGU
											FROM SEGUROS.V1COSSEG_SINI
											WHERE CONGENER = '{this.V1APCD_CODCOSS}'
											AND NUM_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND TIPSGU = '{this.V0APOL_TIPSGU}'";

            return query;
        }
        public string V1CSIN_CONGENER { get; set; }
        public string V1CSIN_NUM_SINI { get; set; }
        public string V1CSIN_TIPSGU { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V0APOL_TIPSGU { get; set; }

        public static R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 Execute(R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 r2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CSIN_CONGENER = result[i++].Value?.ToString();
            dta.V1CSIN_NUM_SINI = result[i++].Value?.ToString();
            dta.V1CSIN_TIPSGU = result[i++].Value?.ToString();
            return dta;
        }

    }
}