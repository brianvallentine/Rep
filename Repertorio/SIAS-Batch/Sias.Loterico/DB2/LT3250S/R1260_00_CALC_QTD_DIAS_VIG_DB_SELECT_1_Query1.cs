using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3250S
{
    public class R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1 : QueryBasis<R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            (DAYS(:WS-DATA) -
            DAYS(:LT3250-DTINIVIG) + 1)
            INTO :WS-QTD-DIAS-VIGENCIA
            FROM SYSIBM.SYSDUMMY1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											(DAYS('{this.WS_DATA}') -
											DAYS('{this.LT3250_DTINIVIG}') + 1)
											FROM SYSIBM.SYSDUMMY1
											WITH UR";

            return query;
        }
        public string WS_QTD_DIAS_VIGENCIA { get; set; }
        public string LT3250_DTINIVIG { get; set; }
        public string WS_DATA { get; set; }

        public static R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1 Execute(R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1 r1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1)
        {
            var ths = r1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD_DIAS_VIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}