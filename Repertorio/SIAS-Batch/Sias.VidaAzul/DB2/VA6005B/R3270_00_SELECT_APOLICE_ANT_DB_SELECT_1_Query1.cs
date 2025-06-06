using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 : QueryBasis<R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_APOLICE)
            INTO :V1APOL-NUM-APOL
            :WS-INDICA-NULL
            FROM SEGUROS.V1ENDOSSO
            WHERE NUMBIL = :V1APOL-NUMBIL
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_APOLICE)
											FROM SEGUROS.V1ENDOSSO
											WHERE NUMBIL = '{this.V1APOL_NUMBIL}'
											AND NRENDOS = 0";

            return query;
        }
        public string V1APOL_NUM_APOL { get; set; }
        public string WS_INDICA_NULL { get; set; }
        public string V1APOL_NUMBIL { get; set; }

        public static R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 Execute(R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1)
        {
            var ths = r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_NUM_APOL = result[i++].Value?.ToString();
            dta.WS_INDICA_NULL = string.IsNullOrWhiteSpace(dta.V1APOL_NUM_APOL) ? "-1" : "0";
            return dta;
        }

    }
}