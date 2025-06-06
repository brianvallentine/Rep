using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF ,
            DATA_NASCIMENTO
            INTO :CLIENTES-CGCCPF ,
            :CLIENTES-DATA-NASCIMENTO:WDT-NASC-NLL
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF 
							,
											DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string WDT_NASC_NLL { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WDT_NASC_NLL = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}