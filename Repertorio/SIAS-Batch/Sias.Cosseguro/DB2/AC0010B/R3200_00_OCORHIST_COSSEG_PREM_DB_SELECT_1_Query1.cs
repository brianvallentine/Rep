using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1 : QueryBasis<R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :WHOST-OCORHIST
            FROM SEGUROS.V1COSSEG_PREM
            WHERE CONGENER = :V1APCD-CODCOSS
            AND NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V1COSSEG_PREM
											WHERE CONGENER = '{this.V1APCD_CODCOSS}'
											AND NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'
											AND TIPSGU = '1'";

            return query;
        }
        public string WHOST_OCORHIST { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1 Execute(R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1 r3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}