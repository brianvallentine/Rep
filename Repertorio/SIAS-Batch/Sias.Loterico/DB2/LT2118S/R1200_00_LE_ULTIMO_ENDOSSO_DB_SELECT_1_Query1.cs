using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2118S
{
    public class R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DATA_INIVIGENCIA)
            INTO :ENDOSSOS-DATA-INIVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            AND SIT_REGISTRO IN ( '0' , '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DATA_INIVIGENCIA)
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											AND SIT_REGISTRO IN ( '0' 
							, '1' )";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1 Execute(R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1 r1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}