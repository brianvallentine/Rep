using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:DCLCLIENTES.DATA-NASCIMENTO)
            INTO :WHOST-DATA-NASCIMENTO
            FROM SYSIBM.SYSDUMMY1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.DATA_NASCIMENTO}')
											FROM SYSIBM.SYSDUMMY1
											WITH UR";

            return query;
        }
        public string WHOST_DATA_NASCIMENTO { get; set; }
        public string DATA_NASCIMENTO { get; set; }

        public static R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1 Execute(R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1 r4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}