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
    public class R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
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
            INTO :V0ENDO-NUM-APOL,
            :V0ENDO-NRENDOS,
            :V0ENDO-CODPRODU,
            :V0ENDO-CODSUBES,
            :V0ENDO-DTEMIS,
            :V0ENDO-DTINIVIG,
            :V0ENDO-DTTERVIG,
            :V0ENDO-TIP-ENDO
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = 0
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
											AND NRENDOS = 0
											WITH UR";

            return query;
        }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0ENDO_CODPRODU { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V0ENDO_DTEMIS { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0ENDO_TIP_ENDO { get; set; }
        public string WHOST_NUM_APOL { get; set; }

        public static R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_NUM_APOL = result[i++].Value?.ToString();
            dta.V0ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.V0ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.V0ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V0ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V0ENDO_TIP_ENDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}