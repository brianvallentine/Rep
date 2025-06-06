using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 : QueryBasis<R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAPS
				SET SIT_REGISTRO = '1' ,
				COD_OPERACAO = 210
				WHERE  NUM_TITULO =  '{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string RCAPS_NUM_TITULO { get; set; }

        public static void Execute(R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 r3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}