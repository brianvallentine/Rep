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
    public class R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(FIM_PRAZO),+0)
            INTO :PRAZOSEG-FIM-PRAZO
            FROM SEGUROS.PRAZO_SEGURO
            WHERE PCT_PRM_ANUAL >= :PRAZOSEG-PCT-PRM-ANUAL
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(FIM_PRAZO)
							,+0)
											FROM SEGUROS.PRAZO_SEGURO
											WHERE PCT_PRM_ANUAL >= '{this.PRAZOSEG_PCT_PRM_ANUAL}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string PRAZOSEG_FIM_PRAZO { get; set; }
        public string PRAZOSEG_PCT_PRM_ANUAL { get; set; }

        public static R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1 r1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRAZOSEG_FIM_PRAZO = result[i++].Value?.ToString();
            return dta;
        }

    }
}