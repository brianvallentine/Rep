using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            SIT_CONGENERE
            INTO
            :V1CPRE-SIT-CONG
            FROM
            SEGUROS.V1COSSEG_PREM
            WHERE
            CONGENER = :V1CHIS-CONGENER
            AND NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            AND NRPARCEL = 01
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_CONGENERE
											FROM
											SEGUROS.V1COSSEG_PREM
											WHERE
											CONGENER = '{this.V1CHIS_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'
											AND NRPARCEL = 01
											AND TIPSGU = '1'";

            return query;
        }
        public string V1CPRE_SIT_CONG { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }

        public static R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1 r1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CPRE_SIT_CONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}