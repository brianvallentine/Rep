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
    public class R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 : QueryBasis<R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO =  '{this.PROPOVA_SIT_REGISTRO}',
				TIMESTAMP = CURRENT TIMESTAMP,
				DATA_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				DTA_DECLINIO =  '{this.WDTA_DECLINIO}',
				COD_USUARIO =  '{this.RELATORI_COD_USUARIO}'
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string WDTA_DECLINIO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 r2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1)
        {
            var ths = r2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}