using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1 : QueryBasis<R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :V1FONT-PROPAUTOM
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V0BILH-FONTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V0BILH_FONTE}'";

            return query;
        }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0BILH_FONTE { get; set; }

        public static R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1 Execute(R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1 r3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1)
        {
            var ths = r3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3001_00_LER_PROPAUTOM_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONT_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}