using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0710S
{
    public class Execute_DB_SELECT_1_Query1 : QueryBasis<Execute_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT DTMOVABE
            INTO :SISTEMA-DTMOVABE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }

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
            dta.SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}