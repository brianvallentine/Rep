using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1 : QueryBasis<R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.RCAPS
				SET NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'
				,NUM_ENDOSSO =  '{this.PARCEHIS_NUM_ENDOSSO}'
				,NUM_PARCELA =  '{this.PARCEHIS_NUM_PARCELA}'
				,CODIGO_PRODUTO =  '{this.ENDOSSOS_COD_PRODUTO}'
				WHERE  NUM_TITULO =  '{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static void Execute(R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1 r4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1)
        {
            var ths = r4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}