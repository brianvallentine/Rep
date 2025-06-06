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
    public class R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_PRODUTO
            INTO :LK-GE510-NUM-APOLICE,
            :WS-COD-PRODUTO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :LK-GE510-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_PRODUTO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.LK_GE510_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string LK_GE510_NUM_APOLICE { get; set; }
        public string WS_COD_PRODUTO { get; set; }
        public string LK_GE510_NUM_CERTIFICADO { get; set; }

        public static R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1 Execute(R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1 r0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LK_GE510_NUM_APOLICE = result[i++].Value?.ToString();
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}