using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1 : QueryBasis<R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.LT_SOLICITA_PARAM
				SET SIT_SOLICITACAO = '3'
				WHERE  COD_PROGRAMA = 'VA1476B'
				AND SIT_SOLICITACAO = '0'";

            return query;
        }

        public static void Execute(R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1 r5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1)
        {
            var ths = r5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}