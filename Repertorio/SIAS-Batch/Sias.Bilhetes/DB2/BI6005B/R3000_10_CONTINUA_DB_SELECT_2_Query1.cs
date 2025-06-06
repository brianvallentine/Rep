using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_10_CONTINUA_DB_SELECT_2_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESCNEG
            INTO :V1ACEF-CODESCNEG
            FROM SEGUROS.V1AGENCIACEF
            WHERE COD_AGENCIA = :V1COFE-AGECOBR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESCNEG
											FROM SEGUROS.V1AGENCIACEF
											WHERE COD_AGENCIA = '{this.V1COFE_AGECOBR}'
											WITH UR";

            return query;
        }
        public string V1ACEF_CODESCNEG { get; set; }
        public string V1COFE_AGECOBR { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_2_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_2_Query1 r3000_10_CONTINUA_DB_SELECT_2_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1ACEF_CODESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}