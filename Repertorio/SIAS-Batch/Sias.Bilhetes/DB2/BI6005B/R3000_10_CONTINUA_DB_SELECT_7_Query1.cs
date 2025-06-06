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
    public class R3000_10_CONTINUA_DB_SELECT_7_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.PCDESISS
            INTO :V1SURG-PCDESISS
            FROM SEGUROS.V1AGENCIACEF A,
            SEGUROS.V1SUREG B
            WHERE A.COD_AGENCIA = :V1COFE-AGECOBR
            AND B.COD_SUREG = A.COD_ESCNEG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.PCDESISS
											FROM SEGUROS.V1AGENCIACEF A
							,
											SEGUROS.V1SUREG B
											WHERE A.COD_AGENCIA = '{this.V1COFE_AGECOBR}'
											AND B.COD_SUREG = A.COD_ESCNEG
											WITH UR";

            return query;
        }
        public string V1SURG_PCDESISS { get; set; }
        public string V1COFE_AGECOBR { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_7_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_7_Query1 r3000_10_CONTINUA_DB_SELECT_7_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_7_Query1();
            var i = 0;
            dta.V1SURG_PCDESISS = result[i++].Value?.ToString();
            return dta;
        }

    }
}