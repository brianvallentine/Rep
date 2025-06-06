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
    public class R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 : QueryBasis<R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SITUACAO_ENVIO = 'S' ,
				COD_USUARIO = 'PF0617B' ,
				SIT_PROPOSTA =  '{this.PROPOFID_SIT_PROPOSTA}'
				WHERE  NUM_SICOB =  '{this.NUM_APOL_ANT}'";

            return query;
        }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string NUM_APOL_ANT { get; set; }

        public static void Execute(R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 r0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1)
        {
            var ths = r0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}