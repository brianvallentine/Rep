using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1 : QueryBasis<R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL
				SET NUM_CARTAO_CREDITO =  '{this.OPCPAGVI_NUM_CARTAO_CREDITO}'
				WHERE  NUM_CERTIFICADO =  '{this.OPCPAGVI_NUM_CERTIFICADO}'
				AND OPCAO_PAGAMENTO = '5'
				AND DATA_INIVIGENCIA <=  '{this.WS_DATA_GERACAO_PARCELA}'
				AND DATA_TERVIGENCIA >=  '{this.WS_DATA_GERACAO_PARCELA}'";

            return query;
        }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string WS_DATA_GERACAO_PARCELA { get; set; }

        public static void Execute(R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1 r3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1)
        {
            var ths = r3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}