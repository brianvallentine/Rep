using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1 : QueryBasis<R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0CLIENTE_CROT
				SET BILH_AP =  '{this.V0CROT_BILH_AP}' ,
				DTMOVABE =  '{this.V0CROT_DTMOVABE}'
				WHERE  CGCCPF =  '{this.V0BILH_CGCCPF}'";

            return query;
        }
        public string V0CROT_DTMOVABE { get; set; }
        public string V0CROT_BILH_AP { get; set; }
        public string V0BILH_CGCCPF { get; set; }

        public static void Execute(R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1 r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1)
        {
            var ths = r3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3240_00_UPDATE_CROT_AP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}