using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1 : QueryBasis<R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            DESCR_CAUSA
            INTO :SINISCAU-DESCR-CAUSA
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = :V0MSIN-RAMO
            AND COD_CAUSA = :V0MSIN-CODCAU
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DESCR_CAUSA
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = '{this.V0MSIN_RAMO}'
											AND COD_CAUSA = '{this.V0MSIN_CODCAU}'
											WITH UR";

            return query;
        }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string V0MSIN_CODCAU { get; set; }
        public string V0MSIN_RAMO { get; set; }

        public static R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1 Execute(R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1 r1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1)
        {
            var ths = r1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}