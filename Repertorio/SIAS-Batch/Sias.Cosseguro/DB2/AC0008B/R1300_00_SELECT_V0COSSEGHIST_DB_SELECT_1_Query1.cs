using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0008B
{
    public class R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WHOST-COUNT
            FROM SEGUROS.V0COSSEG_HISTPRE
            WHERE CONGENER IN (5240,5495,5886,
            6238,6858)
            AND NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = 00
            AND NRPARCEL IN (00,01)
            AND OCORHIST = 1
            AND OPERACAO < 200
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.V0COSSEG_HISTPRE
											WHERE CONGENER IN (5240
							,5495
							,5886
							,
											6238
							,6858)
											AND NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = 00
											AND NRPARCEL IN (00
							,01)
											AND OCORHIST = 1
											AND OPERACAO < 200
											AND TIPSGU = '1'";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string V0HISP_NUM_APOL { get; set; }

        public static R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1 r1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}