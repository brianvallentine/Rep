using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0416B
{
    public class R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1'
				WHERE  CODRELAT = 'VA0417B'
				AND SITUACAO = '0'";

            return query;
        }

        public static void Execute(R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}