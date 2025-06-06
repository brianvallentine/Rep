using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1 : QueryBasis<R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COSSEG_HISTSIN
				SET SIT_LIBRECUP = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CONGENER =  '{this.V1CHSI_CONGENER}'
				AND NUM_SINISTRO =  '{this.V1CHSI_NUM_SINI}'
				AND OCORHIST =  '{this.V1CHSI_OCORHIST}'
				AND DTMOVTO =  '{this.V1CHSI_DTMOVTO}'
				AND OPERACAO =  '{this.V1CHSI_OPERACAO}'";

            return query;
        }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }
        public string V1CHSI_OPERACAO { get; set; }
        public string V1CHSI_DTMOVTO { get; set; }

        public static void Execute(R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1 r1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1)
        {
            var ths = r1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}