using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1 : QueryBasis<R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + :PRAZOSEG-FIM-PRAZO DAYS)
            INTO :WS-HOST-DATA-FIM-VIG-PROP
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WS-HOST-DTINIVIG-APOL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + {this.PRAZOSEG_FIM_PRAZO} DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WS_HOST_DTINIVIG_APOL}'
											WITH UR";

            return query;
        }
        public string WS_HOST_DATA_FIM_VIG_PROP { get; set; }
        public string WS_HOST_DTINIVIG_APOL { get; set; }
        public string PRAZOSEG_FIM_PRAZO { get; set; }

        public static R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1 Execute(R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1 r1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1)
        {
            var ths = r1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_HOST_DATA_FIM_VIG_PROP = result[i++].Value?.ToString();
            return dta;
        }

    }
}