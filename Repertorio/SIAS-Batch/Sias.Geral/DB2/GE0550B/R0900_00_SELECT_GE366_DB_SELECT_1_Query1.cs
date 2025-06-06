using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0900_00_SELECT_GE366_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_GE366_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_MOVTO),0)
            INTO :GE366-NUM-OCORR-MOVTO
            FROM SEGUROS.GE_MOVIMENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_MOVTO)
							,0)
											FROM SEGUROS.GE_MOVIMENTO";

            return query;
        }
        public string GE366_NUM_OCORR_MOVTO { get; set; }

        public static R0900_00_SELECT_GE366_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_GE366_DB_SELECT_1_Query1 r0900_00_SELECT_GE366_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_GE366_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_GE366_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_GE366_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE366_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}