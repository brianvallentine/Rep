using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105B
{
    public class P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE FDRCAP.FC_PROPOSTA
				SET STA_PROPOSTA = 'CAN' ,
				IND_ENVIO_SIGPF = 2
				WHERE  NUM_PLANO =  '{this.FCTITULO_NUM_PLANO}'
				AND NUM_PROPOSTA =  '{this.FCPROPOS_NUM_PROPOSTA}'
				AND NUM_NSA =  '{this.FCPROPOS_NUM_NSA}'
				AND NUM_MOD_PLANO =  '{this.FC239_NUM_MOD_PLANO}'";

            return query;
        }
        public string FCPROPOS_NUM_PROPOSTA { get; set; }
        public string FC239_NUM_MOD_PLANO { get; set; }
        public string FCTITULO_NUM_PLANO { get; set; }
        public string FCPROPOS_NUM_NSA { get; set; }

        public static void Execute(P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 p090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = p090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}