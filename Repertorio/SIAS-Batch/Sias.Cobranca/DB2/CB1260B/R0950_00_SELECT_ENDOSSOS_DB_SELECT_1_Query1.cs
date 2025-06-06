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
    public class R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_ENDOSSO
            INTO :WS-HOST-TIPO-ENDOSSO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_ENDOSSO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string WS_HOST_TIPO_ENDOSSO { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_TIPO_ENDOSSO = result[i++].Value?.ToString();
            return dta;
        }

    }
}