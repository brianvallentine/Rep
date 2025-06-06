using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1 : QueryBasis<R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CADASTRAMENTO
            INTO :RCAPS-DATA-CADASTRAMENTO
            FROM SEGUROS.RCAPS
            WHERE NUM_RCAP = :RCAPS-NUM-RCAP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CADASTRAMENTO
											FROM SEGUROS.RCAPS
											WHERE NUM_RCAP = '{this.RCAPS_NUM_RCAP}'";

            return query;
        }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1 Execute(R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1 r3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}