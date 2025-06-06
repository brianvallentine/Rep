using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 : QueryBasis<R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(A.PRM_TARIFARIO_VAR)
            INTO :W1COBP-PRM-TAR-VR:VIND-PRMTARIFA
            FROM SEGUROS.V1AUTOCOBERPROP A
            WHERE A.FONTE = :WHOST-FONTE
            AND A.NRPROPOS = :WHOST-NRPROPOS
            AND A.NRITEM =
            ( SELECT MAX(B.NRITEM)
            FROM SEGUROS.V1AUTOCOBERPROP B
            WHERE A.FONTE = B.FONTE
            AND A.NRPROPOS = B.NRPROPOS )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(A.PRM_TARIFARIO_VAR)
											FROM SEGUROS.V1AUTOCOBERPROP A
											WHERE A.FONTE = '{this.WHOST_FONTE}'
											AND A.NRPROPOS = '{this.WHOST_NRPROPOS}'
											AND A.NRITEM =
											( SELECT MAX(B.NRITEM)
											FROM SEGUROS.V1AUTOCOBERPROP B
											WHERE A.FONTE = B.FONTE
											AND A.NRPROPOS = B.NRPROPOS )";

            return query;
        }
        public string W1COBP_PRM_TAR_VR { get; set; }
        public string VIND_PRMTARIFA { get; set; }
        public string WHOST_NRPROPOS { get; set; }
        public string WHOST_FONTE { get; set; }

        public static R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 Execute(R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 r4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1)
        {
            var ths = r4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.W1COBP_PRM_TAR_VR = result[i++].Value?.ToString();
            dta.VIND_PRMTARIFA = string.IsNullOrWhiteSpace(dta.W1COBP_PRM_TAR_VR) ? "-1" : "0";
            return dta;
        }

    }
}