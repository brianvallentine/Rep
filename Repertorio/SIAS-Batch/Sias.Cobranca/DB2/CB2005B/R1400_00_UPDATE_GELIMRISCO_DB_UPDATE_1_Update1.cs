using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1 : QueryBasis<R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_LIMITE_DE_RISCO
				SET QTD_SEGUROS =  '{this.GELMR_QTD_SEGUROS}',
				VLR_SOMA_IS =  '{this.GELMR_VLR_SOMA_IS}',
				COD_USUARIO = 'CB2005B' ,
				DTH_TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CGCCPF =  '{this.V0CLIE_CGCCPF}'";

            return query;
        }
        public string GELMR_QTD_SEGUROS { get; set; }
        public string GELMR_VLR_SOMA_IS { get; set; }
        public string V0CLIE_CGCCPF { get; set; }

        public static void Execute(R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1 r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1)
        {
            var ths = r1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}