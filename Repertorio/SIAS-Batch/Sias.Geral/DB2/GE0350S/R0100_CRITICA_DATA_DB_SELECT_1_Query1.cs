using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R0100_CRITICA_DATA_DB_SELECT_1_Query1 : QueryBasis<R0100_CRITICA_DATA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WS-DATA-AUX) + 1 DAY
            INTO :WS-DATA-AUX
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WS_DATA_AUX}') + 1 DAY
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string WS_DATA_AUX { get; set; }

        public static R0100_CRITICA_DATA_DB_SELECT_1_Query1 Execute(R0100_CRITICA_DATA_DB_SELECT_1_Query1 r0100_CRITICA_DATA_DB_SELECT_1_Query1)
        {
            var ths = r0100_CRITICA_DATA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_CRITICA_DATA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_CRITICA_DATA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_AUX = result[i++].Value?.ToString();
            return dta;
        }

    }
}