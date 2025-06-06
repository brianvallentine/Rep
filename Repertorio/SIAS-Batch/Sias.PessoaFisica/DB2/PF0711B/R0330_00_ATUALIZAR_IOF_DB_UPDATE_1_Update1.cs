using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0711B
{
    public class R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1 : QueryBasis<R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET VAL_IOF =  '{this.VAL_IOF}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string VAL_IOF { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1 r0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1)
        {
            var ths = r0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}