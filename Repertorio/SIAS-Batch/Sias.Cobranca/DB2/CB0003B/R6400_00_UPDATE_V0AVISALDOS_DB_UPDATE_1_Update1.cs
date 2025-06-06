using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1 : QueryBasis<R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0AVISOS_SALDOS
				SET SDOATU = (SDOATU -  '{this.V1MCOB_VALTIT}') ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BCOAVISO =  '{this.V1MCOB_BANCO}'
				AND AGEAVISO =  '{this.V1MCOB_AGENCIA}'
				AND NRAVISO =  '{this.V1MCOB_NRAVISO}'";

            return query;
        }
        public string V1MCOB_VALTIT { get; set; }
        public string V1MCOB_AGENCIA { get; set; }
        public string V1MCOB_NRAVISO { get; set; }
        public string V1MCOB_BANCO { get; set; }

        public static void Execute(R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1 r6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1)
        {
            var ths = r6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}