using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000B
{
    public class R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VLCRUZAD
            INTO :V1MOED-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :W1MOED-CODUNIMO
            AND DTINIVIG <= :W1MOED-DTINIVIG
            AND DTTERVIG >= :W1MOED-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.W1MOED_CODUNIMO}'
											AND DTINIVIG <= '{this.W1MOED_DTINIVIG}'
											AND DTTERVIG >= '{this.W1MOED_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1MOED_VLCRUZAD { get; set; }
        public string W1MOED_CODUNIMO { get; set; }
        public string W1MOED_DTINIVIG { get; set; }

        public static R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 r0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}