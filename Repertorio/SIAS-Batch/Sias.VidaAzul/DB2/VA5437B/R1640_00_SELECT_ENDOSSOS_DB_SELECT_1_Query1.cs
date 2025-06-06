using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            DATA_TERVIGENCIA - 1 YEAR
            INTO :ENDOSSOS-DATA-INIVIGENCIA,
            :ENDOSSOS-DATA-TERVIGENCIA,
            :ENDOSSOS-DATA-TERVIGENCIA-1
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
							,
											DATA_TERVIGENCIA - 1 YEAR
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA_1 { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA_1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}