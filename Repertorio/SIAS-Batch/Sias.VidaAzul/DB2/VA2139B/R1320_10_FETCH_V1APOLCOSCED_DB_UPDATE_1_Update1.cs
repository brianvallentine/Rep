using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2139B
{
    public class R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 : QueryBasis<R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_COSSEGURO
				SET NRORDEM =  '{this.V1NCOS_NRORDEM}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  ORGAO =  '{this.V1NCOS_ORGAO}'
				AND CONGENER =  '{this.V1NCOS_CONGENER}'";

            return query;
        }
        public string V1NCOS_NRORDEM { get; set; }
        public string V1NCOS_CONGENER { get; set; }
        public string V1NCOS_ORGAO { get; set; }

        public static void Execute(R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 r1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1)
        {
            var ths = r1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1320_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}