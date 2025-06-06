using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1415_00_SEL_TITULO_DB_UPDATE_1_Update1 : QueryBasis<R1415_00_SEL_TITULO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CEDENTE
				SET NUM_TITULO = NUM_TITULO + 1
				WHERE COD_CEDENTE = 36";

            return query;
        }

        public static void Execute(R1415_00_SEL_TITULO_DB_UPDATE_1_Update1 r1415_00_SEL_TITULO_DB_UPDATE_1_Update1)
        {
            var ths = r1415_00_SEL_TITULO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1415_00_SEL_TITULO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}