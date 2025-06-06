using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1 : QueryBasis<R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.NUMERO_OUTROS
				SET NUM_CLIENTE =  '{this.SEGURVGA_COD_CLIENTE}'
				WHERE  1 = 1";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static void Execute(R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1 r0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1)
        {
            var ths = r0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}