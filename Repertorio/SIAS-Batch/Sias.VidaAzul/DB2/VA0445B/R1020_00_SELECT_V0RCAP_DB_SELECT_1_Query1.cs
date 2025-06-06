using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0445B
{
    public class R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :WHOST-SITUACAO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :WHOST-NUMTIT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.WHOST_NUMTIT}'
											WITH UR";

            return query;
        }
        public string WHOST_SITUACAO { get; set; }
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
            dta.WHOST_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}