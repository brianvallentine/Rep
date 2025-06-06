using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            INTO :WS-DATA-MOV-ABERTO-CO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'CO'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'CO'
											WITH UR";

            return query;
        }
        public string WS_DATA_MOV_ABERTO_CO { get; set; }

        public static R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1 r0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_MOV_ABERTO_CO = result[i++].Value?.ToString();
            return dta;
        }

    }
}