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
    public class R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            ,VAL_TITULO
            INTO :MOVIMCOB-SIT-REGISTRO
            ,:MOVIMCOB-VAL-TITULO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE NUM_TITULO = :HISCONPA-NUM-TITULO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											,VAL_TITULO
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE NUM_TITULO = '{this.HISCONPA_NUM_TITULO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }

        public static R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 r0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}