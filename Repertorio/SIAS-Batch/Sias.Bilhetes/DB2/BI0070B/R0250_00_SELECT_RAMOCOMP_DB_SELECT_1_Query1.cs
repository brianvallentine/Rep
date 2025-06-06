using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 : QueryBasis<R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_IOCC_RAMO
            INTO :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR = :BILHETE-RAMO
            AND DATA_INIVIGENCIA <= :WSGER00-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :WSGER00-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_IOCC_RAMO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR = '{this.BILHETE_RAMO}'
											AND DATA_INIVIGENCIA <= '{this.WSGER00_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.WSGER00_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string WSGER00_DATA_INIVIGENCIA { get; set; }
        public string BILHETE_RAMO { get; set; }

        public static R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 Execute(R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 r0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}