using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3159S
{
    public class R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(DAYS(:WS-DTINIVIG-PROPOSTA) - 1)
            INTO :WS-DATA-AUX
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE(DAYS('{this.WS_DTINIVIG_PROPOSTA}') - 1)
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WS_DATA_AUX { get; set; }
        public string WS_DTINIVIG_PROPOSTA { get; set; }

        public static R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1 Execute(R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1 r1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_AUX = result[i++].Value?.ToString();
            return dta;
        }

    }
}