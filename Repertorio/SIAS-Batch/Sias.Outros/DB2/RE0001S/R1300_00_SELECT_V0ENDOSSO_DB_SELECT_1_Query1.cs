using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0001S
{
    public class R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NRENDOS,
            CODPRODU,
            CODSUBES,
            DTEMIS,
            DTINIVIG,
            DTTERVIG,
            TIPO_ENDOSSO
            INTO :V0ENDS-NUM-APOL,
            :V0ENDS-NRENDOS,
            :V0ENDS-CODPRODU,
            :V0ENDS-CODSUBES,
            :V0ENDS-DTEMIS,
            :V0ENDS-DTINIVIG,
            :V0ENDS-DTTERVIG,
            :V0ENDS-TIP-ENDS
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NRENDOS
							,
											CODPRODU
							,
											CODSUBES
							,
											DTEMIS
							,
											DTINIVIG
							,
											DTTERVIG
							,
											TIPO_ENDOSSO
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'
											WITH UR";

            return query;
        }
        public string V0ENDS_NUM_APOL { get; set; }
        public string V0ENDS_NRENDOS { get; set; }
        public string V0ENDS_CODPRODU { get; set; }
        public string V0ENDS_CODSUBES { get; set; }
        public string V0ENDS_DTEMIS { get; set; }
        public string V0ENDS_DTINIVIG { get; set; }
        public string V0ENDS_DTTERVIG { get; set; }
        public string V0ENDS_TIP_ENDS { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }

        public static R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDS_NUM_APOL = result[i++].Value?.ToString();
            dta.V0ENDS_NRENDOS = result[i++].Value?.ToString();
            dta.V0ENDS_CODPRODU = result[i++].Value?.ToString();
            dta.V0ENDS_CODSUBES = result[i++].Value?.ToString();
            dta.V0ENDS_DTEMIS = result[i++].Value?.ToString();
            dta.V0ENDS_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDS_DTTERVIG = result[i++].Value?.ToString();
            dta.V0ENDS_TIP_ENDS = result[i++].Value?.ToString();
            return dta;
        }

    }
}