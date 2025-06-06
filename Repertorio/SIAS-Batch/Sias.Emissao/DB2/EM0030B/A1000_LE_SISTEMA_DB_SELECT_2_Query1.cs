using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class A1000_LE_SISTEMA_DB_SELECT_2_Query1 : QueryBasis<A1000_LE_SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :SIST-DTMOVABE-CO
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'CO'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'CO'
											WITH UR";

            return query;
        }
        public string SIST_DTMOVABE_CO { get; set; }

        public static A1000_LE_SISTEMA_DB_SELECT_2_Query1 Execute(A1000_LE_SISTEMA_DB_SELECT_2_Query1 a1000_LE_SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = a1000_LE_SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A1000_LE_SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A1000_LE_SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.SIST_DTMOVABE_CO = result[i++].Value?.ToString();
            return dta;
        }

    }
}