using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 : QueryBasis<R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WHOST_SIT_PROPOSTA}',
				SITUACAO_ENVIO =  '{this.WHOST_SIT_ENVIO}' ,
				COD_USUARIO = 'PF0619B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'
				AND SIT_PROPOSTA NOT IN ( 'MAN' , 'EMT' , 'CAN' , 'REJ' )";

            return query;
        }
        public string WHOST_SIT_PROPOSTA { get; set; }
        public string WHOST_SIT_ENVIO { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 r0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1)
        {
            var ths = r0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}