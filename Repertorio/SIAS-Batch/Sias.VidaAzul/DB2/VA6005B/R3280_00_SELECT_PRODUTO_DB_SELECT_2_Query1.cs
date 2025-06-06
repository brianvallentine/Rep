using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1 : QueryBasis<R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :BILHETE-COD-PRODUTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0";

            return query;
        }
        public string BILHETE_COD_PRODUTO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1 Execute(R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1 r3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1)
        {
            var ths = r3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3280_00_SELECT_PRODUTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.BILHETE_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}