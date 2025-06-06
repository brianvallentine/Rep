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
    public class R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1 : QueryBasis<R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OCORHIST,
            PRM_ANUAL_IX
            INTO
            :V1COBI-OCORHIST,
            :W1COBI-ANU-IX
            FROM
            SEGUROS.V1COBERINC
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOL
            AND NUM_RISCO = :V1COBP-NUM-RISCO
            AND SUBRIS = :V1COBP-SUBRIS
            AND NRITEM = :V1COBP-NRITEM
            AND TIPOCOBINC = :V1COBP-TIPCOBINC
            AND CODCOBINC = :V1COBP-CODCOBINC
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OCORHIST
							,
											PRM_ANUAL_IX
											FROM
											SEGUROS.V1COBERINC
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOL}'
											AND NUM_RISCO = '{this.V1COBP_NUM_RISCO}'
											AND SUBRIS = '{this.V1COBP_SUBRIS}'
											AND NRITEM = '{this.V1COBP_NRITEM}'
											AND TIPOCOBINC = '{this.V1COBP_TIPCOBINC}'
											AND CODCOBINC = '{this.V1COBP_CODCOBINC}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1COBI_OCORHIST { get; set; }
        public string W1COBI_ANU_IX { get; set; }
        public string V1COBP_NUM_RISCO { get; set; }
        public string V1COBP_TIPCOBINC { get; set; }
        public string V1COBP_CODCOBINC { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V1COBP_SUBRIS { get; set; }
        public string V1COBP_NRITEM { get; set; }

        public static R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1 Execute(R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1 r3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1)
        {
            var ths = r3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COBI_OCORHIST = result[i++].Value?.ToString();
            dta.W1COBI_ANU_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}