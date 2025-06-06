using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1 : QueryBasis<R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0CONTPROP
				SET SITUACAO = '1' ,
				OCORHIST = OCORHIST + 1,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V1PROP_FONTE}'
				AND NRPROPOS =  '{this.V1PROP_NRPROPOS}'";

            return query;
        }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static void Execute(R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1 r4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1)
        {
            var ths = r4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}