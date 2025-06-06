using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1 : QueryBasis<R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_FISICA
				SET DATA_EXPEDICAO =
				 '{this.DATA_EXPEDICAO}'
				WHERE  COD_PESSOA =  '{this.COD_PESSOA}'";

            return query;
        }
        public string DATA_EXPEDICAO { get; set; }
        public string COD_PESSOA { get; set; }

        public static void Execute(R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1 r0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1)
        {
            var ths = r0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}