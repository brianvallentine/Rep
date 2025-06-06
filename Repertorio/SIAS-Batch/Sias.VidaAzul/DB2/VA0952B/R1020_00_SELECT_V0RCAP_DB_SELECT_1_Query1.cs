using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0952B
{
    public class R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE ,
            NRRCAP ,
            SITUACAO
            INTO :V0RCAP-COD-FONTE ,
            :V0RCAP-NUM-RCAP ,
            :V0RCAP-SIT-REGISTRO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :WHOST-NUMTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE 
							,
											NRRCAP 
							,
											SITUACAO
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.WHOST_NUMTIT}'";

            return query;
        }
        public string V0RCAP_COD_FONTE { get; set; }
        public string V0RCAP_NUM_RCAP { get; set; }
        public string V0RCAP_SIT_REGISTRO { get; set; }
        public string WHOST_NUMTIT { get; set; }

        public static R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_COD_FONTE = result[i++].Value?.ToString();
            dta.V0RCAP_NUM_RCAP = result[i++].Value?.ToString();
            dta.V0RCAP_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}