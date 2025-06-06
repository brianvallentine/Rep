using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 : QueryBasis<R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET COD_USUARIO = 'VP1111B'
				WHERE  NUM_PROPOSTA_SIVPF =  '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 r20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1)
        {
            var ths = r20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}