using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R010_LE_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R010_LE_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            CURRENT DATE
            INTO :HOST-DATA-MOVIMENTO-ABERTO-SI,
            :HOST-DATA-CORRENTE
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											CURRENT DATE
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'
											WITH UR";

            return query;
        }
        public string HOST_DATA_MOVIMENTO_ABERTO_SI { get; set; }
        public string HOST_DATA_CORRENTE { get; set; }

        public static R010_LE_SISTEMAS_DB_SELECT_1_Query1 Execute(R010_LE_SISTEMAS_DB_SELECT_1_Query1 r010_LE_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r010_LE_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R010_LE_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R010_LE_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DATA_MOVIMENTO_ABERTO_SI = result[i++].Value?.ToString();
            dta.HOST_DATA_CORRENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}