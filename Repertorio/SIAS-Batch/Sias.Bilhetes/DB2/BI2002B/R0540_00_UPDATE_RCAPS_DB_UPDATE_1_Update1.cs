using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1 : QueryBasis<R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.RCAPS
				SET NUM_APOLICE =  '{this.CBCONDEV_NUM_APOLICE}'
				,NUM_ENDOSSO =  '{this.CBCONDEV_NUM_ENDOSSO}'
				,NUM_PARCELA =  '{this.CBCONDEV_NUM_PARCELA}'
				,CODIGO_PRODUTO =  '{this.CBCONDEV_COD_PRODUTO}'
				WHERE  COD_FONTE =  '{this.RCAPS_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPS_NUM_RCAP}'";

            return query;
        }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }
        public string CBCONDEV_NUM_PARCELA { get; set; }
        public string CBCONDEV_COD_PRODUTO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static void Execute(R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1 r0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1)
        {
            var ths = r0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}