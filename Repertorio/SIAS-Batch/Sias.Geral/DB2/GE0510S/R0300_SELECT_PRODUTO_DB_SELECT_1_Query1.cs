using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0510S
{
    public class R0300_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0300_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :WS-COD-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :LK-GE510-NUM-APOLICE
            AND COD_SUBGRUPO = :LK-GE510-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.LK_GE510_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.LK_GE510_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string WS_COD_PRODUTO { get; set; }
        public string LK_GE510_COD_SUBGRUPO { get; set; }
        public string LK_GE510_NUM_APOLICE { get; set; }

        public static R0300_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R0300_SELECT_PRODUTO_DB_SELECT_1_Query1 r0300_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0300_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}