using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6016B
{
    public class R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA
            INTO :ENDOSSOS-DATA-INIVIGENCIA ,
            :ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA 
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}