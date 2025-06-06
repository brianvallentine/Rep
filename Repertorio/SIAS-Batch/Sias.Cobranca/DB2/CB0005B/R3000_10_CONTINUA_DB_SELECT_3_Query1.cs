using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3000_10_CONTINUA_DB_SELECT_3_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            INTO :V1MCEF-COD-FONTE
            FROM SEGUROS.V1MALHACEF
            WHERE COD_SUREG = :V1ACEF-CODESCNEG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											FROM SEGUROS.V1MALHACEF
											WHERE COD_SUREG = '{this.V1ACEF_CODESCNEG}'";

            return query;
        }
        public string V1MCEF_COD_FONTE { get; set; }
        public string V1ACEF_CODESCNEG { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_3_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_3_Query1 r3000_10_CONTINUA_DB_SELECT_3_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V1MCEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}