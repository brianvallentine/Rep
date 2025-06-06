using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R0200_00_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            ,CURRENT TIME
            INTO :V1SIST-DTMOVABE
            ,:V1SIST-HRMOVABE
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'EM'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											,CURRENT TIME
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'EM'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_HRMOVABE { get; set; }

        public static R0200_00_SISTEMAS_DB_SELECT_1_Query1 Execute(R0200_00_SISTEMAS_DB_SELECT_1_Query1 r0200_00_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_HRMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}