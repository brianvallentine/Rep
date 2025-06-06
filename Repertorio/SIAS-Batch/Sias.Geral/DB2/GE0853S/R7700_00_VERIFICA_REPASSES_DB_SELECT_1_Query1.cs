using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 : QueryBasis<R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTCDG
            INTO :V0CDGC-VLCUSTCDG
            FROM SEGUROS.V0CDGCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTTERVIG = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTCDG
											FROM SEGUROS.V0CDGCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTTERVIG = '9999-12-31'
											WITH UR";

            return query;
        }
        public string V0CDGC_VLCUSTCDG { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 Execute(R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 r7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1)
        {
            var ths = r7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CDGC_VLCUSTCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}