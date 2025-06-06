using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATARCAP
            INTO :WHOST-DATARCAP
            FROM SEGUROS.V0RCAPCOMP
            WHERE NRRCAP = :WHOST-NRRCAP
            AND OPERACAO >= 100
            AND OPERACAO <= 199
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATARCAP
											FROM SEGUROS.V0RCAPCOMP
											WHERE NRRCAP = '{this.WHOST_NRRCAP}'
											AND OPERACAO >= 100
											AND OPERACAO <= 199";

            return query;
        }
        public string WHOST_DATARCAP { get; set; }
        public string WHOST_NRRCAP { get; set; }

        public static R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 Execute(R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 r1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATARCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}