using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1 : QueryBasis<R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.NUMERO_OUTROS
				SET
				NUM_CLIENTE =  '{this.NUMEROUT_NUM_CLIENTE}'
				WHERE  1 = 1";

            return query;
        }
        public string NUMEROUT_NUM_CLIENTE { get; set; }

        public static void Execute(R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1 r8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1)
        {
            var ths = r8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}