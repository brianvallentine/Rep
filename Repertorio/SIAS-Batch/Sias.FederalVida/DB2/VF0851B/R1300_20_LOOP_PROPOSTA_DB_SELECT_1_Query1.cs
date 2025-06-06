using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :V0FONT-PROPAUTOM
            FROM SEGUROS.V0FONTE
            WHERE FONTE = :V0PROP-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V0FONTE
											WHERE FONTE = '{this.V0PROP_FONTE}'";

            return query;
        }
        public string V0FONT_PROPAUTOM { get; set; }
        public string V0PROP_FONTE { get; set; }

        public static R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1 Execute(R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1 r1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_20_LOOP_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FONT_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}