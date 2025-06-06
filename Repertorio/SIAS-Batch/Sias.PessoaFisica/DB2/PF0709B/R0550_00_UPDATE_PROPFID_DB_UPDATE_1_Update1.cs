using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0709B
{
    public class R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 : QueryBasis<R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET NSAS_SIVPF =  '{this.PROPFIDH_NSAS_SIVPF}',
				NSL =  '{this.PROPFIDH_NSL}' ,
				COD_USUARIO =  '{this.PROPOFID_COD_USUARIO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPFIDH_NSAS_SIVPF { get; set; }
        public string PROPFIDH_NSL { get; set; }
        public string NUM_CERTIFICADO { get; set; }

        public static void Execute(R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 r0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1)
        {
            var ths = r0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}