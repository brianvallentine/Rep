using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF,
            DATA_NASCIMENTO
            INTO :V0CLIE-CGCCPF,
            :V0CLIE-DTNASC:VIND-DTNASC
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0BILH-CODCLIEN
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0BILH_CODCLIEN}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0CLIE_CGCCPF { get; set; }
        public string V0CLIE_DTNASC { get; set; }
        public string VIND_DTNASC { get; set; }
        public string V0BILH_CODCLIEN { get; set; }

        public static R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1 Execute(R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1 r0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_SELECT_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_CGCCPF = result[i++].Value?.ToString();
            dta.V0CLIE_DTNASC = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.V0CLIE_DTNASC) ? "-1" : "0";
            return dta;
        }

    }
}