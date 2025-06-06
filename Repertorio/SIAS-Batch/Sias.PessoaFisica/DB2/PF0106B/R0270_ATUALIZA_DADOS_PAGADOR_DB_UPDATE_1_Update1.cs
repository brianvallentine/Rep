using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0106B
{
    public class R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1 : QueryBasis<R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PF_PAGADOR_SIVPF
				SET NOM_PAGADOR =  '{this.PF039_NOM_PAGADOR}' ,
				DTH_NASCIMENTO =  '{this.PF039_DTH_NASCIMENTO}',
				NUM_TELEFONE =  '{this.PF039_NUM_TELEFONE}'
				WHERE  NUM_CGC_CPF =  '{this.PF039_NUM_CGC_CPF}'";

            return query;
        }
        public string PF039_DTH_NASCIMENTO { get; set; }
        public string PF039_NUM_TELEFONE { get; set; }
        public string PF039_NOM_PAGADOR { get; set; }
        public string PF039_NUM_CGC_CPF { get; set; }

        public static void Execute(R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1 r0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1)
        {
            var ths = r0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}