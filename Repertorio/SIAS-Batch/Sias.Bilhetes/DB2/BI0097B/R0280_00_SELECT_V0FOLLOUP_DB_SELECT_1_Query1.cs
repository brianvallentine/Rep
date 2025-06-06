using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0097B
{
    public class R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1 : QueryBasis<R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :FOLLOUP-NUM-APOLICE
            FROM SEGUROS.FOLLOW_UP
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM SEGUROS.FOLLOW_UP
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }

        public static R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1 Execute(R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1 r0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1)
        {
            var ths = r0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1();
            var i = 0;
            dta.FOLLOUP_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}