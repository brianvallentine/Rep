using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0033B
{
    public class R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1 : QueryBasis<R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_DESTINATARIO
            INTO :GEDESTIN-NOME-DESTINATARIO
            FROM SEGUROS.GE_DESTINATARIO
            WHERE COD_DESTINATARIO =
            :GERECADE-COD-DESTINATARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_DESTINATARIO
											FROM SEGUROS.GE_DESTINATARIO
											WHERE COD_DESTINATARIO =
											'{this.GERECADE_COD_DESTINATARIO}'";

            return query;
        }
        public string GEDESTIN_NOME_DESTINATARIO { get; set; }
        public string GERECADE_COD_DESTINATARIO { get; set; }

        public static R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1 Execute(R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1 r4100_00_LE_GEDESTIN_DB_SELECT_1_Query1)
        {
            var ths = r4100_00_LE_GEDESTIN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4100_00_LE_GEDESTIN_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEDESTIN_NOME_DESTINATARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}