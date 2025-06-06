using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6000_10_CANCEL_DB_SELECT_6_Query1 : QueryBasis<R6000_10_CANCEL_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :V0FONT-PROPAUTOM
            FROM SEGUROS.V0FONTE
            WHERE FONTE = :V0PROP-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V0FONTE
											WHERE FONTE = '{this.V0PROP_FONTE}'
											WITH UR";

            return query;
        }
        public string V0FONT_PROPAUTOM { get; set; }
        public string V0PROP_FONTE { get; set; }

        public static R6000_10_CANCEL_DB_SELECT_6_Query1 Execute(R6000_10_CANCEL_DB_SELECT_6_Query1 r6000_10_CANCEL_DB_SELECT_6_Query1)
        {
            var ths = r6000_10_CANCEL_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_10_CANCEL_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_10_CANCEL_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0FONT_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}