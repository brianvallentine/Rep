using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1 : QueryBasis<R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OCORHIST
            INTO
            :V1APIN-OCORHIST
            FROM
            SEGUROS.V1APOITENSINC
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOL
            AND NUM_RISCO = :V1PRIN-NUM-RISCO
            AND SUBRIS = :V1PRIN-SUBRIS
            AND NRITEM = :V1PRIN-NRITEM
            AND TIPCOND = :V1PRIN-TIPCOND
            AND TIPO_TAXA = :V1PRIN-TIPO-TAXA
            AND CODCOBINC = :V1PRIN-CODCOBINC
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OCORHIST
											FROM
											SEGUROS.V1APOITENSINC
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOL}'
											AND NUM_RISCO = '{this.V1PRIN_NUM_RISCO}'
											AND SUBRIS = '{this.V1PRIN_SUBRIS}'
											AND NRITEM = '{this.V1PRIN_NRITEM}'
											AND TIPCOND = '{this.V1PRIN_TIPCOND}'
											AND TIPO_TAXA = '{this.V1PRIN_TIPO_TAXA}'
											AND CODCOBINC = '{this.V1PRIN_CODCOBINC}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1APIN_OCORHIST { get; set; }
        public string V1PRIN_NUM_RISCO { get; set; }
        public string V1PRIN_TIPO_TAXA { get; set; }
        public string V1PRIN_CODCOBINC { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V1PRIN_TIPCOND { get; set; }
        public string V1PRIN_SUBRIS { get; set; }
        public string V1PRIN_NRITEM { get; set; }

        public static R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1 Execute(R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1 r2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1)
        {
            var ths = r2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APIN_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}