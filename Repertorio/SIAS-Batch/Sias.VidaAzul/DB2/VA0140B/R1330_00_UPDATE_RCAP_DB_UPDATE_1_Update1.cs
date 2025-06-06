using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 : QueryBasis<R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAPS
				SET SIT_REGISTRO =  '{this.RCAPS_SIT_REGISTRO}'
				,COD_OPERACAO =  '{this.RCAPS_COD_OPERACAO}'
				WHERE  NUM_RCAP =  '{this.RCAPCOMP_NUM_RCAP}'";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static void Execute(R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}