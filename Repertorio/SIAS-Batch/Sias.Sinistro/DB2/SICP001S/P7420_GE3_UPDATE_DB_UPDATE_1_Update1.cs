using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7420_GE3_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<P7420_GE3_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_MOVTO_ENVIO_MCP
				SET COD_TP_SERVICO_INSS =  '{this.GE420_COD_TP_SERVICO_INSS}'
				WHERE  NUM_ID_ENVIO =  '{this.GE420_NUM_ID_ENVIO}'
				AND SEQ_ID_ENVIO_HIST =  '{this.GE420_SEQ_ID_ENVIO_HIST}'";

            return query;
        }
        public string GE420_COD_TP_SERVICO_INSS { get; set; }
        public string GE420_SEQ_ID_ENVIO_HIST { get; set; }
        public string GE420_NUM_ID_ENVIO { get; set; }

        public static void Execute(P7420_GE3_UPDATE_DB_UPDATE_1_Update1 p7420_GE3_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = p7420_GE3_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7420_GE3_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}