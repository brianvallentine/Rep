using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :ENDOSSOS-SIT-REGISTRO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0";

            return query;
        }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1 r1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}