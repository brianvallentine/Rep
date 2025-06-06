using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1 : QueryBasis<R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COSSEG_SINI
				SET SITUACAO =  '{this.WHOST_SITUACAO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  TIPSGU =  '{this.V1CSIN_TIPSGU}'
				AND CONGENER =  '{this.V1CSIN_CONGENER}'
				AND NUM_SINISTRO =  '{this.V1CSIN_NUM_SINI}'";

            return query;
        }
        public string WHOST_SITUACAO { get; set; }
        public string V1CSIN_CONGENER { get; set; }
        public string V1CSIN_NUM_SINI { get; set; }
        public string V1CSIN_TIPSGU { get; set; }

        public static void Execute(R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1 r2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1)
        {
            var ths = r2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}