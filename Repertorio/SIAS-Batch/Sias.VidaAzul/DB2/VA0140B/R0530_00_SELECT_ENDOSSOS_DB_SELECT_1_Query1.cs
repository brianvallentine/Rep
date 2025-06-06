using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_TERVIGENCIA
            ,DATA_TERVIGENCIA - 1 MONTHS
            INTO :WHOST-DATAMES2
            ,:WHOST-DATAMES1
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_TERVIGENCIA
											,DATA_TERVIGENCIA - 1 MONTHS
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DATAMES2 { get; set; }
        public string WHOST_DATAMES1 { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATAMES2 = result[i++].Value?.ToString();
            dta.WHOST_DATAMES1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}