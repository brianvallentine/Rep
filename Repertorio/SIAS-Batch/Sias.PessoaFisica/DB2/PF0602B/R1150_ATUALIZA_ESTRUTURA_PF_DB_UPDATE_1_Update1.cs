using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1 : QueryBasis<R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WHOST_SIT_PROPOSTA}',
				SITUACAO_ENVIO =  '{this.WHOST_SIT_ENVIO}',
				DTQITBCO =  '{this.DTQITBCO}',
				VAL_PAGO =  '{this.VAL_PAGO}',
				DATA_CREDITO =  '{this.DATA_CREDITO}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string DATA_CREDITO { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string WHOST_SIT_PROPOSTA { get; set; }
        public string WHOST_SIT_ENVIO { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1 r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1)
        {
            var ths = r1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}