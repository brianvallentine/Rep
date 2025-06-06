using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1 : QueryBasis<R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTREF),
            MAX(DTREF) + 1 MONTH
            INTO :V1SIST-DTMOVABEANT:V1SIST-DTMOVABEANT-I,
            :V1SIST-DTMOVABE:V1SIST-DTMOVABE-I
            FROM SEGUROS.V0HISTREPSAF
            WHERE CODCLIEN = :V0RSAF-CODCLIEN-SUB
            AND CODOPER = 1800
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTREF)
							,
											MAX(DTREF) + 1 MONTH
											FROM SEGUROS.V0HISTREPSAF
											WHERE CODCLIEN = '{this.V0RSAF_CODCLIEN_SUB}'
											AND CODOPER = 1800";

            return query;
        }
        public string V1SIST_DTMOVABEANT { get; set; }
        public string V1SIST_DTMOVABEANT_I { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTMOVABE_I { get; set; }
        public string V0RSAF_CODCLIEN_SUB { get; set; }

        public static R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1 Execute(R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1 r0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABEANT = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABEANT_I = string.IsNullOrWhiteSpace(dta.V1SIST_DTMOVABEANT) ? "-1" : "0";
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE_I = string.IsNullOrWhiteSpace(dta.V1SIST_DTMOVABE) ? "-1" : "0";
            return dta;
        }

    }
}