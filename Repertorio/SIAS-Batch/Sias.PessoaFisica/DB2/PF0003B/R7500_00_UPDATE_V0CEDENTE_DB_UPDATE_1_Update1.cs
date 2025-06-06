using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 : QueryBasis<R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0CEDENTE
				SET NUMTIT =  '{this.V0CEDE_NUMTIT}'
				WHERE  CODCDT = 26";

            return query;
        }
        public string V0CEDE_NUMTIT { get; set; }

        public static void Execute(R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1)
        {
            var ths = r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}