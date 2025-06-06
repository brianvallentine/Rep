using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_DEVOLUCAO
            INTO :DEVOLVID-COD-DEVOLUCAO
            FROM SEGUROS.DEVOLUCAO_VIDAZUL
            WHERE COD_DEVOLUCAO = :DEVOLVID-COD-DEVOLUCAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_DEVOLUCAO
											FROM SEGUROS.DEVOLUCAO_VIDAZUL
											WHERE COD_DEVOLUCAO = '{this.DEVOLVID_COD_DEVOLUCAO}'";

            return query;
        }
        public string DEVOLVID_COD_DEVOLUCAO { get; set; }

        public static R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1 r0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.DEVOLVID_COD_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}