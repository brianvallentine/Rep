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
    public class R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 : QueryBasis<R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAPS
				SET SIT_REGISTRO = '1'
				,COD_OPERACAO = 210
				,NUM_APOLICE =  '{this.RCAPS_NUM_APOLICE}'
				,NUM_ENDOSSO =  '{this.RCAPS_NUM_ENDOSSO}'
				,NUM_PARCELA =  '{this.RCAPS_NUM_PARCELA}'
				WHERE  NUM_RCAP =  '{this.RCAPCOMP_NUM_RCAP}'
				AND COD_FONTE =  '{this.RCAPCOMP_COD_FONTE}'";

            return query;
        }
        public string RCAPS_NUM_APOLICE { get; set; }
        public string RCAPS_NUM_ENDOSSO { get; set; }
        public string RCAPS_NUM_PARCELA { get; set; }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static void Execute(R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 r3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}