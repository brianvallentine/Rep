using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0006S
{
    public class LOOP_CALEND_DB_SELECT_2_Query1 : QueryBasis<LOOP_CALEND_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_FERIADO
            INTO :FERIADOS-DATA-FERIADO
            FROM SEGUROS.FERIADOS
            WHERE DATA_FERIADO = :WHOST-DTTRAB
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_FERIADO
											FROM SEGUROS.FERIADOS
											WHERE DATA_FERIADO = '{this.WHOST_DTTRAB}'";

            return query;
        }
        public string FERIADOS_DATA_FERIADO { get; set; }
        public string WHOST_DTTRAB { get; set; }

        public static LOOP_CALEND_DB_SELECT_2_Query1 Execute(LOOP_CALEND_DB_SELECT_2_Query1 lOOP_CALEND_DB_SELECT_2_Query1)
        {
            var ths = lOOP_CALEND_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override LOOP_CALEND_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LOOP_CALEND_DB_SELECT_2_Query1();
            var i = 0;
            dta.FERIADOS_DATA_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}