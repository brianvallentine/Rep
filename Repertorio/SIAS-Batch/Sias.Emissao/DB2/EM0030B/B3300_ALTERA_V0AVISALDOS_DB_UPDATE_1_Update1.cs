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
    public class B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1 : QueryBasis<B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0AVISOS_SALDOS
				SET SDOATU =  '{this.V1ASAL_SDOATU}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BCOAVISO =  '{this.V1ASAL_BCOAVISO}'
				AND AGEAVISO =  '{this.V1ASAL_AGEAVISO}'
				AND NRAVISO =  '{this.V1ASAL_NRAVISO}'";

            return query;
        }
        public string V1ASAL_SDOATU { get; set; }
        public string V1ASAL_BCOAVISO { get; set; }
        public string V1ASAL_AGEAVISO { get; set; }
        public string V1ASAL_NRAVISO { get; set; }

        public static void Execute(B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1 b3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1)
        {
            var ths = b3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}