using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0032B
{
    public class R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO ,
            DIA_SEMANA
            INTO :V0CALE-DTMOVTO ,
            :V0CALE-DIASEM
            FROM SEGUROS.V0CALENDARIO
            WHERE DATA_CALENDARIO = :V0CALE-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO 
							,
											DIA_SEMANA
											FROM SEGUROS.V0CALENDARIO
											WHERE DATA_CALENDARIO = '{this.V0CALE_DTMOVTO}'";

            return query;
        }
        public string V0CALE_DTMOVTO { get; set; }
        public string V0CALE_DIASEM { get; set; }

        public static R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1 r1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CALE_DTMOVTO = result[i++].Value?.ToString();
            dta.V0CALE_DIASEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}