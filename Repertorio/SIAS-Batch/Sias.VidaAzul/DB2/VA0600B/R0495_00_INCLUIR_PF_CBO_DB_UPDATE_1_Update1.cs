using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1 : QueryBasis<R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_FISICA
				SET COD_CBO =  '{this.COD_CBO}'
				WHERE  COD_PESSOA =  '{this.COD_PESSOA}'";

            return query;
        }
        public string COD_CBO { get; set; }
        public string COD_PESSOA { get; set; }

        public static void Execute(R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1 r0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1)
        {
            var ths = r0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}