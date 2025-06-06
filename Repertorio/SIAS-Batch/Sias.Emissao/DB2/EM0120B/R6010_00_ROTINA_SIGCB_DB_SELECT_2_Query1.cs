using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1 : QueryBasis<R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(DAYS(:WS-DT-VENCIM) - 20)
            INTO :WS-DT-VENCIM-20DIAS
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE(DAYS('{this.WS_DT_VENCIM}') - 20)
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WS_DT_VENCIM_20DIAS { get; set; }
        public string WS_DT_VENCIM { get; set; }

        public static R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1 Execute(R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1 r6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1)
        {
            var ths = r6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6010_00_ROTINA_SIGCB_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_DT_VENCIM_20DIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}