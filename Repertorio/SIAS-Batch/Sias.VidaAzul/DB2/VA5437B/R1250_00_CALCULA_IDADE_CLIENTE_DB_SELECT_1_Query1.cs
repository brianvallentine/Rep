using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT YEAR(DATE(:WS-DATA-OPER-CORR-MONET) -
            DATE(VALUE(DATA_NASCIMENTO, CURRENT_DATE)))
            INTO :WS-IDADE
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT YEAR(DATE('{this.WS_DATA_OPER_CORR_MONET}') -
											DATE(VALUE(DATA_NASCIMENTO
							, CURRENT_DATE)))
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.SEGURVGA_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string WS_IDADE { get; set; }
        public string WS_DATA_OPER_CORR_MONET { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1 Execute(R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1 r1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_IDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}