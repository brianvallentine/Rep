using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1 : QueryBasis<R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_FERIADO
            INTO :FERIADOS-DATA-FERIADO
            FROM SEGUROS.FERIADOS
            WHERE DATA_FERIADO = :WHOST-DT-CALENDARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_FERIADO
											FROM SEGUROS.FERIADOS
											WHERE DATA_FERIADO = '{this.WHOST_DT_CALENDARIO}'";

            return query;
        }
        public string FERIADOS_DATA_FERIADO { get; set; }
        public string WHOST_DT_CALENDARIO { get; set; }

        public static R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1 Execute(R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1 r0310_00_SELECT_FERIADO_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_SELECT_FERIADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FERIADOS_DATA_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}