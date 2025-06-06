using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1 : QueryBasis<R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0APOLINDICA
				SET NUM_APOLICE =  '{this.V0APOIN_NUM_APOLICE}',
				NRENDOS =  '{this.V0APOIN_NRENDOS}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0APOIN_FONTE}'
				AND NRPROPOS =  '{this.V0APOIN_NRPROPOS}'
				AND TIPOFUNC =  '{this.V0APOIN_TIPOFUNC}'";

            return query;
        }
        public string V0APOIN_NUM_APOLICE { get; set; }
        public string V0APOIN_NRENDOS { get; set; }
        public string V0APOIN_NRPROPOS { get; set; }
        public string V0APOIN_TIPOFUNC { get; set; }
        public string V0APOIN_FONTE { get; set; }

        public static void Execute(R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1 r0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1)
        {
            var ths = r0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}