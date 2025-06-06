using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0055B
{
    public class R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1 : QueryBasis<R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0HISTOREC
				SET NUM_APOLICE =  '{this.V0HISR_NUM_APOL}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMOPG =  '{this.V1ADIA_NUMOPG}'
				AND NUM_APOLICE =  '{this.WHOST_NUM_APOL}'
				AND OPERACAO = 1401";

            return query;
        }
        public string V0HISR_NUM_APOL { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string V1ADIA_NUMOPG { get; set; }

        public static void Execute(R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1 r4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1)
        {
            var ths = r4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}