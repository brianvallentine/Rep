using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0094B
{
    public class R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            ,COD_OPERACAO
            INTO :RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :RCAPS-NUM-TITULO
            AND SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											,COD_OPERACAO
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.RCAPS_NUM_TITULO}'
											AND SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 Execute(R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 r0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}