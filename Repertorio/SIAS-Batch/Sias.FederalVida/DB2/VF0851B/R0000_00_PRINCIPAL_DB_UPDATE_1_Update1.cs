using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 : QueryBasis<R0000_00_PRINCIPAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BANCO
				SET NRTIT =  '{this.V0BANC_NRTIT}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BANCO = 104";

            return query;
        }
        public string V0BANC_NRTIT { get; set; }

        public static void Execute(R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 r0000_00_PRINCIPAL_DB_UPDATE_1_Update1)
        {
            var ths = r0000_00_PRINCIPAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}