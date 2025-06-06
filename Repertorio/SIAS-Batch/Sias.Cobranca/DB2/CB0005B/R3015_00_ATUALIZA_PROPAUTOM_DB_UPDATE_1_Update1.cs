using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1 : QueryBasis<R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.V1FONT_PROPAUTOM}'
				WHERE  FONTE =  '{this.V0BILH_FONTE}'";

            return query;
        }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0BILH_FONTE { get; set; }

        public static void Execute(R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1 r3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1)
        {
            var ths = r3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3015_00_ATUALIZA_PROPAUTOM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}