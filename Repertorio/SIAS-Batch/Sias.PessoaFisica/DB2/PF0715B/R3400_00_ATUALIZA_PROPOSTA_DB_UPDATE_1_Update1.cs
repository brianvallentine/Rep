using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET NSAS_SIVPF =  '{this.PROPOFID_NSAS_SIVPF}',
				NSL =  '{this.PROPOFID_NSL}',
				SIT_PROPOSTA =  '{this.PROPOFID_SIT_PROPOSTA}',
				COD_USUARIO =  '{this.PROPOFID_COD_USUARIO}',
				SITUACAO_ENVIO =  '{this.PROPOFID_SITUACAO_ENVIO}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1 r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}