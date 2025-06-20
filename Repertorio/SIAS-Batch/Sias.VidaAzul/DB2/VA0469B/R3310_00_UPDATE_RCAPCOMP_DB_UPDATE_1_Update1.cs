using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAP_COMPLEMENTAR
				SET SIT_REGISTRO = '1'
				WHERE  NUM_RCAP =  '{this.RCAPCOMP_NUM_RCAP}'
				AND COD_FONTE =  '{this.RCAPCOMP_COD_FONTE}'";

            return query;
        }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static void Execute(R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 r3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = r3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}