using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(PRM_TARIFARIO_IX)
            INTO :W1COBP-PRM-TAR-VR:VIND-PRMTARIFA
            FROM SEGUROS.V1COBERPROP
            WHERE FONTE = :V1PROP-FONTE
            AND NRPROPOS = :V1PROP-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(PRM_TARIFARIO_IX)
											FROM SEGUROS.V1COBERPROP
											WHERE FONTE = '{this.V1PROP_FONTE}'
											AND NRPROPOS = '{this.V1PROP_NRPROPOS}'";

            return query;
        }
        public string W1COBP_PRM_TAR_VR { get; set; }
        public string VIND_PRMTARIFA { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 r2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.W1COBP_PRM_TAR_VR = result[i++].Value?.ToString();
            dta.VIND_PRMTARIFA = string.IsNullOrWhiteSpace(dta.W1COBP_PRM_TAR_VR) ? "-1" : "0";
            return dta;
        }

    }
}