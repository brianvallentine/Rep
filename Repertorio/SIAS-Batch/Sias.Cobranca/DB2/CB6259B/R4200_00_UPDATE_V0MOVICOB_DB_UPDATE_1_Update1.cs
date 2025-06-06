using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6259B
{
    public class R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET COD_BANCO =  '{this.MOVIMCOB_COD_BANCO}'
				,COD_AGENCIA =  '{this.MOVIMCOB_COD_AGENCIA}'
				,NUM_AVISO =  '{this.MOVIMCOB_NUM_AVISO}'
				,NUM_TITULO =  '{this.MOVIMCOB_NUM_TITULO}'
				,SIT_REGISTRO =  '{this.MOVIMCOB_SIT_REGISTRO}'
				WHERE  NUM_NOSSO_TITULO =  '{this.MOVIMCOB_NUM_NOSSO_TITULO}'
				AND SIT_REGISTRO = ' '
				AND TIPO_MOVIMENTO = 'G'";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }

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