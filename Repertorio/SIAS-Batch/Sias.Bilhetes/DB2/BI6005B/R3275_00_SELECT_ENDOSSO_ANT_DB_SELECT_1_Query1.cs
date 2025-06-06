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
    public class R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 : QueryBasis<R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG,
            DTTERVIG
            INTO :V0ENDO-INIVIG-ANT,
            :V0ENDO-TERVIG-ANT
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1APOL-NUM-APOL
            AND NRENDOS = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
							,
											DTTERVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1APOL_NUM_APOL}'
											AND NRENDOS = 0
											WITH UR";

            return query;
        }
        public string V0ENDO_INIVIG_ANT { get; set; }
        public string V0ENDO_TERVIG_ANT { get; set; }
        public string V1APOL_NUM_APOL { get; set; }

        public static R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 Execute(R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1)
        {
            var ths = r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_INIVIG_ANT = result[i++].Value?.ToString();
            dta.V0ENDO_TERVIG_ANT = result[i++].Value?.ToString();
            return dta;
        }

    }
}