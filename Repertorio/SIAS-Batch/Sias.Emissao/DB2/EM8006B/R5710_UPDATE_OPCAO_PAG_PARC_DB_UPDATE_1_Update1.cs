using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1 : QueryBasis<R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET OPCAO_PAGAMENTO = '3'
				WHERE  NUM_CERTIFICADO =  '{this.WS_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.WS_NUM_PARCELA}'";

            return query;
        }
        public string WS_NUM_CERTIFICADO { get; set; }
        public string WS_NUM_PARCELA { get; set; }

        public static void Execute(R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1 r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1)
        {
            var ths = r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}