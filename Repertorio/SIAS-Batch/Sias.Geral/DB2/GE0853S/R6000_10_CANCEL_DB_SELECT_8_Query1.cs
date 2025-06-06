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
    public class R6000_10_CANCEL_DB_SELECT_8_Query1 : QueryBasis<R6000_10_CANCEL_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :V0FATC-DTREF
            FROM SEGUROS.V0FATURCONT
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = 0
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V0FATURCONT
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = 0
											WITH UR";

            return query;
        }
        public string V0FATC_DTREF { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R6000_10_CANCEL_DB_SELECT_8_Query1 Execute(R6000_10_CANCEL_DB_SELECT_8_Query1 r6000_10_CANCEL_DB_SELECT_8_Query1)
        {
            var ths = r6000_10_CANCEL_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_10_CANCEL_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_10_CANCEL_DB_SELECT_8_Query1();
            var i = 0;
            dta.V0FATC_DTREF = result[i++].Value?.ToString();
            return dta;
        }

    }
}