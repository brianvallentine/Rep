using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO ,
            (DATA_CALENDARIO + 030 DAYS),
            (DATA_CALENDARIO + 031 DAYS),
            (DATA_CALENDARIO + 060 DAYS),
            (DATA_CALENDARIO + 061 DAYS),
            (DATA_CALENDARIO + 090 DAYS),
            (DATA_CALENDARIO + 091 DAYS),
            (DATA_CALENDARIO + 120 DAYS),
            (DATA_CALENDARIO + 121 DAYS),
            (DATA_CALENDARIO + 150 DAYS),
            (DATA_CALENDARIO + 151 DAYS),
            (DATA_CALENDARIO + 180 DAYS),
            (DATA_CALENDARIO + 181 DAYS),
            (DATA_CALENDARIO + 210 DAYS),
            (DATA_CALENDARIO + 211 DAYS),
            (DATA_CALENDARIO + 240 DAYS),
            (DATA_CALENDARIO + 241 DAYS),
            (DATA_CALENDARIO + 270 DAYS),
            (DATA_CALENDARIO + 271 DAYS),
            (DATA_CALENDARIO + 300 DAYS),
            (DATA_CALENDARIO + 301 DAYS),
            (DATA_CALENDARIO + 330 DAYS),
            (DATA_CALENDARIO + 331 DAYS),
            (DATA_CALENDARIO + 360 DAYS),
            (DATA_CALENDARIO + 361 DAYS),
            (DATA_CALENDARIO + 390 DAYS),
            (DATA_CALENDARIO + 391 DAYS),
            (DATA_CALENDARIO + 420 DAYS),
            (DATA_CALENDARIO + 421 DAYS),
            (DATA_CALENDARIO + 450 DAYS)
            INTO :WSGER01-DATA-INIVIGENCIA ,
            :WSGER01-DATA-TERVIGENCIA ,
            :WSGER02-DATA-INIVIGENCIA ,
            :WSGER02-DATA-TERVIGENCIA ,
            :WSGER03-DATA-INIVIGENCIA ,
            :WSGER03-DATA-TERVIGENCIA ,
            :WSGER04-DATA-INIVIGENCIA ,
            :WSGER04-DATA-TERVIGENCIA ,
            :WSGER05-DATA-INIVIGENCIA ,
            :WSGER05-DATA-TERVIGENCIA ,
            :WSGER06-DATA-INIVIGENCIA ,
            :WSGER06-DATA-TERVIGENCIA ,
            :WSGER07-DATA-INIVIGENCIA ,
            :WSGER07-DATA-TERVIGENCIA ,
            :WSGER08-DATA-INIVIGENCIA ,
            :WSGER08-DATA-TERVIGENCIA ,
            :WSGER09-DATA-INIVIGENCIA ,
            :WSGER09-DATA-TERVIGENCIA ,
            :WSGER10-DATA-INIVIGENCIA ,
            :WSGER10-DATA-TERVIGENCIA ,
            :WSGER11-DATA-INIVIGENCIA ,
            :WSGER11-DATA-TERVIGENCIA ,
            :WSGER12-DATA-INIVIGENCIA ,
            :WSGER12-DATA-TERVIGENCIA ,
            :WSGER13-DATA-INIVIGENCIA ,
            :WSGER13-DATA-TERVIGENCIA ,
            :WSGER14-DATA-INIVIGENCIA ,
            :WSGER14-DATA-TERVIGENCIA ,
            :WSGER15-DATA-INIVIGENCIA ,
            :WSGER15-DATA-TERVIGENCIA
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO =
            :CALENDAR-DATA-CALENDARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO 
							,
											(DATA_CALENDARIO + 030 DAYS)
							,
											(DATA_CALENDARIO + 031 DAYS)
							,
											(DATA_CALENDARIO + 060 DAYS)
							,
											(DATA_CALENDARIO + 061 DAYS)
							,
											(DATA_CALENDARIO + 090 DAYS)
							,
											(DATA_CALENDARIO + 091 DAYS)
							,
											(DATA_CALENDARIO + 120 DAYS)
							,
											(DATA_CALENDARIO + 121 DAYS)
							,
											(DATA_CALENDARIO + 150 DAYS)
							,
											(DATA_CALENDARIO + 151 DAYS)
							,
											(DATA_CALENDARIO + 180 DAYS)
							,
											(DATA_CALENDARIO + 181 DAYS)
							,
											(DATA_CALENDARIO + 210 DAYS)
							,
											(DATA_CALENDARIO + 211 DAYS)
							,
											(DATA_CALENDARIO + 240 DAYS)
							,
											(DATA_CALENDARIO + 241 DAYS)
							,
											(DATA_CALENDARIO + 270 DAYS)
							,
											(DATA_CALENDARIO + 271 DAYS)
							,
											(DATA_CALENDARIO + 300 DAYS)
							,
											(DATA_CALENDARIO + 301 DAYS)
							,
											(DATA_CALENDARIO + 330 DAYS)
							,
											(DATA_CALENDARIO + 331 DAYS)
							,
											(DATA_CALENDARIO + 360 DAYS)
							,
											(DATA_CALENDARIO + 361 DAYS)
							,
											(DATA_CALENDARIO + 390 DAYS)
							,
											(DATA_CALENDARIO + 391 DAYS)
							,
											(DATA_CALENDARIO + 420 DAYS)
							,
											(DATA_CALENDARIO + 421 DAYS)
							,
											(DATA_CALENDARIO + 450 DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO =
											'{this.CALENDAR_DATA_CALENDARIO}'
											WITH UR";

            return query;
        }
        public string WSGER01_DATA_INIVIGENCIA { get; set; }
        public string WSGER01_DATA_TERVIGENCIA { get; set; }
        public string WSGER02_DATA_INIVIGENCIA { get; set; }
        public string WSGER02_DATA_TERVIGENCIA { get; set; }
        public string WSGER03_DATA_INIVIGENCIA { get; set; }
        public string WSGER03_DATA_TERVIGENCIA { get; set; }
        public string WSGER04_DATA_INIVIGENCIA { get; set; }
        public string WSGER04_DATA_TERVIGENCIA { get; set; }
        public string WSGER05_DATA_INIVIGENCIA { get; set; }
        public string WSGER05_DATA_TERVIGENCIA { get; set; }
        public string WSGER06_DATA_INIVIGENCIA { get; set; }
        public string WSGER06_DATA_TERVIGENCIA { get; set; }
        public string WSGER07_DATA_INIVIGENCIA { get; set; }
        public string WSGER07_DATA_TERVIGENCIA { get; set; }
        public string WSGER08_DATA_INIVIGENCIA { get; set; }
        public string WSGER08_DATA_TERVIGENCIA { get; set; }
        public string WSGER09_DATA_INIVIGENCIA { get; set; }
        public string WSGER09_DATA_TERVIGENCIA { get; set; }
        public string WSGER10_DATA_INIVIGENCIA { get; set; }
        public string WSGER10_DATA_TERVIGENCIA { get; set; }
        public string WSGER11_DATA_INIVIGENCIA { get; set; }
        public string WSGER11_DATA_TERVIGENCIA { get; set; }
        public string WSGER12_DATA_INIVIGENCIA { get; set; }
        public string WSGER12_DATA_TERVIGENCIA { get; set; }
        public string WSGER13_DATA_INIVIGENCIA { get; set; }
        public string WSGER13_DATA_TERVIGENCIA { get; set; }
        public string WSGER14_DATA_INIVIGENCIA { get; set; }
        public string WSGER14_DATA_TERVIGENCIA { get; set; }
        public string WSGER15_DATA_INIVIGENCIA { get; set; }
        public string WSGER15_DATA_TERVIGENCIA { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WSGER01_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER01_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER02_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER02_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER03_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER03_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER04_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER04_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER05_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER05_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER06_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER06_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER07_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER07_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER08_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER08_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER09_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER09_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER10_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER10_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER11_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER11_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER12_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER12_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER13_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER13_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER14_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER14_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER15_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER15_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}