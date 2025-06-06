using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD
            INTO :V1MOED-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :WHOST-COD-MOEDA
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.WHOST_COD_MOEDA}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1MOED_VLCRUZAD { get; set; }
        public string WHOST_COD_MOEDA { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 r2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}