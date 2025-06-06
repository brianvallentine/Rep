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
    public class R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET NUM_TITULO =
				 '{this.MOVIMCOB_NUM_TITULO}' ,
				NUM_APOLICE =
				 '{this.MOVIMCOB_NUM_APOLICE}' ,
				NUM_AVISO =
				 '{this.MOVIMCOB_NUM_AVISO}'
				WHERE  NUM_NOSSO_TITULO =
				 '{this.WSHOST_NUM_NOSSO_TITULO}'
				AND TIPO_MOVIMENTO =
				'T'
				AND DATA_MOVIMENTO <=  '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WSHOST_NUM_NOSSO_TITULO { get; set; }

        public static void Execute(R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 r0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1)
        {
            var ths = r0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}