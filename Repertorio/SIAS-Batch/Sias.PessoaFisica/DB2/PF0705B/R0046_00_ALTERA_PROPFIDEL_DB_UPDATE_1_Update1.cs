using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1 : QueryBasis<R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SITUACAO_ENVIO = 'R'
				,NSAS_SIVPF =  '{this.PROPFIDH_NSAS_SIVPF}'
				,NSL =  '{this.PROPFIDH_NSL}'
				,COD_USUARIO = 'PF0705B'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPFIDH_NSAS_SIVPF { get; set; }
        public string PROPFIDH_NSL { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1 r0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1)
        {
            var ths = r0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}