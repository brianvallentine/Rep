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
    public class R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.V0FONT_PROPAUTOM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0PROP_FONTE}'";

            return query;
        }
        public string V0FONT_PROPAUTOM { get; set; }
        public string V0PROP_FONTE { get; set; }

        public static void Execute(R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1 r1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = r1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_20_LOOP_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}