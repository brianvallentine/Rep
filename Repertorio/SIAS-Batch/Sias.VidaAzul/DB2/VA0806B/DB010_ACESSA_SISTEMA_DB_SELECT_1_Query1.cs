using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0806B
{
    public class DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V0SIST-DTMOVABE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }

        public static DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1 Execute(DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1 dB010_ACESSA_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = dB010_ACESSA_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}