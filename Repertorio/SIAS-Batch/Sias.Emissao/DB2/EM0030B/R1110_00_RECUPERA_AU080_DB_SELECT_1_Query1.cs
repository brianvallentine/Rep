using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1 : QueryBasis<R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_TOTAL_ENCARGO
            INTO :AU080-PCT-TOTAL-ENCARGO
            FROM SEGUROS.AU_PARAM_PLANO_PRDTO
            WHERE COD_PRODUTO = :AU080-COD-PRODUTO
            AND IND_FORMA_PGTO = :AU080-IND-FORMA-PGTO
            AND QTD_PARCELA = :AU080-QTD-PARCELA
            AND DTA_INI_VIGENCIA
            <= :AU080-DTA-INI-VIGENCIA
            AND DTA_FIM_VIGENCIA
            >= :AU080-DTA-INI-VIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_TOTAL_ENCARGO
											FROM SEGUROS.AU_PARAM_PLANO_PRDTO
											WHERE COD_PRODUTO = '{this.AU080_COD_PRODUTO}'
											AND IND_FORMA_PGTO = '{this.AU080_IND_FORMA_PGTO}'
											AND QTD_PARCELA = '{this.AU080_QTD_PARCELA}'
											AND DTA_INI_VIGENCIA
											<= '{this.AU080_DTA_INI_VIGENCIA}'
											AND DTA_FIM_VIGENCIA
											>= '{this.AU080_DTA_INI_VIGENCIA}'
											WITH UR";

            return query;
        }
        public string AU080_PCT_TOTAL_ENCARGO { get; set; }
        public string AU080_DTA_INI_VIGENCIA { get; set; }
        public string AU080_IND_FORMA_PGTO { get; set; }
        public string AU080_COD_PRODUTO { get; set; }
        public string AU080_QTD_PARCELA { get; set; }

        public static R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1 Execute(R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1 r1110_00_RECUPERA_AU080_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_RECUPERA_AU080_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU080_PCT_TOTAL_ENCARGO = result[i++].Value?.ToString();
            return dta;
        }

    }
}