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
    public class R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1 : QueryBasis<R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET NUM_TITULO =  '{this.MOVIMCOB_NUM_TITULO}'
				WHERE  COD_BANCO =  '{this.MOVIMCOB_COD_BANCO}'
				AND COD_AGENCIA =  '{this.MOVIMCOB_COD_AGENCIA}'
				AND NUM_FITA =  '{this.MOVIMCOB_NUM_FITA}'
				AND NUM_TITULO = 0
				AND NUM_NOSSO_TITULO =  '{this.MOVIMCOB_NUM_NOSSO_TITULO}'
				AND NUM_AVISO =  '{this.MOVIMCOB_NUM_AVISO}'
				AND COD_MOVIMENTO =  '{this.MOVIMCOB_COD_MOVIMENTO}'";

            return query;
        }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string MOVIMCOB_COD_MOVIMENTO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_FITA { get; set; }

        public static void Execute(R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1 r4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1)
        {
            var ths = r4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}