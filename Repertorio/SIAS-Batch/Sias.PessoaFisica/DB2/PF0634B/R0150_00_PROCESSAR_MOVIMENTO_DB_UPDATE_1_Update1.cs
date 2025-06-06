using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0634B
{
    public class R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1 : QueryBasis<R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SITUACAO_ENVIO = 'R' ,
				NSAS_SIVPF =
				 '{this.NSAS_SIVPF}' ,
				NSL =
				 '{this.NSL}' ,
				SIT_PROPOSTA =
				 '{this.SIT_PROPOSTA}',
				VAL_IOF =
				 '{this.VAL_IOF}' ,
				COD_USUARIO =
				 '{this.COD_USUARIO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string SIT_PROPOSTA { get; set; }
        public string COD_USUARIO { get; set; }
        public string NSAS_SIVPF { get; set; }
        public string VAL_IOF { get; set; }
        public string NSL { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1 r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1)
        {
            var ths = r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}