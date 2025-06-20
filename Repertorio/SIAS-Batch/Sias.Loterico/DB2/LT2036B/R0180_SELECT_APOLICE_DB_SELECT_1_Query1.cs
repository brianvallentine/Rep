using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class R0180_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0180_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG ,
            DTTERVIG
            INTO :V0APO-DTINIVIG ,
            :V0APO-DTTERVIG
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0APO-NUM-APOLICE
            AND NRENDOS = :V0APO-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG 
							,
											DTTERVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0APO_NUM_APOLICE}'
											AND NRENDOS = '{this.V0APO_NUM_ENDOSSO}'";

            return query;
        }
        public string V0APO_DTINIVIG { get; set; }
        public string V0APO_DTTERVIG { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }
        public string V0APO_NUM_ENDOSSO { get; set; }

        public static R0180_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(R0180_SELECT_APOLICE_DB_SELECT_1_Query1 r0180_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0180_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0180_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0180_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0APO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0APO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}