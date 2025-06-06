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
    public class R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAP_COMPLEMENTAR
				SET SIT_REGISTRO = '1'
				WHERE  COD_FONTE =  '{this.RCAPS_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPS_NUM_RCAP}'
				AND NUM_RCAP_COMPLEMEN = 0
				AND COD_OPERACAO <>  '{this.RCAPS_COD_OPERACAO}'";

            return query;
        }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static void Execute(R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 r2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = r2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}