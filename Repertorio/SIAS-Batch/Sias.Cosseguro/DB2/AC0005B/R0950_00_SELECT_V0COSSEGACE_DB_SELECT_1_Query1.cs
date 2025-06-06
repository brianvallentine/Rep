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
    public class R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1 : QueryBasis<R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NRENDOS,
            CODLIDER ,
            ORDLIDER ,
            PCCOMCOS
            INTO :V0COSC-NUM-APOL ,
            :V0COSC-NRENDOS ,
            :V0COSC-CODLIDER ,
            :V0COSC-ORDLIDER ,
            :V0COSC-PCCOMCOS
            FROM SEGUROS.V0COSSEGACE
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NRENDOS
							,
											CODLIDER 
							,
											ORDLIDER 
							,
											PCCOMCOS
											FROM SEGUROS.V0COSSEGACE
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'";

            return query;
        }
        public string V0COSC_NUM_APOL { get; set; }
        public string V0COSC_NRENDOS { get; set; }
        public string V0COSC_CODLIDER { get; set; }
        public string V0COSC_ORDLIDER { get; set; }
        public string V0COSC_PCCOMCOS { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1 Execute(R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1 r0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1)
        {
            var ths = r0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COSC_NUM_APOL = result[i++].Value?.ToString();
            dta.V0COSC_NRENDOS = result[i++].Value?.ToString();
            dta.V0COSC_CODLIDER = result[i++].Value?.ToString();
            dta.V0COSC_ORDLIDER = result[i++].Value?.ToString();
            dta.V0COSC_PCCOMCOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}