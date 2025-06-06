using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1 : QueryBasis<A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT CODLIDER
            INTO :PARM-CODLIDER
            FROM SEGUROS.V1PARAMETRO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODLIDER
											FROM SEGUROS.V1PARAMETRO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PARM_CODLIDER { get; set; }

        public static A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1 Execute(A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1 a1600_LE_V1PARAMETRO_DB_SELECT_1_Query1)
        {
            var ths = a1600_LE_V1PARAMETRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARM_CODLIDER = result[i++].Value?.ToString();
            return dta;
        }

    }
}