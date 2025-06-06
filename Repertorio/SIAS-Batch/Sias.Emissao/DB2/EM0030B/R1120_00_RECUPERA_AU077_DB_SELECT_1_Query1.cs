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
    public class R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1 : QueryBasis<R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(VLR_PREMIO_LIQUIDO), 0),
            VALUE(SUM(VLR_CUSTO), 0),
            VALUE(SUM(VLR_IOF), 0),
            VALUE(SUM(VLR_PREMIO_TOTAL), 0)
            INTO :AU077-VLR-PREMIO-LIQUIDO,
            :AU077-VLR-CUSTO ,
            :AU077-VLR-IOF ,
            :AU077-VLR-PREMIO-TOTAL
            FROM
            SEGUROS.AU_PROD_COBERTURA
            WHERE
            COD_PRODUTO = :AU077-COD-PRODUTO
            AND DTA_INI_VIGENCIA <= :AU077-DTA-INI-VIGENCIA
            AND DTA_FIM_VIGENCIA >= :AU077-DTA-INI-VIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(VLR_PREMIO_LIQUIDO)
							, 0)
							,
											VALUE(SUM(VLR_CUSTO)
							, 0)
							,
											VALUE(SUM(VLR_IOF)
							, 0)
							,
											VALUE(SUM(VLR_PREMIO_TOTAL)
							, 0)
											FROM
											SEGUROS.AU_PROD_COBERTURA
											WHERE
											COD_PRODUTO = '{this.AU077_COD_PRODUTO}'
											AND DTA_INI_VIGENCIA <= '{this.AU077_DTA_INI_VIGENCIA}'
											AND DTA_FIM_VIGENCIA >= '{this.AU077_DTA_INI_VIGENCIA}'";

            return query;
        }
        public string AU077_VLR_PREMIO_LIQUIDO { get; set; }
        public string AU077_VLR_CUSTO { get; set; }
        public string AU077_VLR_IOF { get; set; }
        public string AU077_VLR_PREMIO_TOTAL { get; set; }
        public string AU077_DTA_INI_VIGENCIA { get; set; }
        public string AU077_COD_PRODUTO { get; set; }

        public static R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1 Execute(R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1 r1120_00_RECUPERA_AU077_DB_SELECT_1_Query1)
        {
            var ths = r1120_00_RECUPERA_AU077_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU077_VLR_PREMIO_LIQUIDO = result[i++].Value?.ToString();
            dta.AU077_VLR_CUSTO = result[i++].Value?.ToString();
            dta.AU077_VLR_IOF = result[i++].Value?.ToString();
            dta.AU077_VLR_PREMIO_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}