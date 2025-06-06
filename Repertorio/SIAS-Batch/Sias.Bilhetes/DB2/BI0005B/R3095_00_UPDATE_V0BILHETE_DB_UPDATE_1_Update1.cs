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
    public class R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET AGECOBR =  '{this.V1COFE_AGECOBR}'
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V1COFE_AGECOBR { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}