using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0033B
{
    public class R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMBIL,
            CODCLIEN
            INTO :V1BILH-NUMBIL,
            :V1BILH-COD-CLIENTE
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :V1BILH-NUMBIL
            AND SITUACAO = :V1BILH-SITUACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMBIL
							,
											CODCLIEN
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.V1BILH_NUMBIL}'
											AND SITUACAO = '{this.V1BILH_SITUACAO}'";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_COD_CLIENTE { get; set; }
        public string V1BILH_SITUACAO { get; set; }

        public static R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 Execute(R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}