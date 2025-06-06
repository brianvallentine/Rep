using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_IOCC_RAMO
            INTO :RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR = 93
            AND DATA_INIVIGENCIA <= :PROPOFID-DATA-PROPOSTA
            AND DATA_TERVIGENCIA >= :PROPOFID-DATA-PROPOSTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_IOCC_RAMO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR = 93
											AND DATA_INIVIGENCIA <= '{this.PROPOFID_DATA_PROPOSTA}'
											AND DATA_TERVIGENCIA >= '{this.PROPOFID_DATA_PROPOSTA}'";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }

        public static R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 r1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}