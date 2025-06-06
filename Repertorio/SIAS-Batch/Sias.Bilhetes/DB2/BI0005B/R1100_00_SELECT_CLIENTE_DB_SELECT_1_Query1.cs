using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF
            INTO :V0CLIE-CGCCPF
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0BILH-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0BILH_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string V0CLIE_CGCCPF { get; set; }
        public string V0BILH_CODCLIEN { get; set; }

        public static R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}