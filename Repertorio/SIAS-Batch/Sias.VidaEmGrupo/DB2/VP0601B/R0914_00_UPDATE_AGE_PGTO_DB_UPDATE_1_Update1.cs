using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1 : QueryBasis<R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET AGEPGTO = '{this.PROPOFID_AGEPGTO}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1 r0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1)
        {
            var ths = r0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}