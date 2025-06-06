using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0016B
{
    public class R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1 : QueryBasis<R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CHAR(CURRENT TIMESTAMP)
            INTO :WS-CURRENT-TIMESTAMP
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CHAR(CURRENT TIMESTAMP)
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WS_CURRENT_TIMESTAMP { get; set; }

        public static R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1 Execute(R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1 r0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1)
        {
            var ths = r0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CURRENT_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}