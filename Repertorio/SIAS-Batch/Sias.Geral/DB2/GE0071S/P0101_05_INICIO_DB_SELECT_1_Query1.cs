using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0071S
{
    public class P0101_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0101_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_FLUXO_PARAMTRIZADO
            INTO :GE089-IND-FLUXO-PARAMTRIZADO
            FROM SEGUROS.GE_PRODUTO_COMPLEMENTO
            WHERE COD_PRODUTO = :GE089-COD-PRODUTO
            AND SEQ_PRODUTO_VRS = :GE089-SEQ-PRODUTO-VRS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_FLUXO_PARAMTRIZADO
											FROM SEGUROS.GE_PRODUTO_COMPLEMENTO
											WHERE COD_PRODUTO = '{this.GE089_COD_PRODUTO}'
											AND SEQ_PRODUTO_VRS = '{this.GE089_SEQ_PRODUTO_VRS}'
											WITH UR";

            return query;
        }
        public string GE089_IND_FLUXO_PARAMTRIZADO { get; set; }
        public string GE089_SEQ_PRODUTO_VRS { get; set; }
        public string GE089_COD_PRODUTO { get; set; }

        public static P0101_05_INICIO_DB_SELECT_1_Query1 Execute(P0101_05_INICIO_DB_SELECT_1_Query1 p0101_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0101_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0101_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0101_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE089_IND_FLUXO_PARAMTRIZADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}