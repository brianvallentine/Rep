using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V0CHSP-OCORHIST
            FROM SEGUROS.V0COSSEG_PREM
            WHERE CONGENER = :V1CHSP-CONGENER
            AND NUM_APOLICE = :V1CHSP-NUM-APOL
            AND NRENDOS = :V1CHSP-NRENDOS
            AND NRPARCEL = :V1CHSP-NRPARCEL
            AND TIPSGU = :V1CHSP-TIPSGU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0COSSEG_PREM
											WHERE CONGENER = '{this.V1CHSP_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHSP_NUM_APOL}'
											AND NRENDOS = '{this.V1CHSP_NRENDOS}'
											AND NRPARCEL = '{this.V1CHSP_NRPARCEL}'
											AND TIPSGU = '{this.V1CHSP_TIPSGU}'";

            return query;
        }
        public string V0CHSP_OCORHIST { get; set; }
        public string V1CHSP_CONGENER { get; set; }
        public string V1CHSP_NUM_APOL { get; set; }
        public string V1CHSP_NRPARCEL { get; set; }
        public string V1CHSP_NRENDOS { get; set; }
        public string V1CHSP_TIPSGU { get; set; }

        public static R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1 r1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CHSP_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}