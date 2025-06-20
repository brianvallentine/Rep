using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CT0006S
{
    public class R1110_10_SELECT_GE318_DB_SELECT_1_Query1 : QueryBasis<R1110_10_SELECT_GE318_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_UF
            INTO :GE318-COD-UF
            FROM SEGUROS.GE_DNE_LOG_UF
            WHERE COD_CEP = :GE318-COD-CEP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_UF
											FROM SEGUROS.GE_DNE_LOG_UF
											WHERE COD_CEP = '{this.GE318_COD_CEP}'";

            return query;
        }
        public string GE318_COD_UF { get; set; }
        public string GE318_COD_CEP { get; set; }

        public static R1110_10_SELECT_GE318_DB_SELECT_1_Query1 Execute(R1110_10_SELECT_GE318_DB_SELECT_1_Query1 r1110_10_SELECT_GE318_DB_SELECT_1_Query1)
        {
            var ths = r1110_10_SELECT_GE318_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_10_SELECT_GE318_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_10_SELECT_GE318_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE318_COD_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}