using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0836B
{
    public class Execute_DB_SELECT_1_Query1 : QueryBasis<Execute_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :V0RELATORIOS-DATA-REFERENCIA
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND CODRELAT = 'SI0836B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V0RELATORIOS
											WHERE IDSISTEM = 'SI'
											AND CODRELAT = 'SI0836B'";

            return query;
        }
        public string V0RELATORIOS_DATA_REFERENCIA { get; set; }

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
            dta.V0RELATORIOS_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}