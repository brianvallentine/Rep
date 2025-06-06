using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class Execute_DB_SELECT_1_Query1 : QueryBasis<Execute_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            INTO :WS-SISTEMA-DTMOVABE
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VG'";

            return query;
        }
        public string WS_SISTEMA_DTMOVABE { get; set; }

        public static Execute_DB_SELECT_1_Query1 Execute(Execute_DB_SELECT_1_Query1 execute_DB_SELECT_1_Query1)
        {
            var ths = execute_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}