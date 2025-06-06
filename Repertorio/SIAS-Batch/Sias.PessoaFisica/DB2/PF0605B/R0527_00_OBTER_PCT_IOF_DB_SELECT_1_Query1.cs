using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 : QueryBasis<R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_IOCC_RAMO
            INTO :DCLRAMO-COMPLEMENTAR.RAMOCOMP-PCT-IOCC-RAMO
            FROM SEGUROS.RAMO_COMPLEMENTAR
            WHERE RAMO_EMISSOR =
            :DCLRAMO-COMPLEMENTAR.RAMOCOMP-RAMO-EMISSOR
            AND DATA_INIVIGENCIA <=
            :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >=
            :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_IOCC_RAMO
											FROM SEGUROS.RAMO_COMPLEMENTAR
											WHERE RAMO_EMISSOR =
											'{this.RAMOCOMP_RAMO_EMISSOR}'
											AND DATA_INIVIGENCIA <=
											'{this.RAMOCOMP_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >=
											'{this.RAMOCOMP_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string RAMOCOMP_DATA_INIVIGENCIA { get; set; }
        public string RAMOCOMP_RAMO_EMISSOR { get; set; }

        public static R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 Execute(R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 r0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1)
        {
            var ths = r0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}