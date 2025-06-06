using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3000_10_CONTINUA_DB_SELECT_6_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODANGAR
            INTO :V1NOUT-CODANGAR
            FROM SEGUROS.V1NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODANGAR
											FROM SEGUROS.V1NUMERO_OUTROS";

            return query;
        }
        public string V1NOUT_CODANGAR { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_6_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_6_Query1 r3000_10_CONTINUA_DB_SELECT_6_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_6_Query1();
            var i = 0;
            dta.V1NOUT_CODANGAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}