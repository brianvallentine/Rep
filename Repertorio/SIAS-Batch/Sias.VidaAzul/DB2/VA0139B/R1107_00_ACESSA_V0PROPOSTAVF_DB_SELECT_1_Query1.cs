using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1 : QueryBasis<R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NRTIT
            INTO :V0PRVF-NRTIT
            FROM SEGUROS.V0PROPOSTAVF
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NRTIT
											FROM SEGUROS.V0PROPOSTAVF
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'";

            return query;
        }
        public string V0PRVF_NRTIT { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }

        public static R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1 Execute(R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1 r1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1)
        {
            var ths = r1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRVF_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}