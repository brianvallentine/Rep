using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0007B
{
    public class R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(CHQINT)
            INTO :WHOST-NUM-CHQINT:VIND-CHQINT
            FROM SEGUROS.V1CHEQUES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(CHQINT)
											FROM SEGUROS.V1CHEQUES";

            return query;
        }
        public string WHOST_NUM_CHQINT { get; set; }
        public string VIND_CHQINT { get; set; }

        public static R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1 r0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NUM_CHQINT = result[i++].Value?.ToString();
            dta.VIND_CHQINT = string.IsNullOrWhiteSpace(dta.WHOST_NUM_CHQINT) ? "-1" : "0";
            return dta;
        }

    }
}