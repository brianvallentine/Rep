using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ENDOSSO
            INTO :WHOST-NUM-ENDOSSO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE =
            :ENDOSSOS-NUM-APOLICE
            AND COD_SUBGRUPO =
            :ENDOSSOS-COD-SUBGRUPO
            AND DATA_INIVIGENCIA <=
            :PARCEVID-DATA-VENCIMENTO-1M
            AND DATA_TERVIGENCIA >=
            :PARCEVID-DATA-VENCIMENTO-1M
            AND NUM_ENDOSSO <> 0
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ENDOSSO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE =
											'{this.ENDOSSOS_NUM_APOLICE}'
											AND COD_SUBGRUPO =
											'{this.ENDOSSOS_COD_SUBGRUPO}'
											AND DATA_INIVIGENCIA <=
											'{this.PARCEVID_DATA_VENCIMENTO_1M}'
											AND DATA_TERVIGENCIA >=
											'{this.PARCEVID_DATA_VENCIMENTO_1M}'
											AND NUM_ENDOSSO <> 0
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_NUM_ENDOSSO { get; set; }
        public string PARCEVID_DATA_VENCIMENTO_1M { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }

        public static R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NUM_ENDOSSO = result[i++].Value?.ToString();
            return dta;
        }

    }
}