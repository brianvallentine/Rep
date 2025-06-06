using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1466B
{
    public class R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 : QueryBasis<R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DATCEF)
            INTO :V0CONT-DATCEF
            FROM SEGUROS.V0CONTROCNAB
            WHERE NRCTACED = 63000300001004
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DATCEF)
											FROM SEGUROS.V0CONTROCNAB
											WHERE NRCTACED = 63000300001004";

            return query;
        }
        public string V0CONT_DATCEF { get; set; }

        public static R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 Execute(R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CONT_DATCEF = result[i++].Value?.ToString();
            return dta;
        }

    }
}