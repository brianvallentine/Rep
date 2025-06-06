using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1 : QueryBasis<R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SITUACAO_ENVIO = 'S'
				WHERE  NUM_SICOB =  '{this.PROPOFID_NUM_SICOB}'";

            return query;
        }
        public string PROPOFID_NUM_SICOB { get; set; }

        public static void Execute(R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1 r3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1)
        {
            var ths = r3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}