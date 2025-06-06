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
    public class R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            , COD_PRODUTO
            INTO :BILHETE-NUM-APOLICE
            ,:BILHETE-COD-PRODUTO:WS-INDICA-NULL
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :WHOST-NUM-BIL-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											, COD_PRODUTO
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.WHOST_NUM_BIL_ANT}'";

            return query;
        }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_COD_PRODUTO { get; set; }
        public string WS_INDICA_NULL { get; set; }
        public string WHOST_NUM_BIL_ANT { get; set; }

        public static R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1 r3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3280_00_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WS_INDICA_NULL = string.IsNullOrWhiteSpace(dta.BILHETE_COD_PRODUTO) ? "-1" : "0";
            return dta;
        }

    }
}