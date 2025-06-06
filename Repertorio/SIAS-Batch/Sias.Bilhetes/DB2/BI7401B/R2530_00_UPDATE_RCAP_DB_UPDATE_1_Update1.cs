using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1 : QueryBasis<R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAPS
				SET SIT_REGISTRO =  '{this.RCAPS_SIT_REGISTRO}'
				WHERE  COD_FONTE =  '{this.RCAPS_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPS_NUM_RCAP}'";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static void Execute(R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1 r2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2530_00_UPDATE_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}