using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1 : QueryBasis<R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET DTQITBCO =
				 '{this.PROPOFID_DTQITBCO}' ,
				DATA_CREDITO =
				 '{this.PROPOFID_DATA_CREDITO}' ,
				AGEPGTO =
				 '{this.PROPOFID_AGEPGTO}' ,
				SIT_PROPOSTA =
				 '{this.PROPOFID_SIT_PROPOSTA}' ,
				VAL_PAGO =
				 '{this.PROPOFID_VAL_PAGO}' ,
				SITUACAO_ENVIO =
				 '{this.PROPOFID_SITUACAO_ENVIO}',
				COD_USUARIO =
				 '{this.PROPOFID_COD_USUARIO}'
				WHERE NUM_PROPOSTA_SIVPF =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1 r9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1)
        {
            var ths = r9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}