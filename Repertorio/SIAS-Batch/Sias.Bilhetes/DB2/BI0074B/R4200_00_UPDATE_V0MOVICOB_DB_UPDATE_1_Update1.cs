using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET SIT_REGISTRO =
				 '{this.MOVIMCOB_SIT_REGISTRO}'
				WHERE  NUM_NOSSO_TITULO =
				 '{this.MOVIMCOB_NUM_NOSSO_TITULO}'
				AND TIPO_MOVIMENTO =
				'T'
				AND DATA_MOVIMENTO <=  '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1)
        {
            var ths = r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}