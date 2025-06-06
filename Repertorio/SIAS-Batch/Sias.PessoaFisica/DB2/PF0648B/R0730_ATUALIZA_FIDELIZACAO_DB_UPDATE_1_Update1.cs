using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1 : QueryBasis<R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET DTQITBCO = '{this.DTQITBCO}',
				VAL_PAGO = '{this.VAL_PAGO}',
				AGEPGTO = '{this.AGEPGTO}',
				VAL_TARIFA
				= '{this.VAL_TARIFA}',
				DATA_CREDITO
				= '{this.DATA_CREDITO}',
				VAL_COMISSAO
				= '{this.VAL_COMISSAO}',
				COD_USUARIO
				= '{this.COD_USUARIO}',
				NSAS_SIVPF = '{this.NSAS_SIVPF}',
				NSAC_SIVPF = '{this.NSAC_SIVPF}',
				NSL = '{this.NSL}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string DATA_CREDITO { get; set; }
        public string VAL_COMISSAO { get; set; }
        public string COD_USUARIO { get; set; }
        public string VAL_TARIFA { get; set; }
        public string NSAS_SIVPF { get; set; }
        public string NSAC_SIVPF { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string AGEPGTO { get; set; }
        public string NSL { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1 r0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1)
        {
            var ths = r0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}