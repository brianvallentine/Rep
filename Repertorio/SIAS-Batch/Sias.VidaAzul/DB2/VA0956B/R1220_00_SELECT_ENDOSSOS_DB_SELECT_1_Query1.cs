using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            COD_PRODUTO ,
            DATA_TERVIGENCIA
            INTO :ENDOSSOS-COD-PRODUTO ,
            :ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PRODUTO 
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}