using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0005B
{
    public class R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :WHOST-OCORHIST
            FROM SEGUROS.V1COSSEG_PREM
            WHERE CONGENER = :V0COSC-CODLIDER
            AND NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            AND NRPARCEL = :V0HISP-NRPARCEL
            AND TIPSGU = '0'
            AND NUM_ORDEM = :V0COSC-ORDLIDER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V1COSSEG_PREM
											WHERE CONGENER = '{this.V0COSC_CODLIDER}'
											AND NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'
											AND NRPARCEL = '{this.V0HISP_NRPARCEL}'
											AND TIPSGU = '0'
											AND NUM_ORDEM = '{this.V0COSC_ORDLIDER}'";

            return query;
        }
        public string WHOST_OCORHIST { get; set; }
        public string V0COSC_CODLIDER { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0COSC_ORDLIDER { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 r1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}