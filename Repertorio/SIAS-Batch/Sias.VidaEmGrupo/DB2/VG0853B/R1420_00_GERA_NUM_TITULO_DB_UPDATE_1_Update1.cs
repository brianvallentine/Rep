using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1 : QueryBasis<R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CEDENTE
				SET NUM_TITULO = NUM_TITULO + 1,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_CEDENTE = 36";

            return query;
        }

        public static void Execute(R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1 r1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1)
        {
            var ths = r1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}