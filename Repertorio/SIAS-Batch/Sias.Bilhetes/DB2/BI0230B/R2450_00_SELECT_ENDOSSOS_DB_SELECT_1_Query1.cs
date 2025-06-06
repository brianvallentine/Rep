using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0230B
{
    public class R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            INTO :ENDOSSOS-DATA-INIVIGENCIA
            ,:ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :CBCONDEV-NUM-APOLICE
            AND NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.CBCONDEV_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.CBCONDEV_NUM_ENDOSSO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }

        public static R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}