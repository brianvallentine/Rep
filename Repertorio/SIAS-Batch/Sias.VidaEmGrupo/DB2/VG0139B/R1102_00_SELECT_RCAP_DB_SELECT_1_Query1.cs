using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 : QueryBasis<R1102_00_SELECT_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            AGEAVISO ,
            NRAVISO
            INTO :V1RCAC-AGEAVISO ,
            :V1RCAC-NRAVISO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRTIT = :V0RCAP-NRTIT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											AGEAVISO 
							,
											NRAVISO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'
											WITH UR";

            return query;
        }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 Execute(R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 r1102_00_SELECT_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1102_00_SELECT_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RCAC_AGEAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_NRAVISO = result[i++].Value?.ToString();
            return dta;
        }

    }
}