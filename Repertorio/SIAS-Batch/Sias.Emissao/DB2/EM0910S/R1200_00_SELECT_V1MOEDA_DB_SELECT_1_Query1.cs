using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VLCRUZAD
            INTO :WHOST-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :WHOST-COD-MOEDA
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.WHOST_COD_MOEDA}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'";

            return query;
        }
        public string WHOST_VLCRUZAD { get; set; }
        public string WHOST_COD_MOEDA { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}