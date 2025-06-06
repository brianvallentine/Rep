using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            INTO :WS-HOST-DTINIVIG-APOL
            ,:WS-HOST-DTTERVIG-APOL
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string WS_HOST_DTINIVIG_APOL { get; set; }
        public string WS_HOST_DTTERVIG_APOL { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }

        public static R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_DTINIVIG_APOL = result[i++].Value?.ToString();
            dta.WS_HOST_DTTERVIG_APOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}