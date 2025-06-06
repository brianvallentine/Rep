using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1139B
{
    public class R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 : QueryBasis<R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0AVISOS_SALDOS
				SET SDOATU =
				(SDOATU -  '{this.V1RCAC_VLRCAP}')
				WHERE  BCOAVISO =  '{this.V1RCAC_BCOAVISO}'
				AND AGEAVISO =  '{this.V1RCAC_AGEAVISO}'
				AND NRAVISO =  '{this.V1RCAC_NRAVISO}'";

            return query;
        }
        public string V1RCAC_VLRCAP { get; set; }
        public string V1RCAC_BCOAVISO { get; set; }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }

        public static void Execute(R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1)
        {
            var ths = r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}