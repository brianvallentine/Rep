using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1 : QueryBasis<R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(FIM_PRAZO)
            INTO :W-HOST-FIM-PRAZO
            FROM SEGUROS.PRAZO_SEGURO
            WHERE COD_TABELA = 5
            AND PCT_PRM_ANUAL <= :W-PERCENTUAL-PAGO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(FIM_PRAZO)
											FROM SEGUROS.PRAZO_SEGURO
											WHERE COD_TABELA = 5
											AND PCT_PRM_ANUAL <= '{this.W_PERCENTUAL_PAGO}'
											WITH UR";

            return query;
        }
        public string W_HOST_FIM_PRAZO { get; set; }
        public string W_PERCENTUAL_PAGO { get; set; }

        public static R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1 Execute(R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1 r710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1)
        {
            var ths = r710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1();
            var i = 0;
            dta.W_HOST_FIM_PRAZO = result[i++].Value?.ToString();
            return dta;
        }

    }
}