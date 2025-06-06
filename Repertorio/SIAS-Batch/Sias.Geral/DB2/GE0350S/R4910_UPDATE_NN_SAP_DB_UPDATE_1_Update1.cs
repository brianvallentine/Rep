using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1 : QueryBasis<R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
				SET NUM_APOLICE =  '{this.GE403_NUM_APOLICE}'
				,NUM_ENDOSSO =  '{this.GE403_NUM_ENDOSSO}'
				,NUM_PARCELA =  '{this.GE403_NUM_PARCELA}'
				,NUM_TITULO =
				 {FieldThreatment((this.WS_IND_NUM_TITULO?.ToInt() == -1 ? null : $"{this.GE403_NUM_TITULO}"))}
				,DTH_PROCESSAMENTO = CURRENT_TIMESTAMP
				WHERE  NUM_NOSSO_NUMERO_SAP = '{this.GE403_NUM_NOSSO_NUMERO_SAP}'
				AND SEQ_CONTROLE_SIGCB =  '{this.GE403_SEQ_CONTROLE_SIGCB}'";

            return query;
        }
        public string GE403_NUM_TITULO { get; set; }
        public string WS_IND_NUM_TITULO { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }

        public static void Execute(R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1 r4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1)
        {
            var ths = r4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}